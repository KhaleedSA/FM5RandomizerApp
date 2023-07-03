using FM5Randomizer.GameProperties;
using FM5Randomizer.RandomizerSetting;

namespace FM5Randomizer.GameMethods;

public class RandomStats
{
    private static byte[] ReadOldCoords = new byte[2];
    private static byte[] ReadNewCoords = new byte[2];
    public static void RandomEnemyStats(FileStream fs)
    {
        fs.Read(MyDataTable.Wanzer.Stats(), 0, MyDataTable.Wanzer.Stats().Length);

        if (!MyDataTable.Wanzer.Stats().ElementAt(0).Equals(0) && !MyDataTable.InValidEnemyID.Contains(MyDataTable.Wanzer.Stats().ElementAt(1)))
        {
            WriteNewEnemyStats();
            fs.Seek(-256, SeekOrigin.Current);
            fs.Write(MyDataTable.Wanzer.Stats(), 0, MyDataTable.Wanzer.Stats().Length);
        }

        Array.Clear(MyDataTable.Wanzer.Stats(), 0, MyDataTable.Wanzer.Stats().Length);
    }

    private static void WriteNewEnemyStats()
    {
        // Fix potential soft-Lock!!
        Array.Clear(ReadOldCoords);
        Array.Clear(ReadNewCoords);
        FixCoordinate();

        // Randomize Wanzer Health Value
        if (SettingProperties.Randomize_HealthValue)
        {
            MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinHealth, MyDataTable.MaxHealth), 8);
            MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinHealth, MyDataTable.MaxHealth), 10);
            MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinHealth, MyDataTable.MaxHealth), 12);
            MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinHealth, MyDataTable.MaxHealth), 14);

        } 
        
        // Randomize Wanzer Health Value
        if (!SettingProperties.Randomize_HealthValue)
        {
            MyDataTable.Wanzer.Stats().SetValue((byte)100, 8);
            MyDataTable.Wanzer.Stats().SetValue((byte)100, 10);
            MyDataTable.Wanzer.Stats().SetValue((byte)100, 12);
            MyDataTable.Wanzer.Stats().SetValue((byte)100, 14);

        }

        // Randomize pilot model
        if (SettingProperties.Randomize_UnitModel || SettingProperties.Randomize_BossModel)
            MyDataTable.Wanzer.Stats().SetValue(GetObjectValue.RandomModelID(MyDataTable.ValidEnemyId), 1);

        // Randomize pilot lvl
        if (SettingProperties.Randomize_PilotLvl)
            MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinPilotLvl, MyDataTable.MaxPilotLvl), 30);

        // Randomize Pilot Body Weapons Lvl
        if (SettingProperties.Randomize_EquipmentsLvl)
        {
            MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinLvl, MyDataTable.MaxLvl), 93);

            for (int i = 0; i < 2; i++)
                MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(MyDataTable.MinLvl, MyDataTable.MaxLvl), 96 + i);
        }

        // Randomize Pilot Skills
        if (SettingProperties.Randomize_Skills)
        {
            for (int i = 0; i < 16; i++)
                MyDataTable.Wanzer.Stats().SetValue((byte)MyDataTable.Rnd.Next(0, 100), 192 + i);
        }

        // Randomize Pilot Items
        if (SettingProperties.Randomize_Items)
        {
            for (int i = 0; i < 8; i++)
                MyDataTable.Wanzer.Stats().SetValue(GetObjectValue.Repair_Ammo(), 208 + i);
        }
    }

    /// <summary>
    /// Fix potential soft-Lock or out of bounds in some stages.
    /// </summary>
    private static void FixCoordinate()
    {
        // Get the enemy's current coordinates.
        byte? enemyCoordinate_X = (byte?)MyDataTable.Wanzer.Stats().GetValue(18);
        byte? enemyCoordinate_Y = (byte?)MyDataTable.Wanzer.Stats().GetValue(19);

        // Store the old coordinates.
        ReadOldCoords?.SetValue(enemyCoordinate_X, 0);
        ReadOldCoords?.SetValue(enemyCoordinate_Y, 1);

        // Get the new coordinates.
        ReadNewCoords = SoftLockFixer.SetNew_Coordinates(MyDataTable.ReadStageAddress, ReadOldCoords);

        // Write the new Coordinates.
        MyDataTable.Wanzer.Stats().SetValue(ReadNewCoords.ElementAt(0), 18);
        MyDataTable.Wanzer.Stats().SetValue(ReadNewCoords.ElementAt(1), 19);
    }
}