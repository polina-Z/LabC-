using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentOfCertainSpecialty student1 = new StudentOfCertainSpecialty("CS&PT", "953503", new int[] { 10, 10, 10 }, 
            new int[] { 9, 8 }, new int[] { 10, 10, 10, 10, 10 }, "Victoria", new int[] { 10, 9, 10, 9 }, new int[] { 10, 9, 10 }, 
            new int[] { 9, 8, 9, 9 }, new int[] { 10, 9, 10 }, new int[] { 9, 9, 10, 9 }, new int[] { 10, 9 }, "2019", "BSUIR", "18", "172", "55",
            GenderOfPeople.Woman, "Zorko" , "Polina", "Aleksandrovna");
            student1.ShowInformation();

            StudentOfCertainSpecialty student2 = new StudentOfCertainSpecialty("CS&PT", "853506", new int[] { 6,5,8 },
            new int[] { 5,7 }, new int[] { 4, 6, 5 }, "Victoria", new int[] { 8, 7, 6 }, new int[] { 8, 8, 7 },
            new int[] { 5, 6, 5 }, new int[] { 7, 7, 7 }, new int[] { 5, 8, 6 }, new int[] { 5, 5 }, "2018", "BSUIR", "19", "183", "70",
            GenderOfPeople.Man, "Cook", "Harry ");
            student2.ShowInformation();
        }
    }
}
