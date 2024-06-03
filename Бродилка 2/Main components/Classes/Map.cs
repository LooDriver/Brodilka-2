namespace Бродилка_2.Main_components.Classes
{
    public class Map
    {
        public char[,] ReadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            int numRows = lines.Length;
            int numCols = lines[0].Length;

            char[,] map = new char[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                string line = lines[i];

                for (int j = 0; j < numCols; j++)
                    map[i, j] = line[j];
            }

            return map;
        }

        public void Draw(char[,] map)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                    Console.Write(map[i, j]);

                Console.WriteLine();
            }
        }
    }
}
