using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maximumNumberOfLetters = 30;
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            string myString;
            var randomArray = new byte[maximumNumberOfLetters];
            var random = new Random();
            random.NextBytes(randomArray);

            do
            {
                Console.Write("Please, enter the line.\n");
                myString = Console.ReadLine();
            }
            while (!СheckEnglishLetter(myString, alphabet));

            System.Text.StringBuilder myStringBuilder = FillLineRandomLetters(myString, randomArray, maximumNumberOfLetters);
            for (int i = 0; i < myString.Length; i++)
            {
                Console.Write(String.Format("{0,-3}", myStringBuilder[i]));
                Console.Write(" ");
            }
        }

        static bool СheckEnglishLetter(string myString, string alphabet)
        {
            for (int i = 0; i < myString.Length; i++)
            {
                bool notEnglishLetter = true;
                if (alphabet.IndexOf(myString[i]) > -1)
                {
                    notEnglishLetter = false;
                }
                else
                {
                    notEnglishLetter = true;
                }

                if (notEnglishLetter)
                {
                    Console.WriteLine("------------------------------------------------------------------\n");
                    Console.WriteLine("Error. \nExplanation: incorrectly input\n");
                    Console.WriteLine("Press any key to continue\n");
                    Console.WriteLine("------------------------------------------------------------------\n");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
            }
            return true;
        }

        static System.Text.StringBuilder FillLineRandomLetters(string myString, byte[] randomArray, int maximumNumberOfLetters)
        {
            System.Text.StringBuilder myStringBuilder = new System.Text.StringBuilder("                              ");
            for (int i = 0; i < myString.Length && i < maximumNumberOfLetters; i++)
            {
                myStringBuilder[i] = myString[randomArray[i] % myString.Length];
            }
            return myStringBuilder;
        }
    }
}
