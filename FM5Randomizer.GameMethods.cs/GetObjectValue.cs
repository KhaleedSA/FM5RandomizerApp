using FM5Randomizer.GameEnum;
using FM5Randomizer.GameProperties;

namespace FM5Randomizer.GameMethods;

public class GetObjectValue
{
    private static readonly List<byte> _weaponItemsID = new();

    public static byte RandomModelID(List<byte> ModelsID) => ModelsID[(byte)MyDataTable.Rnd.Next(ModelsID.Count)];

    public static List<long> GetListOfAddresses(FileStream fs, long currentAddress, int scriptSize, int entitySize)
    {
        List<long> addressesList = new();

        long start = fs.Position = currentAddress;

        for (int i = 0; i < scriptSize / entitySize; i++)
            addressesList.Add(start + entitySize * i);

        return addressesList;
    }

    public static T RandomBodyID<T>()
    {
        List<T> values = new();
        values.AddRange((IEnumerable<T>)Enum.GetValues(typeof(PartsID.BodyID)));
        values.AddRange((IEnumerable<T>)Enum.GetValues(typeof(T)));

        return values[MyDataTable.Rnd.Next(values.Count)];
    }

    public static byte BackPack()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Support.BackPackID)));
        
        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }

    public static byte Launcher_Weapon()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Launcher.MissileID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Launcher.GrenadeID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Launcher.RocketID)));

        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }

    public static byte FireArm_Weapon()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.FireArm.MachineGunID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.FireArm.ShotGunID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.FireArm.GatlingGunID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.FireArm.FlameThrowerID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.FireArm.RifleID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.FireArm.BazookaID)));

        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }

    public static byte Repair_Ammo()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Support.ItemAmmo)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Support.ItemRepair)));

        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }
    
    public static byte CloseCombat_Weapon()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.CloseCombat.KnuckleID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.CloseCombat.RodID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.CloseCombat.ShieldID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.CloseCombat.PileBunkerID)));

        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }
}
