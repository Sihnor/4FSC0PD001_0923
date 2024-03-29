using System;

namespace EscapeRoom
{
    public static class CONSTANTS
    {
        public const ushort LENGTH_INNER_ARRAY = 7;
        public const ushort WIDTH_INNER_ARRAY = 3;
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            GameMechanicsDescription();

            Tuple<ushort, ushort> dimension = SetBothRoomDimensions();
            Room escapeRoom = new Room(dimension.Item1, dimension.Item2);

            escapeRoom.PrintRoom();
            escapeRoom.MovePlayer();

        }

        /// <summary>
        /// Prints the description of the game mechanics.
        /// </summary>
        private static void GameMechanicsDescription()
        {
            while (true)
            {
                Console.WriteLine("Greeting. Welcome to the Game 'Escape Room.'");
                Console.WriteLine("You will spawn in a room where you must find the key to the locked door in order to escape.");
                Console.WriteLine("To Move you will have to use the Arrow-Keys.");
                Console.WriteLine("Since you are still flesh and bones, it is not possible to go through walls or through the closed door.");
                Console.Write("If you have understood please type 'understood': ");

                if (Console.ReadLine().ToLower() == "understood")
                {
                    break;
                }

                Console.Clear();
            }
        }

        /// <summary>
        /// Sets the dimensions of the room.
        /// </summary>
        /// <returns>A tuple with the length and width of the room.</returns>
        private static Tuple<ushort, ushort> SetBothRoomDimensions()
        {
            ushort length;

            // Set length of room
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter the length of the room (min. 7 and max 20): ");
                string input = Console.ReadLine();

                if (ushort.TryParse(input, out length))
                {
                    if (length < 7 || length > 20)
                    {
                        continue;
                    }
                    break;
                }
            }

            ushort width;

            // Set width of room
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter the width of the room (min. 7 and max 20): ");
                string input = Console.ReadLine();

                if (ushort.TryParse(input, out width))
                {
                    if (length < 7 || length > 20)
                    {
                        continue;
                    }
                    break;
                }
            }

            return new Tuple<ushort, ushort>(length, width);
        }
    }
}