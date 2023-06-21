namespace FM5Randomizer.GameProperties;

public class MyDataTable
{
    public static Random Rnd = new();
    public static byte EnemyId { get; set; } = 0;
    public static List<byte> ValidEnemyId = new();
    public static List<byte> InValidEnemyID = new();

    public static byte[] ReadWriteModel = new byte[128];
    public static byte[] ReadWriteStats = new byte[256];
    

    #region Object Size
    public const int ModelScriptSize = 3328;
    public const int ModelEntitySize = 128;
    public const int StatsScriptSize = 14848;
    public const int StatsEntitySize = 256;
    public const int JumpToStats = 5632;
    #endregion

    #region Stats Lvl
    public const byte MaxPilotLvl = 50;
    public const byte MinPilotLvl = 0;
    public const byte MaxLvl = 12;
    public const byte MinLvl = 0; 
    #endregion
}