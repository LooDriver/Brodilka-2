using Бродилка_2.Main_components.Interfaces;

namespace Бродилка_2.Main_components.Classes
{
    public class Loot : IBasicActions
    {
        private Random _rnd = new();

        private int CoordX { get; set; }

        private int CoordY { get; set; }

        public Loot()
        {
            CoordX = _rnd.Next(21);
            CoordY = _rnd.Next(52);
        }

        public void RandomCoord()
        {
            CoordX = _rnd.Next(21);
            CoordY = _rnd.Next(52);
        }

        public void Spawn(char[,] map)
        {
            map[CoordX, CoordY] = 'o';
            Console.SetCursorPosition(CoordY, CoordX);
            Console.Write('o');
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
