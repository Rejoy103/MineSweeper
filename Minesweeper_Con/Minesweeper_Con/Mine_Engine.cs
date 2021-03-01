using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper_Con
{
    class Mine_Engine
    {
        private int Board_Size = 9;
        private int Nmine= 10;
        private char[,] Board;
        private char[,] Vis_Board;
        private int[,] Mine;

        public Mine_Engine()
        {
            
        }
        public void InitializeGame()
        {
            Vis_Board = new char[Board_Size, Board_Size];
            Board = new char[Board_Size, Board_Size];
            Mine = new int[Nmine, 2];
            for (int i = 0; i < Board_Size; i++)
            {
                for (int j = 0; j < Board_Size; j++)
                {
                    Vis_Board[i, j] = 'o';
                    Board[i, j] = 'o';
                }
            }
            for (int i = 0; i < Nmine; i++)
            {
                Random z = new Random(DateTime.Now.Millisecond);
                int x = z.Next() % (Board_Size);
                int y = z.Next() % (Board_Size);
                if (IsValid(x, y) && Board[x, y] != '*')
                {
                    Board[x, y] = '*';
                    Mine[i, 0] = x;
                    Mine[i, 1] = y;
                }
                else
                {
                    i--;
                }
            }
        }
        public string Print_MainPage()
        {
            string b = "";
            b = "---------------------------------------------\nMine Sweeper V0.1\n---------------------------------------------\n";
            b += "1.Play\n2.Settings\n3.Quit\n";
            b += "---------------------------------------------";
            return b;
        }
        public string Print_Options()
        {
            string b = "";
            b = "---------------------------------------------\nOptions\n---------------------------------------------\n";
            b += "1.Set Difficulty\n2.Set # of Mines\n3.Board Size\n4.Exit";
            b+= "\n-------------------------------------------- - ";
            return (b);
        }
        public string Print_Difficulty()
        {
            string b = "";
            b = "---------------------------------------------\nDifficulty\n---------------------------------------------\n";
            b += "1.Baby\n2.Kid\n3.Youth\n4.Adult";
            b += "\n---------------------------------------------";
            return b;
        }
        public void SetMine(int x)
        {
            Nmine = x;
        }
        public void SetSize(int x)
        {
            Board_Size = x;
        }
        public void SetDifficult(string o)
        {
            if (o == "1")
            {
                Nmine = 5;
                Board_Size = 9;
            }
            if (o == "2")
            {
                Nmine = 10;
                Board_Size = 9;
            }
            if (o == "3")
            {
                Nmine = 15;
                Board_Size = 18;
            }
            if (o == "4")
            {
                Nmine = 30;
                Board_Size = 20;
            }
        }
        public Boolean Press(int x,int y,char mode)
        {
            if (Board[x, y] == '*' && mode=='u')
            {
                for(int i = 0; i < Nmine; i++)
                {
                    Vis_Board[Mine[i, 0], Mine[i, 1]] = '*';
                }
                return false;
            }else if(Board[x,y]=='*' && mode == 'c')
            {
                return false;
            }
            else
            {
                Vis_Board[x, y] = '-';
                Board[x, y] = '-';
                int t = MineCount(x, y);
                if (t > 0)
                {
                    Vis_Board[x, y] = t.ToString().ToCharArray()[0];
                }
                if (IsValid(x - 1, y - 1))
                {
                    int c = MineCount(x - 1, y - 1);
                    if (Board[x - 1, y - 1] != '*' && Board[x - 1, y - 1] != '-' && c==0)
                    {
                        Press(x - 1, y - 1, 'c');
                    }
                    else if(c !=0 && Board[x - 1, y - 1] != '*')
                    {
                        Vis_Board[x - 1, y - 1] = c.ToString().ToCharArray()[0];
                        Board[x - 1, y - 1] = '-';
                    }
                    else
                    {
                    }
                }
                if (IsValid(x - 1, y))
                {
                    int c = MineCount(x - 1, y);
                    if (Board[x - 1, y] != '*' && Board[x - 1, y] != '-' && c==0)
                    {
                        Press(x - 1, y, 'c');
                    }
                    else if(c !=0 && Board[x - 1, y] != '*')
                    {
                        Vis_Board[x - 1, y] = c.ToString().ToCharArray()[0];
                        Board[x - 1, y ] = '-';
                    }
                    else
                    {
                       
                    }
                }
                if (IsValid(x - 1, y + 1))
                {
                    int c = MineCount(x - 1, y + 1);
                    if (Board[x - 1, y + 1] != '*' && Board[x - 1, y + 1] != '-' && c==0)
                    {
                        Press(x - 1, y + 1, 'c');
                    }
                    else if(c!=0 && Board[x - 1, y + 1] != '*')
                    {
                        Vis_Board[x - 1, y + 1] = c.ToString().ToCharArray()[0];
                        Board[x - 1, y + 1] = '-';
                    }
                    else
                    {
                      
                    }
                }
                if (IsValid(x, y - 1))
                {
                    int c = MineCount(x, y - 1);
                    if (Board[x, y - 1] != '*' && Board[x, y - 1] != '-' && c==0)
                    {
                        Press(x, y - 1, 'c');
                    }
                    else if(c!=0 && Board[x, y - 1] != '*')
                    {
                        Vis_Board[x, y - 1] = c.ToString().ToCharArray()[0];
                        Board[x , y - 1] = '-';
                    }
                    else
                    {
                       
                    }
                }
                if (IsValid(x, y + 1))
                {
                    int c = MineCount(x, y + 1);
                    if (Board[x, y + 1] != '*' && Board[x, y + 1] != '-' && c==0)
                    {
                        Press(x, y + 1, 'c');
                    }
                    else if(c !=0 && Board[x, y + 1] != '*')
                    {
                        Vis_Board[x, y + 1] = c.ToString().ToCharArray()[0];
                        Board[x , y + 1] = '-';
                    }
                    else
                    {
                      
                    }
                }
                if (IsValid(x + 1, y - 1))
                {
                    int c = MineCount(x + 1, y - 1);
                    if (Board[x + 1, y - 1] != '*' && Board[x + 1, y - 1] != '-' && c==0)
                    {
                        Press(x + 1, y - 1, 'c');
                    }
                    else if(c!=0 && Board[x + 1, y - 1] != '*')
                    {
                        Vis_Board[x + 1, y - 1] = c.ToString().ToCharArray()[0];
                        Board[x + 1, y - 1] = '-';
                    }
                    else
                    {
                     
                    }
                }
                if (IsValid(x + 1, y))
                {
                    int c = MineCount(x + 1, y);
                    if (Board[x + 1, y] != '*' && Board[x + 1, y] != '-' && c==0)
                    {
                        Press(x + 1, y, 'c');
                    }
                    else if(c!=0 && Board[x + 1, y] != '*')
                    {
                        Vis_Board[x + 1, y] = c.ToString().ToCharArray()[0];
                        Board[x + 1, y] = '-';
                    }
                    else
                    {
                      
                    }
                }
                if (IsValid(x + 1, y + 1))
                {
                    int c = MineCount(x + 1, y + 1);
                    if (Board[x + 1, y + 1] != '*' && Board[x + 1, y + 1] != '-' && c==0)
                    {
                        Press(x + 1, y + 1, 'c');
                    }
                    else if(c!=0 && Board[x + 1, y + 1] != '*')
                    {
                        Vis_Board[x + 1, y + 1] = c.ToString().ToCharArray()[0];
                        Board[x + 1, y + 1] = '-';
                    }
                    else
                    {
                     
                    }
                }
            }
            return true;
        }
        public Boolean CheckGameState()
        {
            int c=0;
            for(int i = 0; i < Board_Size; i++)
            {
                for(int j = 0; j < Board_Size; j++)
                {
                    if (Board[i, j] == 'o')
                    {
                        c++;
                    }
                }
            }
            if (c == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean IsPlayed(int x,int y)
        {
            if (IsValid(x,y))
            {
                if (Board[x, y] == '-')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public string printBoard()
        {
            string b = "  ";
            for(int i = 0; i < Board_Size; i++)
            {
                b += (i+1).ToString() + " ";
            }
            b += "\n";
            for(int i = 0; i < Board_Size; i++)
            {
                b += (i + 1).ToString() + " ";
                for (int j = 0; j < Board_Size; j++)
                {
                    
                    b += Vis_Board[i, j] + " ";
                }
                b += "\n";
            }
            return b;
        }
        public string printBoard_Mine()
        {
            string b = " 1 2 3 4 5 6 7 8 9\n";
            for (int i = 0; i < Board_Size; i++)
            {
                b += (i + 1).ToString() + " ";
                for (int j = 0; j < Board_Size; j++)
                {

                    b += Board[i, j] + " ";
                }
                b += "\n";
            }
            return b;
        }
        private int MineCount(int x,int y)
        {
            int count = 0;
            if (IsValid(x - 1, y - 1))
            {
                if (Board[x - 1, y - 1] == '*')
                {
                    count++;
                }
            }
            if (IsValid(x - 1, y))
            {
                if (Board[x - 1, y] == '*')
                {
                    count++;
                }
            }
            if (IsValid(x - 1, y + 1))
            {
                if (Board[x - 1, y + 1] == '*')
                {
                    count++;
                }
            }
            if (IsValid(x, y - 1))
            {
                if (Board[x, y - 1] == '*')
                {
                    count++;
                }
            }
            if (IsValid(x, y + 1))
            {
                if (Board[x, y + 1] == '*')
                {
                    count++;
                }
            }
            if (IsValid(x + 1, y - 1))
            {
                if (Board[x + 1, y - 1] == '*')
                {
                    count++;
                }
            }
            if (IsValid(x + 1, y))
            {
                if (Board[x + 1, y] == '*')
                {
                    count++;
                }
            }
            if (IsValid(x + 1, y + 1))
            {
                if (Board[x + 1, y+1] == '*')
                {
                    count++;
                }
            }

            return count;
        }
        public Boolean IsValid(int x,int y)
        {
            if((x<Board_Size && x>=0) && (y < Board_Size && y>=0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
