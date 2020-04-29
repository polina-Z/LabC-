using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.StartProgram();

        }

        void StartProgram()
        {
            ModelOfGame modelGame = new ModelOfGame(4);
            modelGame.StartGame();
            while(true)
            {
                Show(modelGame);
                switch(Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:  
                        modelGame.LeftButtonPressed();  
                        break;
                    case ConsoleKey.RightArrow: 
                        modelGame.RightButtonPressed(); 
                        break;
                    case ConsoleKey.UpArrow:    
                        modelGame.UpButtonPressed();    
                        break;
                    case ConsoleKey.DownArrow: 
                        modelGame.DownButtonPressed();  break;
                    case ConsoleKey.Enter: modelGame.StartGame(); 
                        break;
                    case ConsoleKey.Escape:     
                        return;
                }
            }
        }

        void Show(ModelOfGame modelGame)
        {
            for(int y = 0; y < modelGame.SizeOfMap; y++)
                for (int x = 0; x < modelGame.SizeOfMap; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    int number = modelGame.GetСoordinatesMap(x, y);
                    Console.Write(number == 0 ? ".  ": number.ToString() + "  ");
                }
            Console.WriteLine();
            if (modelGame.IsGameOver())
            {
                Console.WriteLine("\n\nGame Over ");
            }
            else Console.WriteLine("\n\nStill play");
            Console.WriteLine("\nPress \"Enter\" to start a new game.");
            Console.WriteLine("Press \"Escape\" to finish the game.");
        }
    }
}