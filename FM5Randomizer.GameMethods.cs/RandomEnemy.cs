using FM5Randomizer.GameEnum;
using FM5Randomizer.GameProperties;
using static FM5Randomizer.GameProperties.MyDataTable;
using FM5Randomizer.RandomizerSetting;

namespace FM5Randomizer.GameMethods;

public class RandomEnemy
{
    private const byte none_Explotion = 0;
    private const byte low_Explotion = 0x3B;
    private const byte high_Explotion = 0x44;

    private static readonly List<short> _Explotion = new() {none_Explotion, low_Explotion, high_Explotion };

    public static void RandomWanzerModel(FileStream fs, List<long> enemyAddresses)
    {
        MyDataTable.EnemyId = 0;

        for (int i = 0; i < enemyAddresses.Count; i++)
        {
            MyDataTable.EnemyId++;

            fs.Seek(enemyAddresses[i], SeekOrigin.Begin);

            fs.Read(Wanzer.Model());

            if (!GetUnitValue.IsEmptyNameModel(Wanzer.Model().Slice(0, 24)))
            {
                if (GetUnitValue.EnemyType(Wanzer.Model().Slice(64, 2)) && SettingProperties.Randomize_BossModel)
                    MyDataTable.ValidEnemyId.Add(MyDataTable.EnemyId);

                else
                    MyDataTable.InValidEnemyID.Add(MyDataTable.EnemyId);

                if (GetUnitValue.EnemyType(Wanzer.Model().Slice(64, 2)))
                {
                    RandomBody(SettingProperties.Randomize_BodyPart);

                    RandomWeapon(SettingProperties.Randomize_Weapons);

                    RandomBackPack(SettingProperties.Randomize_BackPack);

                    fs.Seek(enemyAddresses[i], SeekOrigin.Begin);
                    fs.Write(Wanzer.Model());
                }
            }
        }
        
        var startingAddress = fs.Position = enemyAddresses.FirstOrDefault() + ObjectSize.GetSize(ObjectSize.Seek_Stats);

        var entityAddresses = GetObjectValue.GetListOfAddresses(fs, startingAddress, ObjectSize.GetSize(ObjectSize.Stats_Script), ObjectSize.GetSize(ObjectSize.Stats_Entity));

        for (int i = 0; i < entityAddresses.Count; i++)
            RandomStats.RandomEnemyStats(fs);

        MyDataTable.ValidEnemyId.Clear();
        MyDataTable.InValidEnemyID.Clear();
    }

    private static void RandomBody(bool enable)
    {
        if (!enable)
            return;

        // Randomize Head part
        Wanzer.Model()[68] = (byte)GetObjectValue.RandomBodyID<PartsID.SpecialHeadID>();

        // Randomize left hand part
        if (Wanzer.Model()[70] == 0)
            Wanzer.Model()[70] = (byte)GetObjectValue.RandomBodyID<PartsID.SpecialHandsID>();

        else
            Wanzer.Model()[70] = (byte)GetObjectValue.RandomBodyID();
        
        // Randomize right hand part
        if (Wanzer.Model()[72] == 0)
            Wanzer.Model()[72] = (byte)GetObjectValue.RandomBodyID<PartsID.SpecialHandsID>();

        else
            Wanzer.Model()[72] = (byte)GetObjectValue.RandomBodyID();

        // Randomize leg part
        Wanzer.Model()[74] = (byte)GetObjectValue.RandomBodyID<PartsID.LegsID>();
    }

    private static void RandomBackPack(bool enable)
    {
        if (!enable)
            return;
        Wanzer.Model()[76] = GetObjectValue.BackPack();
    }

    private static void RandomWeapon(bool enable)
    {
        if (!enable)
            return;

        byte leftArm = Wanzer.Model()[78];
        byte rightArm = Wanzer.Model()[80];
        byte leftShoulder = Wanzer.Model()[82];
        byte rightShoulder = Wanzer.Model()[84];


        SetWeaponLeftArm(leftArm);
        SetWeaponRightArm(rightArm);
        SetWeaponShoulder(leftShoulder, rightShoulder);
    }

    private static void SetWeaponLeftArm(byte leftArm)
    {
        // FireArm left Weapon
        if (leftArm >= 0x01 && leftArm <= 0x42 || leftArm >= 0x5B && leftArm <= 0x7E || leftArm == 0x97)
        {
            Wanzer.Model()[78] = GetObjectValue.FireArm_Weapon();
            Wanzer.Model()[79] = 0;
        }

        // CloseCombat left Weapon
        else if (leftArm >= 0x43 && leftArm <= 0x5A || leftArm >= 0x7F && leftArm <= 0x96)
        {
            Wanzer.Model()[78] = GetObjectValue.CloseCombat_Weapon();
            Wanzer.Model()[79] = 0;
        }
    }

    private static void SetWeaponRightArm(byte rightArm)
    {
        // exit if unit already has an explotion set.
        if (_Explotion.Contains(rightArm) && Wanzer.Model()[81] == 1)
            return;

        // explotion on right Weapon if true in user setting
        if (rightArm == 0 && SettingProperties.Explode_OnKill)
        {
            byte explotion = (byte)_Explotion[MyDataTable.Rnd.Next(_Explotion.Count)];

            if (explotion != 0)
            {
                Wanzer.Model()[80] = explotion;
                Wanzer.Model()[81] = 1;
                return;
            }

            Wanzer.Model()[80] = explotion;
            Wanzer.Model()[81] = 0;
            return;
        }

        // FireArm right Weapon
        if (rightArm >= 0x01 && rightArm <= 0x42 || rightArm >= 0x5B && rightArm <= 0x7E || rightArm == 0x97)
        {
            Wanzer.Model()[80] = GetObjectValue.FireArm_Weapon();
            Wanzer.Model()[81] = 0;
        }

        // CloseCombat right Weapon
        else if (rightArm >= 0x43 && rightArm <= 0x5A || rightArm >= 0x7F && rightArm <= 0x96)
        {
            Wanzer.Model()[80] = GetObjectValue.CloseCombat_Weapon();
            Wanzer.Model()[81] = 0;
        }
    }

    private static void SetWeaponShoulder(byte leftShoulder, byte rightShoulder)
    {
        // Launcher left shoulder weapon
        if (leftShoulder >= 0x01 && leftShoulder <= 0x2A)
        {
            MyDataTable.Wanzer.Model()[82] = GetObjectValue.Launcher_Weapon();
            MyDataTable.Wanzer.Model()[83] = 0;
        }

        // Launcher right shoulder weapon
        else if (rightShoulder >= 0x01 && rightShoulder <= 0x2A)
        {
            MyDataTable.Wanzer.Model()[84] = GetObjectValue.Launcher_Weapon();
            MyDataTable.Wanzer.Model()[85] = 0;
        }
    }
}