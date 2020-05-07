using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IAveragable
    {
        public float DoAverage();

        public Level DetermineAcademicPerformance(float averageMarkInAllSubjects);
    }
}
