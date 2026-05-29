using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ergoSumPOE2
{
    class userName
    {// start of class
        public string submit_name(TextBox user_name, ListView chats)
        {
            string filename = "user_names.txt";
            string name = user_name.Text.Trim();

            // ── RULE 1: Not empty ──────────────────────────────────────
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a username.", "No Name Entered",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return string.Empty;
            }

            // ── RULE 2: Min 3, Max 20 characters ──────────────────────
            if (name.Length < 3 || name.Length > 20)
            {
                MessageBox.Show("Username must be between 3 and 20 characters.",
                    "Invalid Username", MessageBoxButton.OK, MessageBoxImage.Warning);
                return string.Empty;
            }

            // ── RULE 3: Letters and numbers only (no spaces/symbols) ──
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username can only contain letters, numbers, and underscores.",
                    "Invalid Username", MessageBoxButton.OK, MessageBoxImage.Warning);
                return string.Empty;
            }

            // ── RULE 4: Cannot start with a number ────────────────────
            if (char.IsDigit(name[0]))
            {
                MessageBox.Show("Username cannot start with a number.",
                    "Invalid Username", MessageBoxButton.OK, MessageBoxImage.Warning);
                return string.Empty;
            }

            try
            {
                // Auto-create file if it doesn't exist
                if (!File.Exists(filename))
                    File.AppendAllText(filename, "auto_create\n");

                bool found = check_Username(name);

                if (!found)
                {
                    File.AppendAllText(filename, name + "\n");
                    MessageBox.Show("Welcome, " + name + "! 👋 Let's get started.",
                        "Welcome!", MessageBoxButton.OK, MessageBoxImage.Information);
                    error_method("ChatBot", "Hey " + name + ", welcome! Ask me anything about cybersecurity.", chats);
                }
                else
                {
                    MessageBox.Show("Welcome backkk, " + name + "! 🎉 Great to see you again!",
                        "Welcome Back!", MessageBoxButton.OK, MessageBoxImage.Information);
                    error_method("ChatBot", "Hey " + name + ", welcome back! How can I help you today?", chats);
                }

                return name;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Could not access user file: " + ex.Message,
                    "File Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return string.Empty;
            }
        }



        //==========================================================

        //method to check name of the user

        private bool check_Username(string name)
        {
            string filename = "user_names.txt";
            bool found_name = false;
            string[] names = File.ReadAllLines(filename);
            foreach (string name_found in names)
            {
                if (name_found.ToLower() == name.ToLower())
                {
                    found_name = true;
                }
            }
            return found_name;
        }


        //error method
        private void error_method(string name, string message, ListView chats)
        {//star of error mehtod

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

        }//end of error method


    }// end of class
}