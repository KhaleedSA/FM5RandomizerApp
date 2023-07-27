using FM5Randomizer.GameEnum;
using FM5Randomizer.GameProperties;
using FM5Randomizer.RandomizerSetting;
using static FM5Randomizer.GameProperties.MyDataTable;

namespace FM5Randomizer.GameMethods;

public class MyRandomize
{
    public static void GameRandom()
    {
        string[] dirPath = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.iso");

        if (dirPath.Length == 0)
        {
            Console.WriteLine("error: Iso file not found!!");
            Console.ReadKey();
            return;
        }

        foreach (var path in dirPath)
        {
            using (FileStream fs = new(path, FileMode.Open, FileAccess.ReadWrite))
            {
                if (GameInfo.IsValidGame(fs))
                {
                    UserSetting.ReadWriteSetting(Directory.GetCurrentDirectory());

                    HangarPatch.EnableHangarPatch(fs, SettingProperties.Enable_HangarPatch);

                    Array addresses = Enum.GetValues(typeof(Stage.StageAddress));

                    foreach (long address in addresses)
                    {
                        MyDataTable.ReadStageAddress = address;
                        RandomEnemy.RandomWanzerModel(fs, GetObjectValue.GetListOfAddresses(fs, address, ObjectSize.GetSize(ObjectSize.Model_Script), ObjectSize.GetSize(ObjectSize.Model_Entity)));
                    }

                    Console.WriteLine("All done...");
                    Console.ReadKey();
                    return;
                }
            }
        }

        Console.WriteLine("Please make sure you have the right version of the game!!");
        Console.ReadKey();
    }
}