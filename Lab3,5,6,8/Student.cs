using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    abstract class Student : Human
    {
        protected Mark marks;
        protected int yearOfAdmissionHigherEducation;
        protected string educationalInstitutionName;
        protected int studentIdNumber;
        protected Level academicPerformance;
        public delegate float DisciplineDelegate(int[] array);
        protected Dictionary<string, DisciplineDelegate> _subject;
        public delegate void showInformation(string OperationName);
        protected float[] averageMark = new float[6];
        protected float averageMarkInAllSubjects;
        public event showInformation Showing =  (OperationName) => { };

        public Student(int[] math, int[] physics, int[] philosophy, int[] politicalScience, int[] history, int[] belarusianLanguage,
                       string year, string educationalInstitutionName, string age, string height, string weight,GenderOfPeople genderOfPeople, 
                       string surname, string name, string patronymic = "") : base(age, height, weight, genderOfPeople, surname, 
                       name, patronymic)
        {
            _subject =
                new Dictionary<string, DisciplineDelegate>
                {
                   { "Math", this.DoAverage },
                    { "Physics", this.DoAverage },
                    { "Philosophy", this.DoAverageOfRandomElements },
                    { "PoliticalScience", this.DoAverageOfRandomElements},
                    { "History", this.DoAverageOfCertainElements},
                    { "BelarusianLanguage",this.DoAverageOfCertainElements },
                };
            Showing += Display;
            marks = new Mark(math, physics, philosophy, politicalScience, history, belarusianLanguage);
            this.yearOfAdmissionHigherEducation = Int32.TryParse(year, out this.yearOfAdmissionHigherEducation) ? Int32.Parse(year) : 0;
            this.educationalInstitutionName = СheckEnglishLetter(educationalInstitutionName) ? educationalInstitutionName : "No information";
            this.averageMarkInAllSubjects = DoAverage();
            this.academicPerformance = DetermineAcademicPerformance(averageMarkInAllSubjects);
            this.studentIdNumber = SetId();
        }

        protected float DoAverage(int[] array)
        {
            float averageRating = 0;
            for (int i = 0; i < array.Length; i++)
            {
                averageRating += array[i];
            }
            averageRating /= array.Length;
            return averageRating;
        }

        protected float DoAverageOfCertainElements(int[] array)
        {
            float averageRating = 0;
            int counter = 0;
            for (int i = 0; i < array.Length; i += 2)
            {
                counter++;
                averageRating += array[i];
            }
            averageRating /= counter;
            return averageRating;
        }

        protected float DoAverageOfRandomElements(int[] array)
        {
            float averageRating = 0;
            int counter = 0;
            if (array.Length == 1)
            {
                averageRating = array[0];
            }
            else
            {
                for (int i = 0; i < array.Length / 2; i++)
                {
                    counter++;
                    var random = new Random();
                    averageRating += array[random.Next(0, array.Length - 1)];
                }
                averageRating /= counter;
            }
            return averageRating;
        }

        protected float DoOperation(string operationName, int[] array)
        {
            try
            {
                 return _subject[operationName](array);
            }
            catch (Exception ex)
            {
                Showing(ex.ToString());
                return 0;
            }
        }

        public float DoAverage()
        {
            float averageMarkInAllSubjects = 0;
            averageMark[0] = DoOperation("Math", marks.math);
            averageMark[1] = DoOperation("Physics", marks.physics);
            averageMark[2] = DoOperation("Philosophy", marks.philosophy);
            averageMark[3] = DoOperation("PoliticalScience", marks.politicalScience);
            averageMark[4] = DoOperation("History", marks.history);
            averageMark[5] = DoOperation("BelarusianLanguage", marks.belarusianLanguage);

            for (int i = 0; i < averageMark.Length; i++)
            {
                averageMarkInAllSubjects += averageMark[i];
            }
            averageMarkInAllSubjects /= averageMark.Length;
            return averageMarkInAllSubjects;
        }

        public static void Display(string myString)
        {   
            Console.WriteLine(myString);
        }

        public Level DetermineAcademicPerformance(float averageMarkInAllSubjects)
        {
            if(averageMarkInAllSubjects <= 10 && averageMarkInAllSubjects >=9)
            {
                return Level.Excellent;
            }
            else if(averageMarkInAllSubjects < 9 && averageMarkInAllSubjects >= 7)
            {
                return Level.High;
            }
            else if (averageMarkInAllSubjects < 7 && averageMarkInAllSubjects >= 5)
            {
                return Level.Middle;
            }
            else 
            {
                return Level.Low;
            }
        }
    };   
}
