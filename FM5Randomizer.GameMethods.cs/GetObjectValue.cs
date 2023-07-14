using FM5Randomizer.GameEnum;
using FM5Randomizer.GameProperties;

namespace FM5Randomizer.GameMethods;

public class GetObjectValue
{
    public static readonly List<byte> _weaponItemsID = new();

    /// <summary>
    /// Get Random model ID
    /// </summary>
    /// <param name="ModelsID"> List of Models ID's</param>
    /// <returns>Random model id</returns>
    public static byte RandomModelID(List<byte> ModelsID) => ModelsID[(byte)MyDataTable.Rnd.Next(ModelsID.Count)];

    /// <summary>
    /// Get List Enemies Addresses from all stages.
    /// </summary>
    /// <param name="fs">File destination to read and write from it</param>
    /// <param name="currentAddress">The First address for the stage</param>
    /// <param name="scriptSize">script size to calculate the size of the scipt</param>
    /// <param name="entitySize">entity size of the enemy</param>
    /// <returns>List of enemies addresses</returns>
    public static List<long> GetListOfAddresses(FileStream fs, long currentAddress, int scriptSize, int entitySize)
    {
        List<long> addressesList = new();

        long start = fs.Position = currentAddress;

        for (int i = 0; i < scriptSize / entitySize; i++)
            addressesList.Add(start + entitySize * i);

        return addressesList;
    }

    /// <summary>
    /// Get Random Wanzer Body parts ID
    /// </summary>
    /// <typeparam name="T">T is the Enum parts ID's</typeparam>
    /// <returns>Random value of the given 'T' </returns>
    public static T RandomBodyID<T>()
    {
        List<T> values = new();
        values.AddRange((IEnumerable<T>)Enum.GetValues(typeof(PartsID.BodyID)));
        values.AddRange((IEnumerable<T>)Enum.GetValues(typeof(T)));

        return values[MyDataTable.Rnd.Next(values.Count)];
    }

    /// <summary>
    /// Get Random Wanzer Body parts ID
    /// </summary>
    /// <returns>Random value of the given 'PartsID.BodyID' </returns>
    public static PartsID.BodyID RandomBodyID()
    {
        List<PartsID.BodyID> values = new();
        values.AddRange((IEnumerable<PartsID.BodyID>)Enum.GetValues(typeof(PartsID.BodyID)));
        
        return values[MyDataTable.Rnd.Next(values.Count)];
    }

    /// <summary>
    /// Get Random BackPack ID
    /// </summary>
    /// <returns>Random BackPack id</returns>
    public static byte BackPack()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Support.BackPackID)));
        
        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }

    /// <summary>
    /// Get Random Shoulder Weapon ID
    /// </summary>
    /// <returns>Random Shoulder Weapon id</returns>
    public static byte Launcher_Weapon()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Launcher.MissileID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Launcher.GrenadeID)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Launcher.RocketID)));

        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }

    /// <summary>
    /// Get Random Fire arm Weapon ID
    /// </summary>
    /// <returns>Random Fire arm Weapon id</returns>
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

    /// <summary>
    /// Get Random Item ID
    /// </summary>
    /// <returns>Random Item id</returns>
    public static byte Repair_Ammo()
    {
        _weaponItemsID.Clear();
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Support.ItemAmmo)));
        _weaponItemsID.AddRange((IEnumerable<byte>)Enum.GetValues(typeof(WeaponAndItemID.Support.ItemRepair)));

        return _weaponItemsID[MyDataTable.Rnd.Next(_weaponItemsID.Count)];
    }

    /// <summary>
    /// Get Random Close Combat Weapon ID
    /// </summary>
    /// <returns>Random Close Combat Weapon id</returns>
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
