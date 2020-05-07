using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp1
{
    class Human
    {
        protected int id;
        protected GenderOfPeople genderOfPeople;
        protected string surname;
        protected string name;
        protected string patronymic;
        protected int age;
        protected int height;
        protected int weight;

        public Human(int age, int height, int weight, GenderOfPeople genderOfPeople, string surname, string name, string patronymic = "")
        {
            Age = age;
            Height = height;
            Weight = weight;
            this.id = SetId();
            this.genderOfPeople = genderOfPeople;
            this.surname = surname;
            this.name = name;
            this.patronymic = (patronymic == "")? "No information" : patronymic;
        }

        public int Age
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Age must be greater than or equal to 0\n");
                }
                else
                {
                    age = value;
                }
            }
            get { return age; }
        }

        public int Height
        {
            set
            {
                if (value < 20)
                {
                    Console.WriteLine("Height should be more than 20\n");
                }
                else
                {
                    height = value;
                }
            }
            get { return height; }
        }

        public int Weight
        {
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Weight must be greater than or equal to 0\n");
                }
                else
                {
                    weight = value;
                }
            }
            get { return weight; }
        }

        protected static bool СheckEnglishLetter(string myString)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
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
        
        protected static int SetId()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999);
        }

        public virtual void ShowInformation()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Patronymic: {patronymic}");
            Console.WriteLine($"Gender of People: {genderOfPeople}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Weight: {Weight}");
        }
    }
}
