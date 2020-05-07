using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StudentOfCertainSpecialty : Student, IAveragable, IEquatable<StudentOfCertainSpecialty>, ICloneable
    {
        private string mSpeciality;
        private int mGroupNumber;
        private int[] mProgramming;
        private int[] mLogic;
        private int[] mMathematicalLogic;
        private string mWardenOfGroup;

        public StudentOfCertainSpecialty(string speciality, int groupNumber, int[] programming, int[] logic, int[] mathematicalLogic,
                                         string wardenOfGroup, int[] math, int[] physics, int[] philosophy, int[] politicalScience, int[] history, 
                                         int[] belarusianLanguage, int year, string educationalInstitutionName, int age, int height, 
                                         int weight, GenderOfPeople genderOfPeople, string surname, string name, 
                                         string patronymic = "") : base(math, physics, philosophy, politicalScience, history, belarusianLanguage, 
                                         year, educationalInstitutionName, age, height, weight, genderOfPeople, surname, name, patronymic)
        {
            this.mSpeciality = speciality;
            this.mGroupNumber = groupNumber;
            this.mProgramming = programming;
            this.mLogic = logic;
            this.mMathematicalLogic = mathematicalLogic;
            this.mWardenOfGroup = wardenOfGroup;
        }

        public float CalculateAverage()
        {
            const int numberOfAdditionalSubjects = 3;
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
            averageMarkInAllSubjects = DoAverage(mProgramming) + DoAverage(mLogic) + DoAverage(mMathematicalLogic);
            averageMarkInAllSubjects /= (averageMark.Length + numberOfAdditionalSubjects);
            this.averageMarkInAllSubjects = averageMarkInAllSubjects;
            return averageMarkInAllSubjects;
        }

        public override void ShowInformation()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Surname: {surname}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Patronymic: {patronymic}");
            Console.WriteLine($"Gender of People: {genderOfPeople}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Educatonal Institute: {educationalInstitutionName}");
            Console.WriteLine($"Student ID number: {studentIdNumber}");
            Console.WriteLine($"Admission year: {yearOfAdmissionHigherEducation}");
            Console.WriteLine($"Speciality: {mSpeciality}");
            Console.WriteLine($"Group number: {mGroupNumber}");
            Console.WriteLine($"Warden of the group: {mWardenOfGroup}");
            Console.Write("Math grades:");
            for (int i = 0; i < marks.math.Length; i++)
            {
                Console.Write(" " + marks.math[i]); 
            }
            Console.Write("\nPhysics grades:");
            for (int i = 0; i < marks.physics.Length; i++)
            {
                Console.Write(" " + marks.physics[i]);
            }
            Console.Write("\nPhilosophy grades:");
            for (int i = 0; i < marks.philosophy.Length; i++)
            {
                Console.Write(" " + marks.philosophy[i]);
            }
            Console.Write("\nPolitical Science grades:");
            for (int i = 0; i < marks.politicalScience.Length; i++)
            {
                Console.Write(" " + marks.politicalScience[i]);
            }
            Console.Write("\nHistory grades:");
            for (int i = 0; i < marks.history.Length; i++)
            {
                Console.Write(" " + marks.history[i]);
            }
            Console.Write("\nBelarusian Language grades:");
            for (int i = 0; i < marks.belarusianLanguage.Length; i++)
            {
                Console.Write(" " + marks.belarusianLanguage[i]);
            }
            Console.Write("\nProgramming grades:");
            for (int i = 0; i < mProgramming.Length; i++)
            {
                Console.Write(" " + mProgramming[i]);
            }
            Console.Write("\nLogic grades:");
            for (int i = 0; i < mLogic.Length; i++)
            {
                Console.Write(" " + mLogic[i]);
            }
            Console.Write("\nMathematical logic grades:");
            for (int i = 0; i < mLogic.Length; i++)
            {
                Console.Write(" " + mMathematicalLogic[i]);
            }
            Console.WriteLine($"\nGrade point average: {averageMarkInAllSubjects}");
            switch (academicPerformance)
            {
                case Level.Excellent:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Level.High:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Level.Middle:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case Level.Low:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine($"The student has {academicPerformance} level");
            Console.WriteLine('\n');
            Console.ResetColor();
        }

        public bool Equals(StudentOfCertainSpecialty other)
        {
            if (other == null)
            {
                return false;
            }
            if (this.averageMarkInAllSubjects == other.averageMarkInAllSubjects)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object Clone()
        {
            return (StudentOfCertainSpecialty)this.MemberwiseClone();
        }
    }
}
