using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    struct Mark
    {
        public int[] math;
        public int[] physics;
        public int[] philosophy;
        public int[] politicalScience;
        public int[] history;
        public int[] belarusianLanguage;
        public Mark(int[] math, int[] physics, int[] philosophy, int[] politicalScience, int[] history, int[] belarusianLanguage)
        {
            this.math = math;
            this.physics = physics;
            this.philosophy = philosophy;
            this.politicalScience = politicalScience;
            this.history = history;
            this.belarusianLanguage = belarusianLanguage;
        }         
    }
}
