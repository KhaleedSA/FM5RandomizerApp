namespace FM5Randomizer.GameProperties;

public class MyDataTable
{
    public static Random Rnd = new();
    public static long ReadStageAddress {  get; set; }
    public static byte EnemyId { get; set; } = 0;
    public static List<byte> ValidEnemyId = new();
    public static List<byte> InValidEnemyID = new();

    public class ObjectSize
    {
        public const string Player_Script = nameof(Player_Script);
        public const string Model_Script = nameof(Model_Script);
        public const string Model_Entity = nameof(Model_Entity);
        public const string Stats_Script = nameof(Stats_Script);
        public const string Stats_Entity = nameof(Stats_Entity);
        public const string Seek_Stats = nameof(Seek_Stats);

        private static readonly Dictionary<string, int> _size = new() 
        {{Player_Script, 768}, {Model_Script, 3328}, {Model_Entity, 128}, {/*Stats_Script, 14848*/Stats_Script, 16384}, {Stats_Entity, 256}, {/*Seek_Stats, 5632*/Seek_Stats, 4096}};

        public static int GetSize(string kName) => _size[kName];
    }

    public class Wanzer
    {
        static byte[]? _stats;
        static byte[]? _model;
        
        public static Span<byte> Stats()
        {
            if (_stats == null)
                return _stats = new byte[ObjectSize.GetSize(ObjectSize.Stats_Entity)];

            return _stats.AsSpan();
        }
        
        public static Span<byte> Model()
        {
            if (_model == null)
                return _model = new byte[ObjectSize.GetSize(ObjectSize.Model_Entity)];

            return _model.AsSpan();
        }
    }

    public class MyGameInfo
    {
        public ref struct GetInfo
        {

            /// <summary>
            /// GameName.Slice(0,14), GamePublisher.Slice(14,11), GameCreation_1.Slice(25,9), GameCreation_2.Slice(34,9)
            /// </summary>
            public ReadOnlySpan<byte> GameInfoData = new(new byte[43]
            {
                0x46, 0x52, 0x4F, 0x4E, 0x54, 0x5F, 0x4D, 0x49, 0x53, 0x53, 0x49, 0x4F, 0x4E, 0x35,   // game name byte. Slice(0,14)
                0x53, 0x51, 0x55, 0x41, 0x52, 0x45, 0x20, 0x45, 0x4E, 0x49, 0x58,   // game Publisher Byte. Slice(14,11)
                0x32, 0x30, 0x30, 0x35, 0x31, 0x31, 0x32, 0x37, 0x32,   // game GameCreation Date Byte. Slice(25,9)
                0x32, 0x30, 0x30, 0x36, 0x30, 0x32, 0x31, 0x36, 0x32    // game GameCreation Date Byte. Slice(34,9)
            });

            public GetInfo() { }
        }

        public static readonly List<long> InfoLocations = new() { GameName_ExeLocation, Publisher_ExeLocation, CreationDate_ExeLocation };
        private const long GameName_ExeLocation = 0x8028;
        private const long Publisher_ExeLocation = 0x813E;
        private const long CreationDate_ExeLocation = 0x832D;
    }

    public class HangarPatchInfo
    {
        public static byte[] ReadWritePatch = new byte[PatchSize];
        public static string FilePath = $@"{Directory.GetFiles(Directory.GetCurrentDirectory(), "004B7670 shopFM5a").FirstOrDefault()}";
        public const long HangarOffset_EXE = 0x4B7670;
        public const long NewHangarOffset_File= 0;
        public const long OldHangarOffset_File= 0x430;
        private const int PatchSize = 1072;
    }
}