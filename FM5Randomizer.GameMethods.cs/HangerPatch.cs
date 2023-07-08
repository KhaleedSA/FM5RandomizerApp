using static FM5Randomizer.GameProperties.MyDataTable;

namespace FM5Randomizer.GameMethods;

public class HangarPatch
{
    /// <summary>
    /// Enable Hangar patch by reading the data from the file and writing the new Hangar to the file, optionally.
    /// </summary>
    /// <param name="fs">The file destination to read and write from it</param>
    /// <param name="enable">To check if the user setting is enabled or disabled</param>
    public static void EnableHangarPatch(FileStream fs, bool enable)
    {
        Span<byte> buffer = new(HangarPatchInfo.ReadWritePatch);

        ReadHangarPatch(enable, buffer);

        fs.Position = HangarPatchInfo.HangarOffset_EXE;
        fs.Write(buffer);
    }

    /// <summary>
    /// This will read the data from Hangar patch file, the default Hangar and the modified Hangar.
    /// </summary>
    /// <param name="enable">To check if the user setting is enabled or disabled</param>
    /// <param name="buffer">To read and write Hangar patch data</param>
    private static void ReadHangarPatch(bool enable, Span<byte> buffer)
    {
        using (FileStream fs = new(HangarPatchInfo.FilePath, FileMode.Open, FileAccess.Read))
        {
            if (enable)
            {
                fs.Position = HangarPatchInfo.NewHangarOffset_File;
                fs.Read(buffer);
                return;
            }

            fs.Position = HangarPatchInfo.OldHangarOffset_File;
            fs.Read(buffer);
        }
    }
}