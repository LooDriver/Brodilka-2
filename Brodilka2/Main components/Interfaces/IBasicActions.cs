namespace Бродилка_2.Main_components.Interfaces
{
    public interface IBasicActions
    {
        void Spawn(char[,] map);

        void RandomCoord();

        void CheckXY(char[,] map);
    }
}
