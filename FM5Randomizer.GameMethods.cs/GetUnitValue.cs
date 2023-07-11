using System.Text;
using static FM5Randomizer.GameEnum.WanzerSpawn;

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
            (short)SpawnType.None => false,
            (short)SpawnType.Boss_00 => withBosses ? true : false,
            (short)SpawnType.Boss_01 => withBosses ? true : false,
            (short)SpawnType.Landing_Craft => false,
            (short)SpawnType.MapUnit => false,
            _ => true,
        };
    }
}