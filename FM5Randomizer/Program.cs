using FM5Randomizer;
using FM5Randomizer.GameEnum;
using FM5Randomizer.GameMethods;
using FM5Randomizer.GameProperties;
using FM5Randomizer.RandomizerSetting;


string? path = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.iso").FirstOrDefault();


if (path == null)
{
    Console.WriteLine("error: game not found!!");
    return;
}

using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
{
    //if (!GameInfo.IsValidGame(fs))
    //{
    //    Console.WriteLine("Please make sure you have the right copy of the game!!");
    //    return;
    //}

    UserSetting.ReadWriteSetting(Directory.GetCurrentDirectory());

    HangerPatch.EnableHangerPatch(fs, SettingProperties.Enable_HangarPatch);

    Array addresses = Enum.GetValues(typeof(Stage.StageAddress));

    foreach (long address in addresses)
    {
        MyRandomize.GameRandom(fs, GetObjectValue.GetListOfAddresses(fs, address, MyDataTable.ModelScriptSize, MyDataTable.ModelEntitySize));
    }

    Console.WriteLine("All done...");
    Console.ReadKey();
}