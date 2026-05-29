using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ergoSumPOE2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //creating an instance for the class Array
        ArrayList reply = new ArrayList();
        ArrayList ignore = new ArrayList();
        userName check_name = new userName();

        // working variables
        string username = string.Empty;
        string pre_question = string.Empty;
        int counting = 0;

        public MainWindow()
        {
            InitializeComponent();

            //instance for voiceGreeting class to play the greeting sound when the app starts
            new respond(reply, ignore) { };
            playVoiceGreeting greet = new playVoiceGreeting();
            greet.greet();
        }


        //=========================================================================================



        //method to handle the proceed button click and transition to username input
        private void proceed(object sender, RoutedEventArgs e)
        {
            //Hide home page grid and set Username grid visible
            home_grid.Visibility = Visibility.Hidden;
            username_grid.Visibility = Visibility.Visible;
        }// end of method 

        //=========================================================================================



        //method to handle the send button click and process the user's question
        private void send(object sender, RoutedEventArgs e)
        {
            string rawQuestion = question.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(rawQuestion))
            {
                error_method("Ergo-ChatBot", "Please enter a question.");
                return;
            }

            string questions = RemoveSpecialCharacters(rawQuestion);
            error_method(username, rawQuestion);
            auto_show_interest();
            ai_check(questions);
        }// end of method










        //submit name  event handler
        private void submit_name(object sender, RoutedEventArgs e)
        {

            //check the user name from memory recall
            string result = check_name.submit_name(usernames_input, chats);
            if (!string.IsNullOrWhiteSpace(result))
            {
                username = result;
                username_grid.Visibility = Visibility.Hidden;
                chat_grid.Visibility = Visibility.Visible;

            }
        } // end of method


        //=========================================================================================

        //send event handler
        private void sendName(object sender, RoutedEventArgs e)
        {
            // Get the question from the design and sanitize it
            string rawQuestion = question.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(rawQuestion))
            {
                error_method("" +
                    "Ergo-ChatBot", "Please enter a question.");
                return;
            }

            // Remove special characters and clean the question
            string questions = RemoveSpecialCharacters(rawQuestion);

            // Show what the user typed 
            error_method(username, rawQuestion);


            //ai chats and auto_show_interest
            auto_show_interest();
            ai_check(questions);
        }

        //end for the username submit


        //=============================================================================================
        //start of ai_chat method
        private void ai_check(string questions)
        {
            //check user input
            if (string.IsNullOrWhiteSpace(questions))
            {
                error_method("Ergo-ChatBot", "Please enter a valid question.");
                question.Clear();
                return;
            }

            // split into words
            string[] words = questions.ToLower().Split(
                new char[] { ' ', ',', '.', '?', '!', ';', ':' },
                StringSplitOptions.RemoveEmptyEntries);

            bool found = false;
            string message = string.Empty;
            Random indexer = new Random();
            List<string> per_word = new List<string>();
            List<string> answers_found = new List<string>();

            foreach (string word in words)
            {
                // skip short or ignored words
                if (word.Length < 3 || ignore.Contains(word.ToLower()))
                    continue;

                per_word.Clear();

                // interests handling
                if (word.Contains("interested"))
                {
                    string store_interests = string.Empty;
                    bool found_interest = false;
                    HashSet<string> currentInterests = new HashSet<string>();

                    foreach (string interest in words)
                    {
                        string clean = interest.ToLower().Trim();
                        clean = Regex.Replace(clean, @"[^a-zA-Z0-9\s]", "");
                        if (!ignore.Contains(clean) && clean != "interested" && clean != "and" && clean != "in" && clean.Length >= 3)
                        {
                            found_interest = true;
                            currentInterests.Add(clean);
                        }
                    }

                    store_interests = string.Join(", ", currentInterests);

                    if (found_interest && !string.IsNullOrWhiteSpace(store_interests))
                    {
                        string filename = "interested_topic.txt";
                        bool userFound = false;

                        if (File.Exists(filename))
                        {
                            string[] lines = File.ReadAllLines(filename);
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (lines[i].StartsWith(username))
                                {
                                    userFound = true;
                                    string existing = lines[i].Replace(username + " interested in:", "").ToLower();
                                    HashSet<string> existingSet = new HashSet<string>(
                                        existing.Split(',').Select(x => x.Trim()).Where(x => x != ""));
                                    foreach (string item in currentInterests)
                                        existingSet.Add(item);
                                    string finalList = string.Join(", ", existingSet);
                                    lines[i] = username + " interested in: " + finalList;
                                    File.WriteAllLines(filename, lines);
                                    message += "Great, I added " + store_interests + " to your interests! ";
                                    break;
                                }
                            }
                        }

                        if (!userFound)
                        {
                            File.AppendAllText(filename, username + " interested in: " + store_interests + "\n");
                            message += "Great, I'll remember you are interested in " + store_interests + "! ";
                        }
                    }
                    else
                    {
                        message += "Please specify what you're interested in (e.g., 'I am interested in cybersecurity'). ";
                    }
                }

                // search answers — KEY FIX: match keyword at start of answer string
                bool wordFound = false;
                foreach (string answer in reply)
                {
                    string answerLower = answer.ToLower();
                    string keyword = answerLower.Split(' ')[0]; // first word is the keyword tag

                    // match if the keyword starts with the word or word starts with keyword
                    if (keyword == word || keyword.StartsWith(word) || word.StartsWith(keyword))
                    {
                        wordFound = true;
                        per_word.Add(answer);
                    }
                }

                if (wordFound && per_word.Count > 0)
                {
                    found = true;
                    int indexing = indexer.Next(0, per_word.Count);
                    answers_found.Add(per_word[indexing]);
                }
            }

            // display responses
            if (found && answers_found.Count > 0)
            {
                answers_found = answers_found.Distinct().ToList();
                foreach (string per_answer in answers_found)
                {
                    // strip the keyword tag (first word) before showing
                    string cleaned = per_answer.Substring(per_answer.IndexOf(' ') + 1);
                    message += cleaned + "\n";
                }
                error_method("ChatBot", message.Trim());
            }
            else
            {
                string[] fallbackMessages = {
                    "I'm sorry, I don't understand that. Could you rephrase?",
                    "I didn't quite get that. Try asking about cybersecurity topics.",
                    "Hmm, I'm not sure how to respond. Can you ask something else?",
                    "I couldn't find an answer. Please ask about passwords, phishing, vpn, or firewalls.",
                    "My apologies, I don't have information on that topic yet."
                };
                Random random = new Random();
                error_method("ChatBot", fallbackMessages[random.Next(fallbackMessages.Length)]);
            }

            question.Clear();
        }// end of ai_chat method   


        //=============================================================================================



        //method to remove special characters
        private static string RemoveSpecialCharacters(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            StringBuilder sanitized = new StringBuilder();

            foreach (char c in input)
            {
                // Keep letters, numbers, spaces, and basic punctuation
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '\'' || c == '-')
                {
                    sanitized.Append(c);
                }
                else
                {
                    // Replace other special characters with space
                    sanitized.Append(' ');
                }
            }

            // Clean up extra spaces and trim
            string result = sanitized.ToString();
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\s+", " ").Trim();

            return result;
        }
        //end of method to remove special characters


        //=============================================================================================


        //method count to show interests randomly
        private void auto_show_interest()
        {
            //check if three times
            if (counting == 3)
            {
                //read the user's interests from file
                string filename = "interested_topic.txt";

                if (File.Exists(filename))
                {
                    string[] lines = File.ReadAllLines(filename);

                    //find the user's line
                    foreach (string line in lines)
                    {
                        if (line.StartsWith(username))
                        {
                            //get the interests part
                            int colonIndex = line.IndexOf("interested in:");
                            if (colonIndex >= 0)
                            {
                                string interests = line.Substring(colonIndex + 14).Trim();

                                //show reminder of interests
                                error_method("ChatBot", "Just a reminder, you are interested in " + interests + " and ");
                                ai_check(interests);
                                break;
                            }
                        }
                    }
                }

                //reset counting
                counting = 0;
            }
            else
            {
                //incrementing
                counting += 1;
            }
        }
        //end of count interest method

        //=============================================================================================




        // Updated error method with better formatting
        private void error_method(string name, string message)
        {
            // Create a border for chats
            Border messageBorder = new Border
            {
                Margin = new Thickness(0, 2, 0, 2),
                Padding = new Thickness(5, 3, 5, 3),
                CornerRadius = new CornerRadius(5)
            };

            // Set different background for user vs bot
            if (name.ToLower().Contains("chatbot") || name.ToLower().Contains("chat"))
            {// Light blue
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(240, 248, 255));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(173, 216, 230));
            }
            else
            {    // Light gray
                messageBorder.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
                messageBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(211, 211, 211));
            }
            messageBorder.BorderThickness = new Thickness(1);

            TextBlock messageText = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(2)
            };

            // Set color based on sender
            Brush nameColor = (name.ToLower().Contains("chatbot") || name.ToLower().Contains("chat")) ?
                              Brushes.DarkBlue : Brushes.DarkGreen;

            Brush messageColor = Brushes.Black;

            messageText.Inlines.Add(new Run
            {
                Text = name + ": ",
                Foreground = nameColor,
                FontWeight = FontWeights.Bold
            });

            messageText.Inlines.Add(new Run
            {
                Text = message,
                Foreground = messageColor
            });

            messageBorder.Child = messageText;
            chats.Items.Add(messageBorder);

            chats.ScrollIntoView(chats.Items[chats.Items.Count - 1]);
        }//end of error method



    }

}