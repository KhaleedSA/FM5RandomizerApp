using FM5Randomizer.GameEnum;
using FM5Randomizer.GameProperties;
using FM5Randomizer.RandomizerSetting;

namespace FM5Randomizer.GameMethods;

public class RandomEnemy
{
    private const byte none_Explotion = 0;
    private const byte low_Explotion = 0x3B;
    private const byte high_Explotion = 0x44;
    private static readonly List<short> _Explotion = new() {none_Explotion, low_Explotion, high_Explotion };
    public static void RandomEnemyModel(FileStream fs, List<long> enemyAddresses)
    {
        MyDataTable.EnemyId = 0;

        for (int i = 0; i < enemyAddresses.Count; i++)
        {
            MyDataTable.EnemyId++;

            fs.Read(MyDataTable.ReadWriteModel, 0, MyDataTable.ReadWriteModel.Length);
            var enemyName = MyDataTable.ReadWriteModel.Take(24).ToArray();
            var enemyType = MyDataTable.ReadWriteModel.Skip(64).Take(2).ToArray();

            if (!GetUnitValue.IsEmptyString(enemyName))
            {
                if (GetUnitValue.IsNormalEnemy(enemyType, SettingProperties.Randomize_BossModel))
                    MyDataTable.ValidEnemyId.Add(MyDataTable.EnemyId);

                else
                    MyDataTable.InValidEnemyID.Add(MyDataTable.EnemyId);

                if (GetUnitValue.IsNormalEnemy(enemyType))
                {
                    RandomBody(SettingProperties.Randomize_BodyPart);

                    RandomWeapon(SettingProperties.Randomize_Weapons);
                    
                    RandomBackPack(SettingProperties.Randomize_BackPack);
                    
                    fs.Seek(-128, SeekOrigin.Current);
                    fs.Write(MyDataTable.ReadWriteModel, 0, MyDataTable.ReadWriteModel.Length);
                }
            }
        }
        
        var startingAddress = fs.Position = enemyAddresses.FirstOrDefault() + MyDataTable.JumpToStats;

        var entityAddresses = GetObjectValue.GetListOfAddresses(fs, startingAddress, MyDataTable.StatsScriptSize, MyDataTable.StatsEntitySize);

        for (int i = 0; i < entityAddresses.Count; i++)
            RandomStats.RandomEnemyStats(fs);

        MyDataTable.ValidEnemyId.Clear();
        MyDataTable.InValidEnemyID.Clear();
    }

    private static void RandomBody(bool enable)
    {
        if (!enable)
            return;

        MyDataTable.ReadWriteModel.SetValue(GetObjectValue.RandomBodyID<PartsID.SpecialHeadID>(), 68);
        MyDataTable.ReadWriteModel.SetValue(GetObjectValue.RandomBodyID<PartsID.HandsID>(), 70);
        MyDataTable.ReadWriteModel.SetValue(GetObjectValue.RandomBodyID<PartsID.HandsID>(), 72);
        MyDataTable.ReadWriteModel.SetValue(GetObjectValue.RandomBodyID<PartsID.LegsID>(), 74);
    }

    private static void RandomBackPack(bool enable)
    {
        if (!enable)
            return;

        MyDataTable.ReadWriteModel.SetValue(GetObjectValue.BackPack(), 76);
    }

    private static void RandomWeapon(bool enable)
    {
        if (!enable)
            return;

        byte leftArm = MyDataTable.ReadWriteModel.ElementAt(78);
        byte rightArm = MyDataTable.ReadWriteModel.ElementAt(80);
        byte leftShoulder = MyDataTable.ReadWriteModel.ElementAt(82);
        byte rightShoulder = MyDataTable.ReadWriteModel.ElementAt(84);


        SetWeaponLeftArm(leftArm);
        SetWeaponRightArm(rightArm);
        SetWeaponShoulder(leftShoulder, rightShoulder);
    }

    private static void SetWeaponLeftArm(byte leftArm)
    {
        // FireArm left Weapon
        if (leftArm >= 0x01 && leftArm <= 0x42 || leftArm >= 0x5B && leftArm <= 0x7E || leftArm == 0x97)
        {
            MyDataTable.ReadWriteModel.SetValue(GetObjectValue.FireArm_Weapon(), 78);
            MyDataTable.ReadWriteModel.SetValue((byte)0, 79);
            return;
        }

        // CloseCombat left Weapon
        if (leftArm >= 0x43 && leftArm <= 0x5A || leftArm >= 0x7F && leftArm <= 0x96)
        {
            MyDataTable.ReadWriteModel.SetValue(GetObjectValue.CloseCombat_Weapon(), 78);
            MyDataTable.ReadWriteModel.SetValue((byte)0, 79);
            return;
        }
    }

    private static void SetWeaponRightArm(byte rightArm)
    {
        byte? checkValue = (byte?)MyDataTable.ReadWriteModel.GetValue(81);

        // exit if unit already has an explotion set.
        if (_Explotion.Contains(rightArm) && checkValue == 1)
            return;

        // explotion on right Weapon if true in user setting
        if (rightArm == 0 && SettingProperties.Explode_OnKill)
        {
            byte explotion = (byte)_Explotion[MyDataTable.Rnd.Next(_Explotion.Count)];

            if (explotion == 0)
            {
                MyDataTable.ReadWriteModel.SetValue(explotion, 80);
                MyDataTable.ReadWriteModel.SetValue((byte)0, 81);
                return;
            }

            MyDataTable.ReadWriteModel.SetValue(explotion, 80);
            MyDataTable.ReadWriteModel.SetValue((byte)1, 81);
            return;
        }

        // FireArm right Weapon
        if (rightArm >= 0x01 && rightArm <= 0x42 || rightArm >= 0x5B && rightArm <= 0x7E || rightArm == 0x97)
        {
            MyDataTable.ReadWriteModel.SetValue(GetObjectValue.FireArm_Weapon(), 80);
            MyDataTable.ReadWriteModel.SetValue((byte)0, 81);
        }

        // CloseCombat right Weapon
        else if (rightArm >= 0x43 && rightArm <= 0x5A || rightArm >= 0x7F && rightArm <= 0x96)
        {
            MyDataTable.ReadWriteModel.SetValue(GetObjectValue.CloseCombat_Weapon(), 80);
            MyDataTable.ReadWriteModel.SetValue((byte)0, 81);
        }
    }

    private static void SetWeaponShoulder(byte leftShoulder, byte rightShoulder)
    {
        // Launcher left shoulder weapon
        if (leftShoulder >= 0x01 && leftShoulder <= 0x2A)
        {
            MyDataTable.ReadWriteModel.SetValue(GetObjectValue.Launcher_Weapon(), 82);
            MyDataTable.ReadWriteModel.SetValue((byte)0, 83);
        }

        // Launcher right shoulder weapon
        else if (rightShoulder >= 0x01 && rightShoulder <= 0x2A)
        {
            MyDataTable.ReadWriteModel.SetValue(GetObjectValue.Launcher_Weapon(), 84);
            MyDataTable.ReadWriteModel.SetValue((byte)0, 85);
        }
    }
}