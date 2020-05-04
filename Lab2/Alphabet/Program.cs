using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString;
            string alphabet = "abcdefghijklmnopqrstuvwxyz ";
            string stringOfVowels = "aeiouy";
            int numberOfVowels = 6;
            do
            {
                Console.Write("Please, enter the line you want to change:\n");
                myString = Console.ReadLine();
                myString.ToLower();
            } 
            while (!СheckEnglishLetter(myString, alphabet));
            System.Text.StringBuilder myStringBuilder = new System.Text.StringBuilder(myString);

            for (int i = 0; i < myStringBuilder.Length; i++)
            {
                for (int j = 0; j < numberOfVowels; j++)
                {
                    if (myStringBuilder[i] == stringOfVowels[j])
                    {
                        if (i + 1 < myStringBuilder.Length)
                        {
                            myStringBuilder = ChangeLettersInString(myStringBuilder, i + 1, alphabet);
                            break;  
                        }
                    }
                }
            }
            Console.WriteLine("Modified string:");
            Console.WriteLine(myStringBuilder);
        }

        static System.Text.StringBuilder ChangeLettersInString(System.Text.StringBuilder myStringBuilder, int i, string alphabet)
        {
            int indexOfReplacedLetter = alphabet.IndexOf(myStringBuilder[i]);
            if (myStringBuilder[i] != 'z')
            {
                myStringBuilder[i] = alphabet[indexOfReplacedLetter + 1];
            }
            else
            {
                myStringBuilder[i] = 'a';
            }
            return myStringBuilder;
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
    }
}
