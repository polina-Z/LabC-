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

        public Human(string age, string height, string weight, GenderOfPeople genderOfPeople, string surname, string name, string patronymic = "")
        {
            Age = Int32.TryParse(age, out this.age)? Int32.Parse(age) : 0;
            Height = Int32.TryParse(height, out this.height) ? Int32.Parse(height) : 0;
            Weight = Int32.TryParse(weight, out this.weight) ? Int32.Parse(weight) : 0;
            this.id = SetId();
            this.genderOfPeople = genderOfPeople;
            this.surname = СheckEnglishLetter(surname)? surname : "No information";
            this.name = СheckEnglishLetter(name) ? name : "No information";
            this.patronymic = (patronymic == "") ? "No information" : (СheckEnglishLetter(patronymic) ? patronymic : "No information");
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
                if (value < 0)
                {
                    Console.WriteLine("Height must be  be greater than or equal to 0\n");
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
