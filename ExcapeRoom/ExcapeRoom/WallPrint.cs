namespace ExcapeRoom
{
    public class WallPrint
    {
        private readonly char[,] LeftUpperCorner;
        private readonly char[,] RightUpperCorner;
        private readonly char[,] LeftLowerCorner;
        private readonly char[,] RightLowerCorner;
        private readonly char[,] HorizontalWall;
        private readonly char[,] VerticalWall;
        private readonly char[,] EmptySpace;
        private readonly char[,] Chest;
        private readonly char[,] Player;
        private readonly char[,] Door;
        private readonly char[,] DEBUGARRAY;

        public WallPrint()
        {
            this.LeftUpperCorner = new char[3, 7];
            this.RightUpperCorner = new char[3, 7];
            this.LeftLowerCorner = new char[3, 7];
            this.RightLowerCorner = new char[3, 7];
            this.HorizontalWall = new char[3, 7];
            this.VerticalWall = new char[3, 7];
            this.EmptySpace = new char[3, 7];
            this.Chest = new char[3, 7];
            this.Player = new char[3, 7];
            this.Door = new char[3, 7];

            this.InitLeftUpperCorner();
            this.InitRightUpperCorner();
            this.InitLeftLowerCorner();
            this.InitRightLowerCorner();
            this.InitHorizontalWall();
            this.InitVerticalWall();
            this.InitEmptySpace();
            this.InitPlayer();
            this.InitChest();
            this.InitDoor();
            
            this.DEBUGARRAY = new char[3, 7];
            
            this.DEBUGARRAY[0, 0] = 'A';
            this.DEBUGARRAY[0, 1] = 'A';
            this.DEBUGARRAY[0, 2] = 'A';
            this.DEBUGARRAY[0, 3] = 'A';
            this.DEBUGARRAY[0, 4] = 'A';
            this.DEBUGARRAY[0, 5] = 'A';
            this.DEBUGARRAY[0, 6] = 'A';

            this.DEBUGARRAY[1, 0] = 'A';
            this.DEBUGARRAY[1, 1] = 'A';
            this.DEBUGARRAY[1, 2] = 'A';
            this.DEBUGARRAY[1, 3] = 'A';
            this.DEBUGARRAY[1, 4] = 'A';
            this.DEBUGARRAY[1, 5] = 'A';
            this.DEBUGARRAY[1, 6] = 'A';

            this.DEBUGARRAY[2, 0] = 'A';
            this.DEBUGARRAY[2, 1] = 'A';
            this.DEBUGARRAY[2, 2] = 'A';
            this.DEBUGARRAY[2, 3] = 'A';
            this.DEBUGARRAY[2, 4] = 'A';
            this.DEBUGARRAY[2, 5] = 'A';
            this.DEBUGARRAY[2, 6] = 'A';
        }

        void InitLeftUpperCorner()
        {
            // Console.Write("#######");
            // Console.Write("#      ");
            // Console.Write("#     #");

            this.LeftUpperCorner[0, 0] = '#';
            this.LeftUpperCorner[0, 1] = '#';
            this.LeftUpperCorner[0, 2] = '#';
            this.LeftUpperCorner[0, 3] = '#';
            this.LeftUpperCorner[0, 4] = '#';
            this.LeftUpperCorner[0, 5] = '#';
            this.LeftUpperCorner[0, 6] = '#';

            this.LeftUpperCorner[1, 0] = '#';
            this.LeftUpperCorner[1, 1] = ' ';
            this.LeftUpperCorner[1, 2] = ' ';
            this.LeftUpperCorner[1, 3] = ' ';
            this.LeftUpperCorner[1, 4] = ' ';
            this.LeftUpperCorner[1, 5] = ' ';
            this.LeftUpperCorner[1, 6] = ' ';

            this.LeftUpperCorner[2, 0] = '#';
            this.LeftUpperCorner[2, 1] = ' ';
            this.LeftUpperCorner[2, 2] = ' ';
            this.LeftUpperCorner[2, 3] = ' ';
            this.LeftUpperCorner[2, 4] = ' ';
            this.LeftUpperCorner[2, 5] = ' ';
            this.LeftUpperCorner[2, 6] = '#';
        }

        void InitRightUpperCorner()
        {
            // Console.Write("#######");
            // Console.Write("      #");
            // Console.Write("#     #");

            this.RightUpperCorner[0, 0] = '#';
            this.RightUpperCorner[0, 1] = '#';
            this.RightUpperCorner[0, 2] = '#';
            this.RightUpperCorner[0, 3] = '#';
            this.RightUpperCorner[0, 4] = '#';
            this.RightUpperCorner[0, 5] = '#';
            this.RightUpperCorner[0, 6] = '#';

            this.RightUpperCorner[1, 0] = ' ';
            this.RightUpperCorner[1, 1] = ' ';
            this.RightUpperCorner[1, 2] = ' ';
            this.RightUpperCorner[1, 3] = ' ';
            this.RightUpperCorner[1, 4] = ' ';
            this.RightUpperCorner[1, 5] = ' ';
            this.RightUpperCorner[1, 6] = '#';

            this.RightUpperCorner[2, 0] = '#';
            this.RightUpperCorner[2, 1] = ' ';
            this.RightUpperCorner[2, 2] = ' ';
            this.RightUpperCorner[2, 3] = ' ';
            this.RightUpperCorner[2, 4] = ' ';
            this.RightUpperCorner[2, 5] = ' ';
            this.RightUpperCorner[2, 6] = '#';
        }

        void InitLeftLowerCorner()
        {
            // Console.Write("#     #");
            // Console.Write("#      ");
            // Console.Write("#######");

            this.LeftLowerCorner[0, 0] = '#';
            this.LeftLowerCorner[0, 1] = ' ';
            this.LeftLowerCorner[0, 2] = ' ';
            this.LeftLowerCorner[0, 3] = ' ';
            this.LeftLowerCorner[0, 4] = ' ';
            this.LeftLowerCorner[0, 5] = ' ';
            this.LeftLowerCorner[0, 6] = '#';

            this.LeftLowerCorner[1, 0] = '#';
            this.LeftLowerCorner[1, 1] = ' ';
            this.LeftLowerCorner[1, 2] = ' ';
            this.LeftLowerCorner[1, 3] = ' ';
            this.LeftLowerCorner[1, 4] = ' ';
            this.LeftLowerCorner[1, 5] = ' ';
            this.LeftLowerCorner[1, 6] = ' ';

            this.LeftLowerCorner[2, 0] = '#';
            this.LeftLowerCorner[2, 1] = '#';
            this.LeftLowerCorner[2, 2] = '#';
            this.LeftLowerCorner[2, 3] = '#';
            this.LeftLowerCorner[2, 4] = '#';
            this.LeftLowerCorner[2, 5] = '#';
            this.LeftLowerCorner[2, 6] = '#';
        }

        void InitRightLowerCorner()
        {
            // Console.Write("#     #");
            // Console.Write("      #");
            // Console.Write("#######");

            this.RightLowerCorner[0, 0] = '#';
            this.RightLowerCorner[0, 1] = ' ';
            this.RightLowerCorner[0, 2] = ' ';
            this.RightLowerCorner[0, 3] = ' ';
            this.RightLowerCorner[0, 4] = ' ';
            this.RightLowerCorner[0, 5] = ' ';
            this.RightLowerCorner[0, 6] = '#';

            this.RightLowerCorner[1, 0] = ' ';
            this.RightLowerCorner[1, 1] = ' ';
            this.RightLowerCorner[1, 2] = ' ';
            this.RightLowerCorner[1, 3] = ' ';
            this.RightLowerCorner[1, 4] = ' ';
            this.RightLowerCorner[1, 5] = ' ';
            this.RightLowerCorner[1, 6] = '#';

            this.RightLowerCorner[2, 0] = '#';
            this.RightLowerCorner[2, 1] = '#';
            this.RightLowerCorner[2, 2] = '#';
            this.RightLowerCorner[2, 3] = '#';
            this.RightLowerCorner[2, 4] = '#';
            this.RightLowerCorner[2, 5] = '#';
            this.RightLowerCorner[2, 6] = '#';
        }

        void InitHorizontalWall()
        {
            // Console.Write("#######");
            // Console.Write("       ");
            // Console.Write("#######");

            this.HorizontalWall[0, 0] = '#';
            this.HorizontalWall[0, 1] = '#';
            this.HorizontalWall[0, 2] = '#';
            this.HorizontalWall[0, 3] = '#';
            this.HorizontalWall[0, 4] = '#';
            this.HorizontalWall[0, 5] = '#';
            this.HorizontalWall[0, 6] = '#';

            this.HorizontalWall[1, 0] = ' ';
            this.HorizontalWall[1, 1] = ' ';
            this.HorizontalWall[1, 2] = ' ';
            this.HorizontalWall[1, 3] = ' ';
            this.HorizontalWall[1, 4] = ' ';
            this.HorizontalWall[1, 5] = ' ';
            this.HorizontalWall[1, 6] = ' ';

            this.HorizontalWall[2, 0] = '#';
            this.HorizontalWall[2, 1] = '#';
            this.HorizontalWall[2, 2] = '#';
            this.HorizontalWall[2, 3] = '#';
            this.HorizontalWall[2, 4] = '#';
            this.HorizontalWall[2, 5] = '#';
            this.HorizontalWall[2, 6] = '#';
        }

        void InitVerticalWall()
        {
            // Console.Write("#     #");
            // Console.Write("#     #");
            // Console.Write("#     #");

            this.VerticalWall[0, 0] = '#';
            this.VerticalWall[0, 1] = ' ';
            this.VerticalWall[0, 2] = ' ';
            this.VerticalWall[0, 3] = ' ';
            this.VerticalWall[0, 4] = ' ';
            this.VerticalWall[0, 5] = ' ';
            this.VerticalWall[0, 6] = '#';

            this.VerticalWall[1, 0] = '#';
            this.VerticalWall[1, 1] = ' ';
            this.VerticalWall[1, 2] = ' ';
            this.VerticalWall[1, 3] = ' ';
            this.VerticalWall[1, 4] = ' ';
            this.VerticalWall[1, 5] = ' ';
            this.VerticalWall[1, 6] = '#';

            this.VerticalWall[2, 0] = '#';
            this.VerticalWall[2, 1] = ' ';
            this.VerticalWall[2, 2] = ' ';
            this.VerticalWall[2, 3] = ' ';
            this.VerticalWall[2, 4] = ' ';
            this.VerticalWall[2, 5] = ' ';
            this.VerticalWall[2, 6] = '#';
        }

        void InitEmptySpace()
        {
            // Console.Write("       ");
            // Console.Write("       ");
            // Console.Write("       ");

            this.EmptySpace[0, 0] = ' ';
            this.EmptySpace[0, 1] = ' ';
            this.EmptySpace[0, 2] = ' ';
            this.EmptySpace[0, 3] = ' ';
            this.EmptySpace[0, 4] = ' ';
            this.EmptySpace[0, 5] = ' ';
            this.EmptySpace[0, 6] = ' ';

            this.EmptySpace[1, 0] = ' ';
            this.EmptySpace[1, 1] = ' ';
            this.EmptySpace[1, 2] = ' ';
            this.EmptySpace[1, 3] = ' ';
            this.EmptySpace[1, 4] = ' ';
            this.EmptySpace[1, 5] = ' ';
            this.EmptySpace[1, 6] = ' ';

            this.EmptySpace[2, 0] = ' ';
            this.EmptySpace[2, 1] = ' ';
            this.EmptySpace[2, 2] = ' ';
            this.EmptySpace[2, 3] = ' ';
            this.EmptySpace[2, 4] = ' ';
            this.EmptySpace[2, 5] = ' ';
            this.EmptySpace[2, 6] = ' ';
        }

        void InitPlayer()
        {
            // Console.WriteLine("\  O  /");
            // Console.WriteLine(" \ | / ");
            // Console.WriteLine(" / | \ ");

            this.Player[0, 0] = '\\';
            this.Player[0, 1] = ' ';
            this.Player[0, 2] = ' ';
            this.Player[0, 3] = 'O';
            this.Player[0, 4] = ' ';
            this.Player[0, 5] = ' ';
            this.Player[0, 6] = '/';

            this.Player[1, 0] = ' ';
            this.Player[1, 1] = '\\';
            this.Player[1, 2] = ' ';
            this.Player[1, 3] = '|';
            this.Player[1, 4] = ' ';
            this.Player[1, 5] = '/';
            this.Player[1, 6] = ' ';

            this.Player[2, 0] = ' ';
            this.Player[2, 1] = '/';
            this.Player[2, 2] = ' ';
            this.Player[2, 3] = '|';
            this.Player[2, 4] = ' ';
            this.Player[2, 5] = '\\';
            this.Player[2, 6] = ' ';
        }
        
        void InitChest()
        {
            // Console.Write("/XXXXX\");
            // Console.Write("| XXX |");
            // Console.Write("\XXXXX/");

            this.Chest[0, 0] = '/';
            this.Chest[0, 1] = 'X';
            this.Chest[0, 2] = 'X';
            this.Chest[0, 3] = 'X';
            this.Chest[0, 4] = 'X';
            this.Chest[0, 5] = 'X';
            this.Chest[0, 6] = '\\';

            this.Chest[1, 0] = '|';
            this.Chest[1, 1] = ' ';
            this.Chest[1, 2] = 'X';
            this.Chest[1, 3] = 'X';
            this.Chest[1, 4] = 'X';
            this.Chest[1, 5] = ' ';
            this.Chest[1, 6] = '|';

            this.Chest[2, 0] = '\\';
            this.Chest[2, 1] = 'X';
            this.Chest[2, 2] = 'X';
            this.Chest[2, 3] = 'X';
            this.Chest[2, 4] = 'X';
            this.Chest[2, 5] = 'X';
            this.Chest[2, 6] = '/';
        }
        
        void InitDoor()
        {
            // Console.Write("#X   X#");
            // Console.Write("  XXX  ");
            // Console.Write("#X   X#");

            this.Door[0, 0] = '#';
            this.Door[0, 1] = 'X';
            this.Door[0, 2] = ' ';
            this.Door[0, 3] = ' ';
            this.Door[0, 4] = ' ';
            this.Door[0, 5] = 'X';
            this.Door[0, 6] = '#';

            this.Door[1, 0] = ' ';
            this.Door[1, 1] = ' ';
            this.Door[1, 2] = 'X';
            this.Door[1, 3] = 'X';
            this.Door[1, 4] = 'X';
            this.Door[1, 5] = ' ';
            this.Door[1, 6] = ' ';

            this.Door[2, 0] = '#';
            this.Door[2, 1] = 'X';
            this.Door[2, 2] = ' ';
            this.Door[2, 3] = ' ';
            this.Door[2, 4] = ' ';
            this.Door[2, 5] = 'X';
            this.Door[2, 6] = '#';
        }

        public void DrawLeftUpperCorner(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.LeftUpperCorner[i, j];
                }
            }
        }

        public void DrawRightUpperCorner(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.RightUpperCorner[i, j];
                }
            }
        }

        public void DrawLeftLowerCorner(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.LeftLowerCorner[i, j];
                }
            }
        }

        public void DrawRightLowerCorner(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.RightLowerCorner[i, j];
                }
            }
        }

        public void DrawHorizontalWall(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.HorizontalWall[i, j];
                }
            }
        }

        public void DrawVerticalWall(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.VerticalWall[i, j];
                }
            }
        }

        public void DrawPlayer(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.Player[i, j];
                }
            }
        }

        public void DrawChest(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.Chest[i, j];
                }
            }
        }

        public void DrawEmptySpace(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.EmptySpace[i, j];
                }
            }
        }

        public void DrawDoor(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.Door[i, j];
                }
            }
        }
        
        public void DrawDEBUG(char[,] _Room)
        {
            for (int i = 0; i < CONSTANTS.WIDTH_INNER_ARRAY; i++)
            {
                for (int j = 0; j < CONSTANTS.LENGTH_INNER_ARRAY; j++)
                {
                    _Room[i, j] = this.DEBUGARRAY[i, j];
                }
            }
        }
    }
}