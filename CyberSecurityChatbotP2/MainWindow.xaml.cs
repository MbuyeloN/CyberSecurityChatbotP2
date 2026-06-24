using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityChatbotP2
{
    public partial class MainWindow : Window
    {
        Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        Random random = new Random();

        string userName = "";
        string favouriteTopic = "";

        private List<string> tasks = new List<string>();
        private List<string> activityLog = new List<string>();

        private bool quizActive = false;
        private int currentQuestion = 0;
        private int quizScore = 0;

        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>()
        {
            new QuizQuestion("What does 2FA stand for?", "Two-Factor Authentication", "Two-Fast Access", "Two-File Approval", "a"),
            new QuizQuestion("Which one is an example of a strong password?", "123456", "Password123", "G7@kL!92zP", "c"),
            new QuizQuestion("What is phishing?", "A type of online scam", "A computer update", "A strong password", "a"),
            new QuizQuestion("Which website is usually more secure?", "http://example.com", "https://example.com", "www.example", "b"),
            new QuizQuestion("What should you do with suspicious email links?", "Click them quickly", "Ignore or verify them first", "Forward them to everyone", "b"),
            new QuizQuestion("What is malware?", "Helpful software", "Harmful software", "A password manager", "b"),
            new QuizQuestion("Why should software be updated?", "To improve security", "To delete all files", "To make passwords public", "a"),
            new QuizQuestion("Should you share your password with friends?", "Yes", "No", "Only sometimes", "b"),
            new QuizQuestion("What does antivirus software help with?", "Detecting and blocking threats", "Creating weak passwords", "Sharing private information", "a"),
            new QuizQuestion("What is a common sign of a scam?", "Urgency and pressure", "Clear verified information", "Secure official communication", "a")
        };

        public MainWindow()
        {
            InitializeComponent();

            LoadResponses();
            PlayGreeting();

            BotMessage("Hello! Welcome to the Cybersecurity Awareness Chatbot.");
            BotMessage("Please tell me your name to begin.");
        }

        private void LoadResponses()
        {
            responses["password"] = new List<string>()
            {
                "Use strong passwords with uppercase letters, numbers, and symbols.",
                "Avoid using your birthday or personal information in passwords.",
                "Use different passwords for different accounts."
            };

            responses["phishing"] = new List<string>()
            {
                "Never click suspicious email links.",
                "Check email addresses carefully before responding.",
                "Phishing scams often create urgency to trick users."
            };

            responses["privacy"] = new List<string>()
            {
                "Review your social media privacy settings regularly.",
                "Avoid sharing sensitive personal information online.",
                "Use secure websites with HTTPS protection."
            };

            responses["scam"] = new List<string>()
            {
                "Scammers often pretend to be trusted organisations.",
                "Never send money to unknown people online.",
                "Be cautious of deals that seem too good to be true."
            };

            responses["malware"] = new List<string>()
            {
                "Install antivirus software on your devices.",
                "Do not download files from unknown websites.",
                "Keep your software updated to prevent malware attacks."
            };

            responses["2fa"] = new List<string>()
            {
                "Two-factor authentication adds an extra layer of security to your account.",
                "2FA helps protect your accounts even if someone steals your password.",
                "Use 2FA on important accounts such as banking, email, and social media."
            };

            responses["two-factor authentication"] = responses["2fa"];
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                BotMessage("Please enter a message.");
                return;
            }

            WelcomePanel.Visibility = Visibility.Collapsed;

            string time = DateTime.Now.ToString("HH:mm");
            ChatDisplay.AppendText("[" + time + "] You: " + input + "\n\n");

            UserInput.Clear();

            string lowerInput = input.ToLower();

            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "bye")
            {
                BotMessage("Thank you for using the Cybersecurity Awareness Chatbot.");
                BotMessage("Goodbye and stay safe online!");

                Application.Current.Shutdown();
                return;
            }

            if (string.IsNullOrEmpty(userName))
            {
                userName = input;

                BotMessage("Nice to meet you, " + userName + "!");
                BotMessage("You can ask me about passwords, phishing, scams, privacy, malware, or 2FA.");
                BotMessage("Type 'start quiz' to begin the cybersecurity quiz.");
                BotMessage("Type 'show activity' to view your activity log.");
                BotMessage("Type 'exit', 'quit', or 'bye' to close the chatbot.");

                return;
            }

            if (quizActive)
            {
                CheckQuizAnswer(lowerInput);
                return;
            }

            HandleSentiment(input);

            bool found = false;

            if (lowerInput == "start quiz")
            {
                StartQuiz();
                found = true;
            }
            else if (lowerInput.Contains("how are you"))
            {
                BotMessage("I am doing well, " + userName + ". Thank you for asking. I am ready to help you stay safe online.");
                found = true;
            }
            else if (lowerInput.Contains("what can you do"))
            {
                BotMessage("I can answer questions about password safety, phishing, privacy, malware, scams, and two-factor authentication.");
                BotMessage("I can also help you manage cybersecurity tasks, show your activity log, and run a cybersecurity quiz.");
                found = true;
            }
            else if (lowerInput.Contains("thank you") || lowerInput.Contains("thanks"))
            {
                BotMessage("You are welcome, " + userName + "! Staying informed is one of the best ways to stay safe online.");
                found = true;
            }
            else if (lowerInput.Contains("your name"))
            {
                BotMessage("I am the Cybersecurity Awareness Chatbot, your digital safety assistant.");
                found = true;
            }
            else if (lowerInput == "show activity")
            {
                if (activityLog.Count == 0)
                {
                    BotMessage("No activities have been recorded yet.");
                }
                else
                {
                    BotMessage("Activity Log:");

                    foreach (string activity in activityLog)
                    {
                        BotMessage(activity);
                    }
                }

                found = true;
            }

            foreach (var item in responses)
            {
                if (lowerInput.Contains(item.Key))
                {
                    string response = item.Value[random.Next(item.Value.Count)];

                    BotMessage(response);

                    favouriteTopic = item.Key;
                    found = true;
                    break;
                }
            }

            if (lowerInput.Contains("another") ||
                lowerInput.Contains("more") ||
                lowerInput.Contains("tell me more") ||
                lowerInput.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    string response =
                        responses[favouriteTopic][random.Next(responses[favouriteTopic].Count)];

                    BotMessage("Here is another tip about " + favouriteTopic + ":");
                    BotMessage(response);

                    found = true;
                }
                else
                {
                    BotMessage("Please ask about a cybersecurity topic first, then I can give you more information.");
                    found = true;
                }
            }

            if (lowerInput.Contains("my favourite topic") ||
                lowerInput.Contains("my favorite topic"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    BotMessage("Your favourite cybersecurity topic seems to be " + favouriteTopic + ".");
                }
                else
                {
                    BotMessage("I have not saved a favourite topic for you yet.");
                }

                found = true;
            }

            if (!found)
            {
                BotMessage("I am not sure I understand. Can you try rephrasing?");
            }
        }

        private void StartQuiz()
        {
            quizActive = true;
            currentQuestion = 0;
            quizScore = 0;

            LogActivity("Cybersecurity Quiz Started");

            BotMessage("Cybersecurity Quiz started!");
            BotMessage("Please answer using a, b, or c.");

            DisplayQuizQuestion();
        }

        private void DisplayQuizQuestion()
        {
            QuizQuestion question = quizQuestions[currentQuestion];

            BotMessage("Question " + (currentQuestion + 1) + "/" + quizQuestions.Count + ":");
            BotMessage(question.Question);
            BotMessage("a) " + question.OptionA);
            BotMessage("b) " + question.OptionB);
            BotMessage("c) " + question.OptionC);
        }

        private void CheckQuizAnswer(string answer)
        {
            if (answer != "a" && answer != "b" && answer != "c")
            {
                BotMessage("Please answer using only a, b, or c.");
                return;
            }

            QuizQuestion question = quizQuestions[currentQuestion];

            if (answer == question.CorrectAnswer)
            {
                quizScore++;
                BotMessage("Correct!");
            }
            else
            {
                BotMessage("Incorrect. The correct answer was: " + question.CorrectAnswer);
            }

            currentQuestion++;

            if (currentQuestion < quizQuestions.Count)
            {
                DisplayQuizQuestion();
            }
            else
            {
                quizActive = false;

                BotMessage("Quiz complete!");
                BotMessage("Your final score is " + quizScore + "/" + quizQuestions.Count + ".");

                if (quizScore >= 8)
                {
                    BotMessage("Excellent work, " + userName + "! You have strong cybersecurity awareness.");
                }
                else if (quizScore >= 5)
                {
                    BotMessage("Good effort, " + userName + ". Keep learning and improving your cybersecurity knowledge.");
                }
                else
                {
                    BotMessage("You may need more cybersecurity practice, " + userName + ". Keep using the chatbot to learn more.");
                }

                LogActivity("Cybersecurity Quiz Completed with score " + quizScore + "/" + quizQuestions.Count);
            }
        }

        private void HandleSentiment(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("worried") ||
                lowerInput.Contains("scared") ||
                lowerInput.Contains("nervous"))
            {
                BotMessage("It is completely understandable to feel that way. Cybersecurity can feel overwhelming sometimes.");
            }
            else if (lowerInput.Contains("curious"))
            {
                BotMessage("Curiosity is great when learning about cybersecurity.");
            }
            else if (lowerInput.Contains("frustrated") ||
                     lowerInput.Contains("angry"))
            {
                BotMessage("I understand your frustration. Let me help you step by step.");
            }
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendButton_Click(sender, e);
            }
        }

        private void BotMessage(string message)
        {
            WelcomePanel.Visibility = Visibility.Collapsed;

            string time = DateTime.Now.ToString("HH:mm");
            ChatDisplay.AppendText("[" + time + "] Bot: " + message + "\n\n");

            ChatDisplay.ScrollToEnd();
        }

        private void LogActivity(string activity)
        {
            string time = DateTime.Now.ToString("HH:mm");
            activityLog.Add("[" + time + "] " + activity);
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleInput.Text.Trim();
            string description = TaskDescriptionInput.Text.Trim();
            string reminder = TaskReminderInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            string task = "[PENDING] " + title;

            if (!string.IsNullOrWhiteSpace(description))
            {
                task += " | " + description;
            }

            if (!string.IsNullOrWhiteSpace(reminder))
            {
                task += " | Reminder: " + reminder;
            }

            tasks.Add(task);
            TaskListBox.Items.Add(task);

            LogActivity("Task Added: " + title);

            if (!string.IsNullOrWhiteSpace(reminder))
            {
                BotMessage("Task added successfully. Reminder set for: " + reminder);
            }
            else
            {
                BotMessage("Task added successfully. No reminder was set.");
            }

            TaskTitleInput.Clear();
            TaskDescriptionInput.Clear();
            TaskReminderInput.Clear();
        }

        private void CompleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to mark as complete.");
                return;
            }

            int index = TaskListBox.SelectedIndex;

            string selectedTask = TaskListBox.SelectedItem.ToString();

            string completedTask = selectedTask.Replace("[PENDING]", "[COMPLETED]");

            TaskListBox.Items[index] = completedTask;
            tasks[index] = completedTask;

            LogActivity("Task Completed: " + selectedTask);

            BotMessage("Task marked as completed.");
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            int index = TaskListBox.SelectedIndex;

            string deletedTask = TaskListBox.SelectedItem.ToString();

            LogActivity("Task Deleted: " + deletedTask);

            TaskListBox.Items.RemoveAt(index);
            tasks.RemoveAt(index);

            BotMessage("Task deleted successfully.");
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav.wav");
                player.Play();
            }
            catch
            {
                string time = DateTime.Now.ToString("HH:mm");
                ChatDisplay.AppendText("[" + time + "] Bot: Voice greeting could not play.\n\n");
            }
        }
    }

    public class QuizQuestion
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string CorrectAnswer { get; set; }

        public QuizQuestion(string question, string optionA, string optionB, string optionC, string correctAnswer)
        {
            Question = question;
            OptionA = optionA;
            OptionB = optionB;
            OptionC = optionC;
            CorrectAnswer = correctAnswer;
        }
    }
}

