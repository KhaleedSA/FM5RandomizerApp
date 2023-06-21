using System.Text;
using static FM5Randomizer.GameEnum.MechSpawn;

namespace FM5Randomizer.GameMethods;

public class CheckObjectValue
{
    private static readonly List<string> MapObject = new() { "cannon", "mapunit"/*, "TANK", "HELI" */};

    public static bool IsEmptyString(byte[] checkValues)
    {
        string convertToString = Encoding.ASCII.GetString(checkValues).Trim('\0');

        return string.IsNullOrEmpty(convertToString) ? true : false;
    }

    public static string GetEnemyName(byte[] checkValues) => Encoding.ASCII.GetString(checkValues).Trim('\0');

    public static bool IsObject(byte[] checkValue)
    {
        string convertToString = Encoding.UTF8.GetString(checkValue).Trim('\0');

        return MapObject.Any(x => convertToString.Contains(x)) ? true : false;
    }

    public static bool IsNormalEnemy(byte[] checkValue, bool withBosses = false)
    {
        return BitConverter.ToInt16(checkValue, 0) switch
        {
            (short)SpawnAreaSize.None => false,
            (short)SpawnAreaSize.Boss_00 => withBosses ? true : false,
            (short)SpawnAreaSize.Boss_01 => withBosses ? true : false,
            (short)SpawnAreaSize.Landing_Craft => false,
            (short)SpawnAreaSize.MapUnit => false,
            _ => true,
        };
    }
}