using System.Text;
using static FM5Randomizer.GameEnum.MechSpawn;

namespace FM5Randomizer.GameMethods;

public class GetUnitValue
{
    public static bool IsEmptyString(byte[] checkValues)
    {
        string convertToString = Encoding.ASCII.GetString(checkValues).Trim('\0');

        return string.IsNullOrEmpty(convertToString) ? true : false;
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