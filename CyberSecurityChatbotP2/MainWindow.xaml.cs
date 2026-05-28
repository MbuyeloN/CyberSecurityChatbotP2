using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;

namespace CyberSecurityChatbotP2
{
    public partial class MainWindow : Window
    {
        Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        Random random = new Random();

        string userName = "";
        string favouriteTopic = "";

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

            ChatDisplay.AppendText("You: " + input + "\n\n");
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
                BotMessage("Type 'exit', 'quit', or 'bye' to close the chatbot.");

                return;
            }

            HandleSentiment(input);

            bool found = false;

            if (lowerInput.Contains("how are you"))
            {
                BotMessage("I am doing well, " + userName + ". Thank you for asking. I am ready to help you stay safe online.");
                found = true;
            }
            else if (lowerInput.Contains("what can you do"))
            {
                BotMessage("I can answer questions about password safety, phishing, privacy, malware, scams, and two-factor authentication.");
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

        private void BotMessage(string message)
        {
            ChatDisplay.AppendText("Bot: " + message + "\n\n");
            ChatDisplay.ScrollToEnd();
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch
            {
                BotMessage("Voice greeting could not play.");
            }
        }
    }
}

