using static FM5Randomizer.GameProperties.MyDataTable;

namespace FM5Randomizer;

public class GameInfo
{
    private static byte[] buffer = new byte[14];

    /// <summary>
    /// Read .Iso game and check three boolean value. 'Game Name', 'Creation Date', 'Publish Date'.
    /// </summary>
    /// <param name="fs">File destination to read and write from it</param>
    /// <returns>'true' if game has been found</returns>
    public static bool IsValidGame(FileStream fs)
    {
        Span<byte> bufferAsSpan = new(buffer);
        MyGameInfo.GetInfo gameInfo = new();

        // if 'Game Name byte[]' not equal to fixed array in MyGameInfo.MyGameInfo.GetInfo class
        ReadInfo(fs, bufferAsSpan, MyGameInfo.InfoLocations[0]);
        if (!bufferAsSpan.SequenceEqual(gameInfo.GameInfoData[..14]))
            return false;

        // if 'Publish Date byte[]' not equal to fixed array in MyGameInfo.MyGameInfo.GetInfo class
        ReadInfo(fs, bufferAsSpan[..11], MyGameInfo.InfoLocations[1]);
        if (!bufferAsSpan[..11].SequenceEqual(gameInfo.GameInfoData.Slice(14, 11)))
            return false;

        // if 'Creation Date byte[]' equal to fixed array in MyGameInfo.MyGameInfo.GetInfo class
        ReadInfo(fs, bufferAsSpan[..9], MyGameInfo.InfoLocations[2]);
        bool creationDate_1 = bufferAsSpan[..9].SequenceEqual(gameInfo.GameInfoData.Slice(25, 9));
        bool creationDate_2 = bufferAsSpan[..9].SequenceEqual(gameInfo.GameInfoData.Slice(34, 9));

        if (creationDate_1 == true || creationDate_2 == true)
            return true;

        return false;
    }

    /// <summary>
    /// Read from File Stream and store the data to the provided byte array.
    /// </summary>
    /// <param name="fs">File destination to read and write from it</param>
    /// <param name="data">The byte array data to store the values to it</param>
    /// <param name="location">The offset of the data in the current Stream</param>
    private static void ReadInfo(FileStream fs, Span<byte> data, long location)
    {
        fs.Seek(location, SeekOrigin.Begin);
        fs.Read(data);
    }
}