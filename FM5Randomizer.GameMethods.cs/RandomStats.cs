using FM5Randomizer.GameProperties;
using FM5Randomizer.RandomizerSetting;

namespace FM5Randomizer.GameMethods;

public class RandomStats
{
    private static byte[] ReadOldCoords = new byte[2];
    private static byte[] ReadNewCoords = new byte[2];
    public static void RandomEnemyStats(FileStream fs)
    {
        fs.Read(MyDataTable.ReadWriteStats, 0, MyDataTable.ReadWriteStats.Length);

        if (!MyDataTable.ReadWriteStats.ElementAt(0).Equals(0) && !MyDataTable.InValidEnemyID.Contains(MyDataTable.ReadWriteStats.ElementAt(1)))
        {
            WriteNewEnemyStats();
            fs.Seek(-256, SeekOrigin.Current);
            fs.Write(MyDataTable.ReadWriteStats, 0, MyDataTable.ReadWriteStats.Length);
        }

        Array.Clear(MyDataTable.ReadWriteStats, 0, MyDataTable.ReadWriteStats.Length);
    }

    private static void WriteNewEnemyStats()
    {
        // Fix potential soft-Lock!!
        Array.Clear(ReadOldCoords);
        Array.Clear(ReadNewCoords);
        FixCoordinate();

        // Randomize pilot model
        if (SettingProperties.Randomize_UnitModel || SettingProperties.Randomize_BossModel)
            MyDataTable.ReadWriteStats.SetValue(GetObjectValue.RandomModelID(MyDataTable.ValidEnemyId), 1);

        // Randomize pilot lvl
        if (SettingProperties.Randomize_PilotLvl/* && !SettingProperties.PilotLvl_SamePlayer*/)
            MyDataTable.ReadWriteStats.SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinPilotLvl, MyDataTable.MaxPilotLvl), 30);

        // Randomize Pilot Body Weapons Lvl
        if (SettingProperties.Randomize_WeaponsLvl)
        {
            MyDataTable.ReadWriteStats.SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinLvl, MyDataTable.MaxLvl), 93);

            for (int i = 0; i < 2; i++)
                MyDataTable.ReadWriteStats.SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinLvl, MyDataTable.MaxLvl), 96 + i);
        }

        // Randomize Pilot Skills
        if (SettingProperties.Randomize_Skills)
        {
            for (int i = 0; i < 16; i++)
                MyDataTable.ReadWriteStats.SetValue((byte)MyDataTable.Rnd.Next(0, 100), 192 + i);
        }

        // Randomize Pilot Items
        if (SettingProperties.Randomize_Items)
        {
            for (int i = 0; i < 8; i++)
                MyDataTable.ReadWriteStats.SetValue(GetObjectValue.Repair_Ammo(), 208 + i);
        }
    }

    private static void FixCoordinate()
    {
        byte? enemyCoordinate_X = (byte?)MyDataTable.ReadWriteStats.GetValue(18);
        byte? enemyCoordinate_Y = (byte?)MyDataTable.ReadWriteStats.GetValue(19);
        ReadOldCoords.SetValue(enemyCoordinate_X, 0);
        ReadOldCoords.SetValue(enemyCoordinate_Y, 1);
        ReadNewCoords = SoftLockFixer.SetNew_Coordinates(MyDataTable.ReadStageAddress, ReadOldCoords);
        MyDataTable.ReadWriteStats.SetValue(ReadNewCoords.ElementAt(0), 18);
        MyDataTable.ReadWriteStats.SetValue(ReadNewCoords.ElementAt(1), 19);
    }
}
