using Бродилка_2.Main_components.Classes;

Console.CursorVisible = false;

bool inOpen = true;
int score = 0,
    level = 1;

char[,] playArea;

Map map = new Map();
Player player = new Player();
Loot loot = new Loot();

while (inOpen)
{
    int mapNumber = score / 10 + 1;
    playArea = map.ReadFromFile($"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"))}/Maps/map{mapNumber}.txt");
    map.Draw(playArea);

    Console.SetCursorPosition(0, 25);
    Console.Write("Количество лута: ");

    Console.SetCursorPosition(17, 25);
    Console.WriteLine(score);

    Console.SetCursorPosition(0, 26);
    Console.WriteLine("Уровень: ");

    Console.SetCursorPosition(9, 26);
    Console.WriteLine(level);

    player.CheckXY(playArea);

    loot.CheckXY(playArea);

    ConsoleKeyInfo charKey = Console.ReadKey();

    switch (charKey.Key)
    {
        case ConsoleKey.UpArrow:
        case ConsoleKey.W:
            player.CoordX--;
            break;

        case ConsoleKey.DownArrow:
        case ConsoleKey.S:
            player.CoordX++;
            break;

        case ConsoleKey.LeftArrow:
        case ConsoleKey.A:
            player.CoordY--;
            break;

        case ConsoleKey.RightArrow:
        case ConsoleKey.D:
            player.CoordY++;
            break;
    }

    if (playArea[player.CoordX, player.CoordY] == 'o')
    {
        playArea[player.CoordX, player.CoordY] = ' ';

        score++;

        if (score % 10 == 0)
            level++;

        loot.RandomCoord();
        loot.CheckXY(playArea);
    }

    Console.ForegroundColor = ConsoleColor.Green;

    if (playArea[player.CoordX, player.CoordY] == '#')
    {
        inOpen = false;
        Console.Clear();
        Console.WriteLine("ТЫ ПРОИГРАЛ!!!");
    }

    if (charKey.Key == ConsoleKey.Escape)
    {
        inOpen = false;
        Console.Clear();
        Console.WriteLine("ТТЫ ЛИВНУЛ С ПОЗОРОМ!!!");
    }

    if (score == 100)
    {
        inOpen = false;
        Console.Clear();
        level--;
        Console.WriteLine("Ура, ты скипнул время, молодец!");
    }
}

Console.WriteLine($"Количество набранного лута: {score}.");
Console.WriteLine($"Уровень: {level}.");
Console.WriteLine("Для выхода нажми 2 раза Enter.");
Console.ReadLine();