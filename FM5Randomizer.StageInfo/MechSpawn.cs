namespace FM5Randomizer.GameEnum;

public class MechSpawn
{
    public enum SpawnAreaSize : short
    {
        None = 0,
        Normal = 256,           // Normal units
        Tank = 1024,            // Normal units
        Heli = 768,             // Normal units
        Boss_00 = 512,          // Boss units
        Boss_01 = 1792,         // Boss unit
        Landing_Craft = 2304,   // Map object
        MapUnit = 2048          // Car, Cannon, Grenad, Silo, Hanger
    }
}