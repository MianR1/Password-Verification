/****************************************************************************
    PROGRAMME	:	Password Validation

    OUTLINE		:	This program asks the user for a password and then
                    tells the user if they have met the requirements.

    PROGRAMMER	:	Mian Rafay

 ****************************************************************************/
using System;
using System.IO;
using System.Text.RegularExpressions;
namespace RafayM_ASSN01_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Passwords";
            Console.ForegroundColor = ConsoleColor.Red;
            StreamWriter passwords = new StreamWriter("passwords.txt");
            Console.Write("    Enter Password: ");
            string pass = Console.ReadLine();
            string user_input = pass;
            while (true)
            {
                if (!new Regex("(?=.{8})").IsMatch(user_input))
                {
                    Console.Write("\n\tInvalid password length: Minimum 8 characters!");
                }

                if (!new Regex("(?=.*[0-9])").IsMatch(user_input))
                {
                    Console.Write("\n\tPassword needs at least 1 number!");
                }

                if (!new Regex("(?=.*[A-Z])").IsMatch(user_input))
                {
                    Console.Write("\n\tPassword needs at least 1 uppercase letter!");
                }

                if (!new Regex("(?=.*[^a-z A-Z 0-9 :])").IsMatch(user_input))
                {
                    Console.Write("\n\tPassword needs at least 1 special character!");
                }

                if (new Regex(" ").IsMatch(user_input))
                {
                    Console.Write("\n\tPassword should not contain spaces!");
                }

                if (new Regex("(?=.{8})(?=.*[0-9])(?=.*[A-Z])(?=.*[^a-z A-Z 0-9 :])").IsMatch(user_input) && !new Regex(" ").IsMatch(user_input))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nPassword input successful!\n\n");
                    passwords.WriteLine(pass);
                    passwords.Close();
                    Console.WriteLine("Passwords Entered: \n\n" + pass);
                    Console.ReadKey();
                    Environment.Exit(-1);
                }
                Console.Write("\n\n    Enter Password: ");
                user_input = Console.ReadLine();
                pass += "\n" + user_input;
            }            
        }
    }
}