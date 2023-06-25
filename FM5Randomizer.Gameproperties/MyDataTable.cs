namespace FM5Randomizer.GameProperties;

public class MyDataTable
{
    public static Random Rnd = new(Guid.NewGuid().GetHashCode());
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

    public class MyGameInfo
    {
        public byte[] PublisherByte = new byte[11] { 0x53, 0x51, 0x55, 0x41, 0x52, 0x45, 0x20, 0x45, 0x4E, 0x49, 0x58 };
        public static byte[] GameNameByte = new byte[14] { 0x46, 0x52, 0x4F, 0x4E, 0x54, 0x5F, 0x4D, 0x49, 0x53, 0x53, 0x49, 0x4F, 0x4E, 0x35 };
        public static readonly byte[] GameCreationDateByte = new byte[17] { 0x32, 0x30, 0x30, 0x35, 0x31, 0x31, 0x32, 0x37, 0x32, 0x31, 0x31, 0x38, 0x34, 0x38, 0x30, 0x30, 0x24 };
        public static byte[] ReadInfoBytes = Array.Empty<byte>();
        public const long GameName_Exe = 0x8028;
        public const long CreationDate_Exe = 0x832D;
        public const long Publisher_Exe = 0x813E;

    }
    public class HangerPatch
    {
        public static byte[] ReadWritePatch = new byte[PatchSize];
        public static string FilePath = $@"{Directory.GetFiles(Directory.GetCurrentDirectory(), "004B7670 shopFM5a").FirstOrDefault()}";
        public const long HangerOffset_EXE = 0x4B7670;
        public const long NewHangerOffset_File= 0;
        public const long OldHangerOffset_File= 0x430;
        private const int PatchSize = 1072;
    }
}