using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int amountOfNumbers = 10;
            DateTime date = DateTime.Now;
            Console.WriteLine("Time now: " + date);
            Console.WriteLine("Time now: " + date.ToString("F"));
            Console.WriteLine($"It is {date.DayOfWeek} now");
            Console.WriteLine();
            int[] countingArray = new int[amountOfNumbers];
            for (int i = 0; i < amountOfNumbers; i++)
            {
                countingArray[i] = 0;
            }

            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            int timeHour = date.Hour;
            int timeMinute = date.Minute;
            int timeSecond = date.Second;

            while (year != 0)
            {
                countingArray[year % 10]++;
                year /= 10;

            }
            while (month != 0)
            {
                countingArray[month % 10]++;
                month /= 10;
            }
            while (day != 0)
            {
                countingArray[day % 10]++;
                day /= 10;
            }
            while (timeHour != 0)
            {
                countingArray[timeHour % 10]++;
                timeHour /= 10;
            }
            while (timeMinute != 0)
            {
                countingArray[timeMinute % 10]++;
                timeMinute /= 10;
            }
            while (timeSecond != 0)
            {
                countingArray[timeSecond % 10]++;
                timeSecond /= 10;
            }

            for (int i = 0; i < amountOfNumbers; i++)
            {
                Console.WriteLine(i + String.Format("{0,3}", countingArray[i]));
            }
        }
    }
}
