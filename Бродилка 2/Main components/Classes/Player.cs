using Бродилка_2.Main_components.Interfaces;

namespace Бродилка_2.Main_components.Classes
{
    public class Player : IBasicActions
    {
        private Random _rnd = new();

        public int CoordX { get; set; }

        public int CoordY { get; set; }

        public Player()
        {
            CoordX = _rnd.Next(21);
            CoordY = _rnd.Next(52);
        }

        public void Spawn(char[,] map)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            map[CoordX, CoordY] = '@';
            Console.SetCursorPosition(CoordY, CoordX);
            Console.Write('@');
        }

        public void RandomCoord()
        {
            CoordX = _rnd.Next(21);
            CoordY = _rnd.Next(52);
        }

        public void CheckXY(char[,] map)
        {
            while (map[CoordX, CoordY] == '#')
                RandomCoord();

            if (map[CoordX, CoordY] == ' ')
                Spawn(map);
        }
    }
}
