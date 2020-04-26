using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1 
{
    class ModelOfGame
    {
        PlayingFieldMap mapOfPlayingField;

        static Random random = new Random();

        bool isGameOver;
        bool isMoved;
        public int sizeOfMap 
        { 
            get { return mapOfPlayingField.sizeOfMap; }
        }

        public ModelOfGame(int sizeOfMap)
        {
            mapOfPlayingField = new PlayingFieldMap(sizeOfMap);
        }

        public void StartGame()
        {
            isGameOver = false;
            for (int x = 0; x < sizeOfMap; x++)
                for (int y = 0; y < sizeOfMap; y++)
                    mapOfPlayingField.SetNumberByCoordinates(x, y, 0);
            AddRandomNumber();
            AddRandomNumber();
        }

        private void AddRandomNumber()
        {
            if (isGameOver)
            {
                return;
            }
            for(int j = 0; j < 100; j++)
            {
                int x = random.Next(0, mapOfPlayingField.sizeOfMap);
                int y = random.Next(0, mapOfPlayingField.sizeOfMap);
                if (mapOfPlayingField.GetСoordinates(x, y) == 0)
                {
                    mapOfPlayingField.SetNumberByCoordinates(x, y, random.Next(1, 3) * 2);
                    return;
                }
            }
        }

        void MoveNumber(int x, int y, int stepX, int stepY)
        {
            if(mapOfPlayingField.GetСoordinates(x, y) > 0)
                while(mapOfPlayingField.GetСoordinates(x + stepX, y+ stepY) == 0)
                {
                    mapOfPlayingField.SetNumberByCoordinates(x + stepX, y + stepY, mapOfPlayingField.GetСoordinates(x, y));
                    mapOfPlayingField.SetNumberByCoordinates(x, y, 0);
                    x += stepX;
                    y += stepY;
                    isMoved = true;
                }
        }
      
        void JoinTheSameNumbers(int x, int y, int stepX, int stepY)
        {
            if (mapOfPlayingField.GetСoordinates(x, y) > 0)
                if(mapOfPlayingField.GetСoordinates(x + stepX, y + stepY) == mapOfPlayingField.GetСoordinates(x, y))
                {
                    mapOfPlayingField.SetNumberByCoordinates(x + stepX, y + stepY, mapOfPlayingField.GetСoordinates(x, y) * 2);
                    while(mapOfPlayingField.GetСoordinates(x - stepX, y - stepY) > 0)
                    {
                        mapOfPlayingField.SetNumberByCoordinates(x, y, mapOfPlayingField.GetСoordinates(x - stepX, y - stepY));
                        x -= stepX;
                        y -= stepY;
                    }
                    mapOfPlayingField.SetNumberByCoordinates(x, y, 0);
                    isMoved = true;
                }
        }

        public void LeftButtonPressed()
        {
            isMoved = false;
            for (int y = 0; y < mapOfPlayingField.sizeOfMap; y++)
            {
                for (int x = 1; x < mapOfPlayingField.sizeOfMap; x++)
                    MoveNumber(x, y, -1, 0);
                for (int x = 1; x < mapOfPlayingField.sizeOfMap; x++)
                    JoinTheSameNumbers(x, y, -1, 0);
            }
            if (isMoved)
            {
                AddRandomNumber();
            }
        }

        public void RightButtonPressed()
        {
            isMoved = false;
            for (int y = 0; y < mapOfPlayingField.sizeOfMap; y++)
            {
                for (int x = mapOfPlayingField.sizeOfMap - 2; x >= 0; x--)
                    MoveNumber(x, y, +1, 0);
                for (int x = mapOfPlayingField.sizeOfMap - 2; x >= 0; x--)
                    JoinTheSameNumbers(x, y, +1, 0);
            }
            if (isMoved)
            {
                AddRandomNumber();
            }
        }

        public void UpButtonPressed()
        {
            isMoved = false;
            for (int x = 0; x < mapOfPlayingField.sizeOfMap; x++)
            {
                for (int y = 1; y < mapOfPlayingField.sizeOfMap; y++)
                    MoveNumber(x, y, 0, -1);
                for (int y = 1; y < mapOfPlayingField.sizeOfMap; y++)
                    JoinTheSameNumbers(x, y, 0, -1);
            }
            if (isMoved)
            {
                AddRandomNumber();
            }
        }

        public void DownButtonPressed()
        {
            isMoved = false;
            for (int x = 0; x < mapOfPlayingField.sizeOfMap; x++)
            {
                for (int y = mapOfPlayingField.sizeOfMap - 2; y >= 0; y--)
                    MoveNumber(x, y, 0, +1);
                for (int y = mapOfPlayingField.sizeOfMap - 2; y >= 0; y--)
                    JoinTheSameNumbers(x, y, 0, +1);
            }
            if (isMoved)
            {
                AddRandomNumber();
            }
        }

        public int GetСoordinatesMap(int x, int y)
        {
            return mapOfPlayingField.GetСoordinates(x, y);
        }

        public bool IsGameOver()
        {
            if (isGameOver)
            {
                return isGameOver;
            }
            for (int x = 0; x < sizeOfMap; x++)
                for (int y = 0; y < sizeOfMap; y++)
                    if(mapOfPlayingField.GetСoordinates(x, y) == 0)
                        return false;
            for (int x = 0; x < sizeOfMap; x++)
                for (int y = 0; y < sizeOfMap; y++)
                    if (mapOfPlayingField.GetСoordinates(x, y) == mapOfPlayingField.GetСoordinates(x + 1, y) ||
                        mapOfPlayingField.GetСoordinates(x, y) == mapOfPlayingField.GetСoordinates(x, y + 1))
                        return false;
            isGameOver = true;
            return isGameOver;
        }
    }
}
