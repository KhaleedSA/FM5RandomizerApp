namespace FM5Randomizer.GameEnum;

public class MechSpawn
{
    public enum SpawnAreaSize : short
    {
        None = 0,
        Normal = 256,           // Normal Wanzer
        Tank = 1024,            // Normal Wanzer
        Heli = 768,             // Normal Wanzer
        Boss_00 = 512,          // Boss Wanzer
        Boss_01 = 1792,         // Boss Wanzer
        Landing_Craft = 2304,   // Map object
        MapUnit = 2048          // Car, Cannon, Grenad, Silo, Hanger
    }
}