using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1 
{
    class ModelOfGame
    {
        private PlayingFieldMap mMapOfPlayingField;

        static Random random = new Random();

        private bool mIsGameOver;
        private bool mIsMoved;
        public int SizeOfMap 
        { 
            get { return mMapOfPlayingField.SizeOfMap; }
        }

        public ModelOfGame(int SizeOfMap)
        {
            mMapOfPlayingField = new PlayingFieldMap(SizeOfMap);
        }

        public void StartGame()
        {
            mIsGameOver = false;
            for (int x = 0; x < SizeOfMap; x++)
                for (int y = 0; y < SizeOfMap; y++)
                    mMapOfPlayingField.SetNumberByCoordinates(x, y, 0);
            AddRandomNumber();
            AddRandomNumber();
        }

        private void AddRandomNumber()
        {
            if (mIsGameOver)
            {
                return;
            }
            for(int j = 0; j < 100; j++)
            {
                int x = random.Next(0, mMapOfPlayingField.SizeOfMap);
                int y = random.Next(0, mMapOfPlayingField.SizeOfMap);
                if (mMapOfPlayingField.GetСoordinates(x, y) == 0)
                {
                    mMapOfPlayingField.SetNumberByCoordinates(x, y, random.Next(1, 3) * 2);
                    return;
                }
            }
        }

        void MoveNumber(int x, int y, int stepX, int stepY)
        {
            if(mMapOfPlayingField.GetСoordinates(x, y) > 0)
                while(mMapOfPlayingField.GetСoordinates(x + stepX, y+ stepY) == 0)
                {
                    mMapOfPlayingField.SetNumberByCoordinates(x + stepX, y + stepY, mMapOfPlayingField.GetСoordinates(x, y));
                    mMapOfPlayingField.SetNumberByCoordinates(x, y, 0);
                    x += stepX;
                    y += stepY;
                    mIsMoved = true;
                }
        }
      
        void JoinTheSameNumbers(int x, int y, int stepX, int stepY)
        {
            if (mMapOfPlayingField.GetСoordinates(x, y) > 0)
                if(mMapOfPlayingField.GetСoordinates(x + stepX, y + stepY) == mMapOfPlayingField.GetСoordinates(x, y))
                {
                    mMapOfPlayingField.SetNumberByCoordinates(x + stepX, y + stepY, mMapOfPlayingField.GetСoordinates(x, y) * 2);
                    while(mMapOfPlayingField.GetСoordinates(x - stepX, y - stepY) > 0)
                    {
                        mMapOfPlayingField.SetNumberByCoordinates(x, y, mMapOfPlayingField.GetСoordinates(x - stepX, y - stepY));
                        x -= stepX;
                        y -= stepY;
                    }
                    mMapOfPlayingField.SetNumberByCoordinates(x, y, 0);
                    mIsMoved = true;
                }
        }

        public void LeftButtonPressed()
        {
            mIsMoved = false;
            for (int y = 0; y < mMapOfPlayingField.SizeOfMap; y++)
            {
                for (int x = 1; x < mMapOfPlayingField.SizeOfMap; x++)
                    MoveNumber(x, y, -1, 0);
                for (int x = 1; x < mMapOfPlayingField.SizeOfMap; x++)
                    JoinTheSameNumbers(x, y, -1, 0);
            }
            if (mIsMoved)
            {
                AddRandomNumber();
            }
        }

        public void RightButtonPressed()
        {
            mIsMoved = false;
            for (int y = 0; y < mMapOfPlayingField.SizeOfMap; y++)
            {
                for (int x = mMapOfPlayingField.SizeOfMap - 2; x >= 0; x--)
                    MoveNumber(x, y, +1, 0);
                for (int x = mMapOfPlayingField.SizeOfMap - 2; x >= 0; x--)
                    JoinTheSameNumbers(x, y, +1, 0);
            }
            if (mIsMoved)
            {
                AddRandomNumber();
            }
        }

        public void UpButtonPressed()
        {
            mIsMoved = false;
            for (int x = 0; x < mMapOfPlayingField.SizeOfMap; x++)
            {
                for (int y = 1; y < mMapOfPlayingField.SizeOfMap; y++)
                    MoveNumber(x, y, 0, -1);
                for (int y = 1; y < mMapOfPlayingField.SizeOfMap; y++)
                    JoinTheSameNumbers(x, y, 0, -1);
            }
            if (mIsMoved)
            {
                AddRandomNumber();
            }
        }

        public void DownButtonPressed()
        {
            mIsMoved = false;
            for (int x = 0; x < mMapOfPlayingField.SizeOfMap; x++)
            {
                for (int y = mMapOfPlayingField.SizeOfMap - 2; y >= 0; y--)
                    MoveNumber(x, y, 0, +1);
                for (int y = mMapOfPlayingField.SizeOfMap - 2; y >= 0; y--)
                    JoinTheSameNumbers(x, y, 0, +1);
            }
            if (mIsMoved)
            {
                AddRandomNumber();
            }
        }

        public int GetСoordinatesMap(int x, int y)
        {
            return mMapOfPlayingField.GetСoordinates(x, y);
        }

        public bool IsGameOver()
        {
            if (mIsGameOver)
            {
                return mIsGameOver;
            }
            for (int x = 0; x < SizeOfMap; x++)
                for (int y = 0; y < SizeOfMap; y++)
                    if(mMapOfPlayingField.GetСoordinates(x, y) == 0)
                        return false;
            for (int x = 0; x < SizeOfMap; x++)
                for (int y = 0; y < SizeOfMap; y++)
                    if (mMapOfPlayingField.GetСoordinates(x, y) == mMapOfPlayingField.GetСoordinates(x + 1, y) ||
                        mMapOfPlayingField.GetСoordinates(x, y) == mMapOfPlayingField.GetСoordinates(x, y + 1))
                        return false;
            mIsGameOver = true;
            return mIsGameOver;
        }
    }
}
