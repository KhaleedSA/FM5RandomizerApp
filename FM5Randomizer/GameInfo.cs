using static FM5Randomizer.GameProperties.MyDataTable;

namespace FM5Randomizer;

public class GameInfo
{
    private static byte[] readGameName = new byte[14];
    private static byte[] readGameCreationDate = new byte[9];
    private static byte[] readPublisher = new byte[11];

    /// <summary>
    /// Read .Iso game and check three boolean value. 'Game Name', 'Creation Date', 'Publish Date'.
    /// </summary>
    /// <param name="fs">File destination to read and write from it</param>
    /// <returns>'true' if game has been found</returns>
    public static bool IsValidGame(FileStream fs)
    {
        MyGameInfo.GetInfo gameInfo = new();

        bool gameFound = false;
        bool creationDateFound = false;
        bool publisherFound = false;

        // if 'Game Name byte[]' and ' Creation date byte[]' and 'Publish date byte[]' Element index[0] are equal to Zero, Then it's an empty array.
        if (readGameName[0] == 0 && readGameCreationDate[0] == 0 && readPublisher[0] == 0)
        {
            // Read byte[] and store new data.
            ReadInfo(fs, readGameName, MyGameInfo.InfoLocations[0]);
            ReadInfo(fs, readGameCreationDate, MyGameInfo.InfoLocations[1]);
            ReadInfo(fs, readPublisher, MyGameInfo.InfoLocations[2]);
        }

        // if 'Game Name byte[]' equal to fixed array in MyGameInfo class and the 'gameFound' flag is false, then 'gameFound' flag well be true.
        if (readGameName.SequenceEqual(gameInfo.GameNameByte[..14].ToArray()) && !gameFound)
        {
            gameFound = true;
        }

        // if 'Creation Date byte[]' equal to fixed array in MyGameInfo class and the 'creationDateFound' flag is false, then 'creationDateFound' flag well be true.
        if (readGameCreationDate.SequenceEqual(gameInfo.GameCreationDateByte_1[..9].ToArray()) ||
            readGameCreationDate.SequenceEqual(gameInfo.GameCreationDateByte_2[..9].ToArray()) && !creationDateFound)
        {
            creationDateFound = true;
        }

        // if 'Publish Date byte[]' equal to fixed array in MyGameInfo class and the 'publisherFound' flag is false, then 'publisherFound' flag well be true.
        if (readPublisher.SequenceEqual(gameInfo.PublisherByte[..11].ToArray()) && !publisherFound)
        {
            publisherFound = true;
        }

        // return true for all three flags, otherwise false => Game data is different 
        return gameFound && creationDateFound && publisherFound ? true : false;
    }

    /// <summary>
    /// Read from File Stream and store the data to the provided byte array.
    /// </summary>
    /// <param name="fs">File destination to read and write from it</param>
    /// <param name="data">The byte array data to store the values to it</param>
    /// <param name="location">The offset of the data in the current Stream</param>
    private static void ReadInfo(FileStream fs, byte[] data, long location)
    {
        if (data[0] == 0)
        {
            fs.Seek(location, SeekOrigin.Begin);
            fs.Read(data, 0, data.Length);
        }
    }
}