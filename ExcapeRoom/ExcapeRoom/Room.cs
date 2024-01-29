using System;


namespace ExcapeRoom
{
    public class Room
    {
        enum EQuadrant
        {
            Top,
            Right,
            Bot,
            Left
        }

        enum EObject
        {
            Chest,
            Player,
            Door,
        }
        
        public Room()
        {
            this.DrawObjects = new WallPrint();

            this.RoomLength = CONSTANTS.LENGTH_INNER_ARRAY;
            this.RoomWidth = CONSTANTS.WIDTH_INNER_ARRAY;
            this.TotalRoomLength = (ushort)(this.RoomLength + 2);
            this.TotalRoomWidth = (ushort)(this.RoomWidth + 2);

            this.CreateRoom();
            this.SpawnDoor();
            this.SpawnPlayer();
            this.SpawnChest();
            
        }
        
        public Room(ushort _RoomLength, ushort _RoomWidth)
        {
            this.DrawObjects = new WallPrint();

            this.RoomLength = _RoomLength;
            this.RoomWidth = _RoomWidth;
            this.TotalRoomLength = (ushort)(this.RoomLength + 2);
            this.TotalRoomWidth = (ushort)(this.RoomWidth + 2);

            this.CreateRoom();
            this.SpawnDoor();
            this.SpawnPlayer();
            this.SpawnChest();
        }

        private WallPrint DrawObjects;

        private ushort RoomLength;
        private ushort TotalRoomLength;
        private ushort RoomWidth;
        private ushort TotalRoomWidth;

        private char[,][,] RoomConstruct;
  
        private ushort PlayerPositionX;
        private ushort PlayerPositionY;
        private ushort ChestPositionX;
        private ushort ChestPositionY;
        private ushort DoorPositionX;
        private ushort DoorPositionY;
        private bool IsDoorUnlocked;
        EQuadrant DoorQuadrant;
        
        private void CreateRoom()
        {
            // Create Instance
            this.RoomConstruct = new char[this.TotalRoomWidth, this.TotalRoomLength][,];
            
            // Allocate the Room
            for (short i = 0; i < this.TotalRoomWidth; i++)
            {
                for (short j = 0; j < this.TotalRoomLength; j++)
                {
                    for (int k = 0; k < this.RoomWidth; k++)
                    {
                        for (int l = 0; l < this.RoomLength; l++)
                        {
                            this.RoomConstruct[i, j] = new char[this.RoomWidth,this.RoomLength];
                        }
                    }
                }
            }
            
            // Fill the Room
            for (short i = 0; i < this.TotalRoomWidth; i++)
            {
                for (short j = 0; j < this.TotalRoomLength; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        this.DrawObjects.DrawLeftUpperCorner(this.RoomConstruct[i, j]);
                        continue;
                    }

                    if (i == 0 && j == this.TotalRoomLength -1)
                    {
                        this.DrawObjects.DrawRightUpperCorner(this.RoomConstruct[i, j]);
                        continue;
                    }
                    
                    if (i == this.TotalRoomWidth - 1 && j == 0)
                    {
                        this.DrawObjects.DrawLeftLowerCorner(this.RoomConstruct[i, j]);
                        continue;
                    }

                    if (i == this.TotalRoomWidth - 1 && j == this.TotalRoomLength - 1)
                    {
                        this.DrawObjects.DrawRightLowerCorner(this.RoomConstruct[i, j]);
                        continue;
                    }

                    if (i == 0 || i == this.TotalRoomWidth - 1)
                    {
                        this.DrawObjects.DrawHorizontalWall(this.RoomConstruct[i, j]);
                        continue;
                    }
                    
                    if (j == 0 || j == this.TotalRoomLength - 1)
                    {
                        this.DrawObjects.DrawVerticalWall(this.RoomConstruct[i, j]);
                        continue;
                    }

                    this.DrawObjects.DrawEmptySpace(this.RoomConstruct[i, j]);
                }
            }
        }

        private void SpawnDoor()
        {
            Random randomNumber = new Random();
            Array randomQuadrant = Enum.GetValues(typeof(EQuadrant));
            
            this.DoorQuadrant = (EQuadrant)randomQuadrant.GetValue(randomNumber.Next(randomQuadrant.Length));

            switch (this.DoorQuadrant)
            {
                case EQuadrant.Top:
                    this.DoorPositionX = (ushort)randomNumber.Next(1, this.TotalRoomLength - 1);
                    this.DoorPositionY = 0;
                    break;
                case EQuadrant.Right:
                    this.DoorPositionX = (ushort)(TotalRoomLength - 1);
                    this.DoorPositionY = (ushort)randomNumber.Next(1, this.TotalRoomWidth - 1);
                    break;
                case EQuadrant.Bot:
                    this.DoorPositionX = (ushort)randomNumber.Next(1, this.TotalRoomLength - 1);
                    this.DoorPositionY = (ushort)(TotalRoomWidth - 1);
                    break;
                case EQuadrant.Left:
                    this.DoorPositionX = 0;
                    this.DoorPositionY = (ushort)randomNumber.Next(1, this.TotalRoomWidth - 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            this.DrawObjects.DrawDoor(this.RoomConstruct[this.DoorPositionY, this.DoorPositionX]);
        }
        
        private void SpawnPlayer()
        {
            Random randomNumber = new Random();
            this.PlayerPositionX = (ushort)randomNumber.Next(1, this.TotalRoomLength - 1);
            this.PlayerPositionY = (ushort)randomNumber.Next(1, this.TotalRoomWidth - 1);
            
            this.DrawObjects.DrawPlayer(this.RoomConstruct[this.PlayerPositionY, this.PlayerPositionX]);
        }

        private void SpawnChest()
        {
            Random randomNumber = new Random();

            while (true)
            {
                this.ChestPositionX = (ushort)randomNumber.Next(1, this.TotalRoomLength - 1);
                this.ChestPositionY = (ushort)randomNumber.Next(1, this.TotalRoomWidth - 1);
                if (this.ChestPositionX != this.PlayerPositionX && this.ChestPositionY != this.PlayerPositionY)
                {
                    break;
                }
            }
            
            this.DrawObjects.DrawChest(this.RoomConstruct[this.ChestPositionY, this.ChestPositionX]);
        }

        public void PrintRoom()
        {
            Console.Clear();
            
            for (int i = 0; i < this.TotalRoomWidth; i++)
            {
                string firstLine = "";
                string secondLine = "";
                string thirdLine = "";
                
                for (int j = 0; j < this.TotalRoomLength; j++)
                {
                    for (int k = 0; k < this.RoomLength; k++)
                    {
                        firstLine += this.RoomConstruct[i, j][0, k];
                        secondLine += this.RoomConstruct[i, j][1, k];
                        thirdLine += this.RoomConstruct[i, j][2, k];
                    }
                }
                Console.WriteLine(firstLine);
                Console.WriteLine(secondLine);
                Console.WriteLine(thirdLine);
            }
        }

        private void UpdateInteriorObjectPosition(ref ushort _OldPositionX, ref ushort _OldPositionY, ushort _NewPositionX, ushort _NewPositionY, EObject _Object)
        {
            this.DrawObjects.DrawEmptySpace(this.RoomConstruct[_OldPositionY, _OldPositionX]);

            // Update the old Position
            _OldPositionX = _NewPositionX;
            _OldPositionY = _NewPositionY;
            
            switch (_Object)
            {
                case EObject.Chest:
                    this.DrawObjects.DrawChest(this.RoomConstruct[_NewPositionY, _NewPositionX]);
                    break;
                case EObject.Player:
                    this.DrawObjects.DrawPlayer(this.RoomConstruct[_NewPositionY, _NewPositionX]);
                    break;
                case EObject.Door:
                    this.DrawObjects.DrawDoor(this.RoomConstruct[_NewPositionY, _NewPositionX]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_Object), _Object, null);
            }
            
            this.PrintRoom();
        }

        public void MovePlayer()
        {
            while (true)
            {
                ConsoleKeyInfo InputKeyInfo = Console.ReadKey(true);

                // Winning text
                if (this.PlayerPositionX == this.DoorPositionX && this.PlayerPositionY == this.DoorPositionY)
                {
                    bool isWon = false;
                    switch (this.DoorQuadrant)
                    {
                        case EQuadrant.Top:
                            if (InputKeyInfo.Key == ConsoleKey.W || InputKeyInfo.Key == ConsoleKey.UpArrow)
                            {
                                isWon = true;
                            }
                            break;
                        case EQuadrant.Right:
                            if (InputKeyInfo.Key == ConsoleKey.D || InputKeyInfo.Key == ConsoleKey.RightArrow)
                            {
                                isWon = true;
                            }
                            break;
                        case EQuadrant.Bot:
                            if (InputKeyInfo.Key == ConsoleKey.S || InputKeyInfo.Key == ConsoleKey.DownArrow)
                            {
                                isWon = true;
                            }
                            break;
                        case EQuadrant.Left:
                            if (InputKeyInfo.Key == ConsoleKey.A || InputKeyInfo.Key == ConsoleKey.LeftArrow)
                            {
                                isWon = true;
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    if (isWon)
                    {
                        Console.WriteLine("Congratulations. You managed to get out of the Locked Room.");
                        break;
                    }
                    
                }

                ushort newPlayerXPosition = this.PlayerPositionX;
                ushort newPlayerYPosition = this.PlayerPositionY;
                
                switch (InputKeyInfo.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                    {
                        newPlayerYPosition--;
                        break;
                    }
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                    {
                        newPlayerYPosition++;
                        break;
                    }
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                    {
                        newPlayerXPosition--;
                        break;
                    }
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                    {
                        newPlayerXPosition++;
                        break;
                    }
                }

                // Collect the Chest
                if (newPlayerXPosition == this.ChestPositionX && newPlayerYPosition == this.ChestPositionY)
                {
                    this.IsDoorUnlocked = true;
                    this.DrawObjects.DrawEmptySpace(this.RoomConstruct[this.ChestPositionY, this.ChestPositionX]);
                }

                if (this.IsDoorUnlocked)
                {
                    this.DrawObjects.DrawEmptySpace(this.RoomConstruct[this.DoorPositionY, this.DoorPositionX]);
                }

                if (this.CheckIfWall(newPlayerXPosition, newPlayerYPosition))
                {
                    newPlayerXPosition = this.PlayerPositionX;
                    newPlayerYPosition = this.PlayerPositionY;
                }
                
                this.UpdateInteriorObjectPosition(ref this.PlayerPositionX, ref this.PlayerPositionY, newPlayerXPosition, newPlayerYPosition, EObject.Player);

                //CreateRoom();
            }
        }

        private bool CheckIfWall(ushort _xPos, ushort _yPos )
        {
            return (this.RoomConstruct[_yPos, _xPos][0, 0] == '#');
        }
    }
}