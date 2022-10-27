using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var con = true;
            do
            {
                Console.WriteLine("Welcome to the password generator");
                Console.WriteLine("Would you like to create a password? yes/no");
                var ans = Console.ReadLine();
                if (!(ans.Equals("yes")) && !(ans.Equals("no"))) {
                    Console.WriteLine("Invalid answer");
                } else if (ans.Equals("yes"))
                {
                    Console.WriteLine("How long?");
                    var answer = Console.ReadLine();
                    int amount = (int)Int64.Parse(answer);
                    generatePassword(amount);
                } else if (ans.Equals("no"))
                {
                    con = false;
                }

            } while (con);

        }

        private static void generatePassword(int amount)
        {
            var con = true;
            do
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var charString = new char[amount];
                var random = new Random();
                for (int i = 0; i < charString.Length; i++)
                {
                    charString[i] = chars[random.Next(chars.Length)];
                }
                var password = new String(charString);
                Console.WriteLine("Here's generated password: {0} ;Do you like it? yes/no", password);
                var ans = Console.ReadLine();
                if (!(ans.Equals("yes")) && !(ans.Equals("no")))
                {
                    Console.WriteLine("Invalid answer");
                }
                else if (ans.Equals("yes"))
                {
                    Console.WriteLine("Then we'll save it.");
                    saveToFile(password);
                    con = false;
                }
                else if (ans.Equals("no"))
                {
                    Console.WriteLine("Noone cares");
                }
            } while (con);
            Console.ReadKey();
        }

        private static void saveToFile(string password)
        {
            try {
                string path = @"file.txt";
                string createText = password + Environment.NewLine;
                File.WriteAllText(path, createText);
                string readText = File.ReadAllText(path);
                Console.WriteLine(readText);
            } catch (Exception exception)
            {
                Console.WriteLine("We failed");
            }
            Console.ReadKey();

        }
    }
}
