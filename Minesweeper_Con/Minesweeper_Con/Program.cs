using System;

namespace Minesweeper_Con
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gamestate = true;
            bool winstate = false;
            Mine_Engine engine = new Mine_Engine();
            while (gamestate)
            {
                Console.WriteLine(engine.Print_MainPage());
                string n = Console.ReadLine();
                switch (n)
                {
                    case "1":
                        engine.InitializeGame();
                        while (gamestate)
                        {
                            Console.Clear();
                            Console.WriteLine(engine.printBoard());
                            Console.WriteLine("Enter location as (x y):");
                            string x = Console.ReadLine();
                            int x1 = Convert.ToInt32(x.Split(" ")[0]);
                            int y1 = Convert.ToInt32(x.Split(" ")[1]);
                            if (!engine.IsPlayed(x1 - 1, y1 - 1))
                            {
                                gamestate = engine.Press(x1 - 1, y1 - 1, 'u');
                            }
                            winstate = engine.CheckGameState();
                            if (winstate)
                            {
                                break;
                            }
                        }
                        if (winstate)
                        {
                            Console.Clear();
                            Console.WriteLine("You Have Won the Game");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(engine.printBoard());
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(engine.Print_Options());
                        string r = Console.ReadLine();
                        switch (r)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine(engine.Print_Difficulty());
                                string rn = Console.ReadLine();
                                engine.SetDifficult(rn);
                                Console.Clear();
                                engine.Print_Options();
                                break;
                            case "2":
                                Console.Clear();
                                Console.WriteLine("Enter the Number of Mines Needed : ");
                                string temp = Console.ReadLine();
                                int n1 = Convert.ToInt32(temp);
                                engine.SetMine(n1);
                                Console.Clear();
                                engine.Print_Options();
                                break;
                            case "3":
                                Console.Clear();
                                Console.WriteLine("Enter the Board Size : ");
                                string temp1 = Console.ReadLine();
                                int n2 = Convert.ToInt32(temp1);
                                engine.SetSize(n2);
                                Console.Clear();
                                engine.Print_Options();
                                break;
                            case "4":
                                break;
                        }
                        break;
                    case "3":
                        gamestate = false;
                        break;
                }
            }
            
            

        }
    }
}
