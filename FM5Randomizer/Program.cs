using FM5Randomizer.GameEnum;
using FM5Randomizer.GameMethods;
using FM5Randomizer.GameProperties;
using FM5Randomizer.RandomizerSetting;

string? path = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.iso").FirstOrDefault();

using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
{
    UserSetting.ReadWriteSetting(Directory.GetCurrentDirectory());
    Array addresses = Enum.GetValues(typeof(Stage.StageAddress));

    foreach (long address in addresses)
    {
        MyRandomize.GameRandom(fs, GetObjectValue.GetListOfAddresses(fs, address, MyDataTable.ModelScriptSize, MyDataTable.ModelEntitySize));
    }
}