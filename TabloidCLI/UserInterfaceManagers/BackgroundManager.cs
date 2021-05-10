using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.UserInterfaceManagers
{
    public class BackgroundManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;


        public BackgroundManager(IUserInterfaceManager parentUI)
        {
            _parentUI = parentUI;
        }
        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Background Manager Menu");
            Console.WriteLine(" 1) Change Background Color");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ChangeBackground();
                    return this;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;

            }
            void ChangeBackground()
            {
                ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

                int loopCounter = 1;
                ConsoleColor currentBackground = Console.BackgroundColor;
                string currentForeground = Console.ForegroundColor.ToString();
                foreach (var color in colors)
                {
                    Console.WriteLine($"{loopCounter} {color}");
                    loopCounter++;

                }
                Console.WriteLine("Change background color");
                string colorChoice = Console.ReadLine();
                switch (colorChoice)
                {
                    case "1":
                        if (currentForeground == "Black")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            break;
                        }
                    case "2":
                        if (currentForeground == "DarkBlue")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Clear();
                            break;
                        }
                    case "3":
                        if (currentForeground == "DarkGreen")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Clear();
                            break;
                        }
                    case "4":
                        if (currentForeground == "DarkCyan")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Clear();
                            break;
                        }
                    case "5":
                        if (currentForeground == "DarkRed")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Clear();
                            break;
                        }
                    case "6":
                        if (currentForeground == "DarkMagenta")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Clear();
                            break;
                        }
                    case "7":
                        if (currentForeground == "DarkYellow")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Clear();
                            break;
                        }
                    case "8":
                        if (currentForeground == "Gray")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Clear();
                            break;
                        }
                    case "9":
                        if (currentForeground == "DarkGray")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Clear();
                            break;
                        }
                    case "10":
                        if (currentForeground == "Blue")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Clear();
                            break;
                        }
                    case "11":
                        if (currentForeground == "Green")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Clear();
                            break;
                        }
                    case "12":
                        if (currentForeground == "Cyan")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Clear();
                            break;
                        }
                    case "13":
                        if (currentForeground == "Red")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            break;
                        }
                    case "14":
                        if (currentForeground == "Magenta")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Clear();
                            break;
                        }
                    case "15":
                        if (currentForeground == "Yellow")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Clear();
                            break;
                        }
                    case "16":
                        if (currentForeground == "White")
                        {
                            Console.WriteLine("Setting The Background Color The Same As The Text Color Is Not A Good Idea");
                            break;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            break;
                        }
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
        }
        // Get an array with the values of ConsoleColor enumeration members.
        //ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
        //// Save the current background.

        //Console.WriteLine();


        //// Restore the original console colors.
        //Console.ResetColor();
        //Console.WriteLine("\nOriginal colors restored...");
    } 
}
