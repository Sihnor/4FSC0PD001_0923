using System;


namespace EscapeRoom
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
        
        public Room(ushort roomLength, ushort roomWidth)
        {
            this.DrawObjects = new WallPrint();

            this.RoomLength = roomLength;
            this.RoomWidth = roomWidth;
            this.TotalRoomLength = (ushort)(this.RoomLength + 2);
            this.TotalRoomWidth = (ushort)(this.RoomWidth + 2);

            this.CreateRoom();
            this.SpawnDoor();
            this.SpawnPlayer();
            this.SpawnChest();
        }

        private readonly WallPrint DrawObjects;

        private readonly ushort RoomLength;
        private readonly ushort TotalRoomLength;
        private readonly ushort RoomWidth;
        private readonly ushort TotalRoomWidth;

        private char[,][,] RoomConstruct;
  
        private ushort PlayerPositionX;
        private ushort PlayerPositionY;
        private ushort ChestPositionX;
        private ushort ChestPositionY;
        private ushort DoorPositionX;
        private ushort DoorPositionY;
        private bool IsDoorUnlocked;
        private EQuadrant DoorQuadrant;
        
        /// <summary>
        /// Creates the Room
        /// </summary>
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

        /// <summary>
        /// Spawns the Door
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        
        /// <summary>
        /// Spawns the Player
        /// </summary>
        private void SpawnPlayer()
        {
            Random randomNumber = new Random();
            this.PlayerPositionX = (ushort)randomNumber.Next(1, this.TotalRoomLength - 1);
            this.PlayerPositionY = (ushort)randomNumber.Next(1, this.TotalRoomWidth - 1);
            
            this.DrawObjects.DrawPlayer(this.RoomConstruct[this.PlayerPositionY, this.PlayerPositionX]);
        }

        /// <summary>
        /// Spawns the Chest
        /// </summary>
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

        /// <summary>
        /// Prints the Room
        /// </summary>
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

        /// <summary>
        /// Updates the Position of the Interior Objects (actual only the Player)
        /// </summary>
        /// <param name="oldPositionX">The old x Position</param>
        /// <param name="oldPositionY">The old y Position</param>
        /// <param name="newPositionX">The new x Position</param>
        /// <param name="newPositionY">The new y Position</param>
        /// <param name="object">The Object</param>
        private void UpdateInteriorObjectPosition(ref ushort oldPositionX, ref ushort oldPositionY, ushort newPositionX, ushort newPositionY, EObject @object)
        {
            this.DrawObjects.DrawEmptySpace(this.RoomConstruct[oldPositionY, oldPositionX]);

            // Update the old Position
            oldPositionX = newPositionX;
            oldPositionY = newPositionY;
            
            switch (@object)
            {
                case EObject.Chest:
                    this.DrawObjects.DrawChest(this.RoomConstruct[newPositionY, newPositionX]);
                    break;
                case EObject.Player:
                    this.DrawObjects.DrawPlayer(this.RoomConstruct[newPositionY, newPositionX]);
                    break;
                case EObject.Door:
                    this.DrawObjects.DrawDoor(this.RoomConstruct[newPositionY, newPositionX]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@object), @object, null);
            }
            
            this.PrintRoom();
        }

        /// <summary>
        /// Handling the Movement of the Player (Game Loop)
        /// </summary>
        public void MovePlayer()
        {
            while (true)
            {
                ConsoleKeyInfo inputKeyInfo = Console.ReadKey(true);

                // Winning Move
                if (this.PlayerPositionX == this.DoorPositionX && this.PlayerPositionY == this.DoorPositionY)
                {
                    bool isWon = false;
                    switch (this.DoorQuadrant)
                    {
                        case EQuadrant.Top:
                            if (inputKeyInfo.Key == ConsoleKey.W || inputKeyInfo.Key == ConsoleKey.UpArrow)
                            {
                                isWon = true;
                            }
                            break;
                        case EQuadrant.Right:
                            if (inputKeyInfo.Key == ConsoleKey.D || inputKeyInfo.Key == ConsoleKey.RightArrow)
                            {
                                isWon = true;
                            }
                            break;
                        case EQuadrant.Bot:
                            if (inputKeyInfo.Key == ConsoleKey.S || inputKeyInfo.Key == ConsoleKey.DownArrow)
                            {
                                isWon = true;
                            }
                            break;
                        case EQuadrant.Left:
                            if (inputKeyInfo.Key == ConsoleKey.A || inputKeyInfo.Key == ConsoleKey.LeftArrow)
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
                
                // Input Handling for the Player
                switch (inputKeyInfo.Key)
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

                // Open the Door
                if (this.IsDoorUnlocked)
                {
                    this.DrawObjects.DrawEmptySpace(this.RoomConstruct[this.DoorPositionY, this.DoorPositionX]);
                }

                // Check if the new Position is a Wall
                if (this.CheckIfWall(newPlayerXPosition, newPlayerYPosition))
                {
                    newPlayerXPosition = this.PlayerPositionX;
                    newPlayerYPosition = this.PlayerPositionY;
                }
                
                this.UpdateInteriorObjectPosition(ref this.PlayerPositionX, ref this.PlayerPositionY, newPlayerXPosition, newPlayerYPosition, EObject.Player);

                //CreateRoom();
            }
        }

        /// <summary>
        /// Checks if the new Position is a Wall
        /// </summary>
        /// <param name="xPos">The x Position</param>
        /// <param name="yPos">The y Position</param>
        private bool CheckIfWall(ushort xPos, ushort yPos )
        {
            return (this.RoomConstruct[yPos, xPos][0, 0] == '#');
        }
    }
}