using FM5Randomizer.GameProperties;

namespace FM5Randomizer.GameMethods;

public class HangerPatch
{
    public static void EnableHangerPatch(FileStream fs, bool enable)
    {
        ReadHangerPatch(enable);
        fs.Position = MyDataTable.HangerPatch.HangerOffset_EXE;

        fs.Write(MyDataTable.HangerPatch.ReadWritePatch, 0, MyDataTable.HangerPatch.ReadWritePatch.Length);
    }

    private static void ReadHangerPatch(bool enable)
    {
        using(FileStream fs = new(MyDataTable.HangerPatch.FilePath, FileMode.Open, FileAccess.Read))
        {
            if (enable)
            {
                Array.Clear(MyDataTable.HangerPatch.ReadWritePatch);
                fs.Position = MyDataTable.HangerPatch.NewHangerOffset_File;
                fs.Read(MyDataTable.HangerPatch.ReadWritePatch, 0, MyDataTable.HangerPatch.ReadWritePatch.Length);
                fs.Close();
                _ = MyDataTable.HangerPatch.ReadWritePatch;
                return;
            }

            Array.Clear(MyDataTable.HangerPatch.ReadWritePatch);
            fs.Position = MyDataTable.HangerPatch.OldHangerOffset_File;
            fs.Read(MyDataTable.HangerPatch.ReadWritePatch, 0, MyDataTable.HangerPatch.ReadWritePatch.Length);
            fs.Close();
            _ = MyDataTable.HangerPatch.ReadWritePatch;

            fs.Close ();
        }
    }
}