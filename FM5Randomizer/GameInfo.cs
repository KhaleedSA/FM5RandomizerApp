using FM5Randomizer.GameProperties;

namespace FM5Randomizer;

public class GameInfo
{
    
    public static bool IsValidGame(FileStream fs)
    {
        byte[] data = Array.Empty<byte>();
        bool gameName = false;
        bool creationDate = false;
        bool publisher = false;

        fs.Position = MyDataTable.MyGameInfo.GameName_Exe;

        data.SetValue(fs.Read(MyDataTable.MyGameInfo.ReadInfoBytes, 0, MyDataTable.MyGameInfo.GameNameByte.Length), 0);

        if (data.SequenceEqual(MyDataTable.MyGameInfo.ReadInfoBytes))
        {
            gameName = true;
            Array.Clear(data);
            Array.Clear(MyDataTable.MyGameInfo.ReadInfoBytes);
        }

        return (gameName && creationDate && publisher ? true : false);
    }
}