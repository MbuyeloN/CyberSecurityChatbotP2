using System;
using System.Collections.Generic;
using System.Linq;
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

            if (string.IsNullOrEmpty(userName))
            {
                userName = input;
                BotMessage("Nice to meet you, " + userName + "!");
                BotMessage("You can ask me about passwords, phishing, scams, privacy, or malware.");
                return;
            }

            HandleSentiment(input);

            bool found = false;

            foreach (var item in responses)
            {
                if (input.ToLower().Contains(item.Key))
                {
                    string response =
                        item.Value[random.Next(item.Value.Count)];

                    BotMessage(response);

                    favouriteTopic = item.Key;

                    found = true;
                    break;
                }
            }

            if (input.ToLower().Contains("another")
                || input.ToLower().Contains("more")
                || input.ToLower().Contains("tell me more"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    string response =
                        responses[favouriteTopic]
                        [random.Next(responses[favouriteTopic].Count)];

                    BotMessage("Here is another tip about "
                        + favouriteTopic + ":");

                    BotMessage(response);

                    found = true;
                }
            }

            if (input.ToLower().Contains("my favourite topic"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    BotMessage("Your favourite cybersecurity topic seems to be "
                        + favouriteTopic + ".");
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
            input = input.ToLower();

            if (input.Contains("worried")
                || input.Contains("scared")
                || input.Contains("nervous"))
            {
                BotMessage("It is completely understandable to feel that way. Cybersecurity can feel overwhelming sometimes.");
            }

            else if (input.Contains("curious"))
            {
                BotMessage("Curiosity is great when learning about cybersecurity.");
            }

            else if (input.Contains("frustrated")
                || input.Contains("angry"))
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
                SoundPlayer player =
                    new SoundPlayer("greeting.wav");

                player.Play();
            }
            catch
            {
                BotMessage("Voice greeting could not play.");
            }
        }
    }
}

