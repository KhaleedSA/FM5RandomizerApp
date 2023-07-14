using FM5Randomizer;
using FM5Randomizer.GameEnum;
using FM5Randomizer.GameMethods;
using FM5Randomizer.GameProperties;
using static FM5Randomizer.GameProperties.MyDataTable;
using FM5Randomizer.RandomizerSetting;

string? path = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.iso").FirstOrDefault();

if (path == null)
{
    Console.WriteLine("error: game not found!!");
    Console.ReadKey();
    return;
}

using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
{
    if (!GameInfo.IsValidGame(fs))
    {
        Console.WriteLine("Please make sure you have the right copy of the game!!");
        Console.ReadKey();
        return;
    }

    UserSetting.ReadWriteSetting(Directory.GetCurrentDirectory());

    HangarPatch.EnableHangarPatch(fs, SettingProperties.Enable_HangarPatch);

    Array addresses = Enum.GetValues(typeof(Stage.StageAddress));

    foreach (long address in addresses)
    {
        MyDataTable.ReadStageAddress = address;
        MyRandomize.GameRandom(fs, GetObjectValue.GetListOfAddresses(fs, address, ObjectSize.GetSize(ObjectSize.Model_Script), ObjectSize.GetSize(ObjectSize.Model_Entity)));
    }

    Console.WriteLine("All done...");
    Console.ReadKey();
}
