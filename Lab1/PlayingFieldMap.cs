using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class PlayingFieldMap
    {
        int[,] MapOfPlayingField;
        public int SizeOfMap { get; private set; }

        public PlayingFieldMap(int SizeOfMap)
        {
            this.SizeOfMap = SizeOfMap;
            MapOfPlayingField = new int[SizeOfMap, SizeOfMap];
        }
        
        public int GetСoordinates(int x, int y)
        {
            if (OnMap(x, y))
            {
                return MapOfPlayingField[x, y];
            }
            return -1;
        }

        public void SetNumberByCoordinates(int x, int y, int number)
        {
            if (OnMap(x, y))
            {
                MapOfPlayingField[x, y] = number;
            }
        }

        public bool OnMap(int x, int y)
        {
            return x >= 0 && x < SizeOfMap &&
                   y >= 0 && y < SizeOfMap;
        }
    }
}
