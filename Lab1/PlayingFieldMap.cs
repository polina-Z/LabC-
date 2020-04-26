using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class PlayingFieldMap
    {
        int[,] mapOfPlayingField;
        public int sizeOfMap { get; private set; }

        public PlayingFieldMap(int sizeOfMap)
        {
            this.sizeOfMap = sizeOfMap;
            mapOfPlayingField = new int[sizeOfMap, sizeOfMap];
        }
        
        public int GetСoordinates(int x, int y)
        {
            if (OnMap(x, y))
            {
                return mapOfPlayingField[x, y];
            }
            return -1;
        }

        public void SetNumberByCoordinates(int x, int y, int number)
        {
            if (OnMap(x, y))
            {
                mapOfPlayingField[x, y] = number;
            }
        }

        public bool OnMap(int x, int y)
        {
            return x >= 0 && x < sizeOfMap &&
                   y >= 0 && y < sizeOfMap;
        }
    }
}
