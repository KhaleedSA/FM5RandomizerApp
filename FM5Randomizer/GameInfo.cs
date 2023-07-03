using FM5Randomizer.GameProperties;

namespace FM5Randomizer;

public class GameInfo
{
    private static byte[] readGameName = new byte[MyDataTable.MyGameInfo.GameNameByte.Length];
    private static byte[] readGameCreationDate = new byte[MyDataTable.MyGameInfo.GameCreationDateByte_1.Length];
    private static byte[] readPublisher = new byte[MyDataTable.MyGameInfo.PublisherByte.Length];
    public static bool IsValidGame(FileStream fs)
    {
        bool gameFound = false;
        bool creationDateFound = false;
        bool publisherFound = false;

        if (readGameName[0] == 0 && readGameName[0] == 0 && readPublisher[0] == 0)
        {
            ReadInfo(fs, readGameName, MyDataTable.MyGameInfo.InfoLocations[0]);
            ReadInfo(fs, readGameCreationDate, MyDataTable.MyGameInfo.InfoLocations[1]);
            ReadInfo(fs, readPublisher, MyDataTable.MyGameInfo.InfoLocations[2]);
        }

        if (readGameName.SequenceEqual(MyDataTable.MyGameInfo.GameNameByte) && !gameFound)
        {
            gameFound = true;
        }

        if (readGameCreationDate.SequenceEqual(MyDataTable.MyGameInfo.GameCreationDateByte_1) ||
            readGameCreationDate.SequenceEqual(MyDataTable.MyGameInfo.GameCreationDateByte_2) && !creationDateFound)
        {
            creationDateFound = true;
        }

        if (readPublisher.SequenceEqual(MyDataTable.MyGameInfo.PublisherByte) && !publisherFound)
        {
            publisherFound = true;
        }

        return gameFound && creationDateFound && publisherFound ? true : false;
    }

    private static void ReadInfo(FileStream fs, byte[] data, long location)
    {
        if (data[0] == 0)
        {
            fs.Seek(location, SeekOrigin.Begin);
            fs.Read(data, 0, data.Length);
        }
    }
}