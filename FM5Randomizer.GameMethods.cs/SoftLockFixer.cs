using FM5Randomizer.GameEnum;

namespace FM5Randomizer.GameMethods;

public class SoftLockFixer
{
    private class Coordinates
    {
        public byte Coord_X;
        public byte Coord_Y;
        public Coordinates(byte x, byte y)
        {
            Coord_X = x;
            Coord_Y = y;
        }
    }

    private static readonly byte[] _NewCoord = new byte[2];
    private static readonly Dictionary<byte, Coordinates> _PotentialSoftLocks = new();
    private static readonly Dictionary<byte, Coordinates> _FixSoftLocks = new();

    /// <summary>
    /// Retrun new Coordinates for some stages.
    /// </summary>
    /// <param name="stageAddress"> Stage address where there potential soft-lock are.</param>
    /// <param name="coords">Old Coordinates to match the soft-lock list</param>
    /// <returns>New coordinates. [X, Y]</returns>
    public static byte[] SetNew_Coordinates(long stageAddress, byte[] coords)
    {
        _PotentialSoftLocks.Clear();
        _FixSoftLocks.Clear();
        Array.Clear(_NewCoord);

        return stageAddress switch
        {
            (long)Stage.StageAddress.ST04 => FixStage04(coords),
            (long)Stage.StageAddress.ST06 => FixStage06(coords),
            (long)Stage.StageAddress.ST07 => FixStage07(coords),
            (long)Stage.StageAddress.ST11 => FixStage11(coords),
            (long)Stage.StageAddress.ST17 => FixStage17(coords),
            (long)Stage.StageAddress.ST19 => FixStage19(coords),
            (long)Stage.StageAddress.ST23 => FixStage23(coords),
            (long)Stage.StageAddress.ST44 => FixStage44(coords),
            (long)Stage.StageAddress.ST45 => FixStage45(coords),
            (long)Stage.StageAddress.ST49 => FixStage49(coords),
            (long)Stage.StageAddress.ST87 => FixStage04(coords),
            (long)Stage.StageAddress.ST89 => FixStage06(coords),
            (long)Stage.StageAddress.ST90 => FixStage07(coords),
            (long)Stage.StageAddress.ST94 => FixStage11(coords),
            (long)Stage.StageAddress.ST100 => FixStage17(coords),
            (long)Stage.StageAddress.ST102 => FixStage19(coords),
            (long)Stage.StageAddress.ST106 => FixStage23(coords),
            (long)Stage.StageAddress.ST118 => FixStage44(coords),
            (long)Stage.StageAddress.ST128 => FixStage45(coords),
            (long)Stage.StageAddress.ST132 => FixStage49(coords),
            _ => coords,
        };
    }

    /// <summary>
    /// Fix Coordinates by cheking old coordinates with potential SoftLocks list
    /// </summary>
    /// <param name="potentialSoftLocks">Potential SoftLocks coordinates list</param>
    /// <param name="fixSoftLocks">New coordinates list</param>
    /// <param name="coords">Old Coordinates to match the soft-lock list</param>
    /// <returns>New modified coordinates</returns>
    private static byte[] Coordinates_Fixer(Dictionary<byte, Coordinates> potentialSoftLocks, Dictionary<byte, Coordinates> fixSoftLocks, byte[] coords)
    {
        for (byte i = 0; i < potentialSoftLocks.Count; i++)
        {
            if (coords[0] == potentialSoftLocks[i].Coord_X && coords[1] == potentialSoftLocks[i].Coord_Y)
            {
                _NewCoord.SetValue(fixSoftLocks[i].Coord_X, 0);
                _NewCoord.SetValue(fixSoftLocks[i].Coord_Y, 1);
                return _NewCoord;
            }
        }

        return coords;
    }

    private static byte[] FixStage04(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x08, 0x21));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x0A, 0x21));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }
    
    private static byte[] FixStage06(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x14, 0x02));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x14, 0x03));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }
    
    private static byte[] FixStage07(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x1C, 0x20));
        _PotentialSoftLocks.Add(1, new Coordinates(0x17, 0x13));
        _PotentialSoftLocks.Add(2, new Coordinates(0x0B, 0x0B));
        _PotentialSoftLocks.Add(3, new Coordinates(0x08, 0x08));
        _PotentialSoftLocks.Add(4, new Coordinates(0x05, 0x1A));
        _PotentialSoftLocks.Add(5, new Coordinates(0x07, 0x18));
        _PotentialSoftLocks.Add(6, new Coordinates(0x17, 0x0F));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x1C, 0x1F));
        _FixSoftLocks.Add(1, new Coordinates(0x16, 0x13));
        _FixSoftLocks.Add(2, new Coordinates(0x0B, 0x0E));
        _FixSoftLocks.Add(3, new Coordinates(0x08, 0x0F));
        _FixSoftLocks.Add(4, new Coordinates(0x05, 0x17));
        _FixSoftLocks.Add(5, new Coordinates(0x07, 0x17));
        _FixSoftLocks.Add(6, new Coordinates(0x16, 0x0F));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }

    private static byte[] FixStage11(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x08, 0x02));
        _PotentialSoftLocks.Add(1, new Coordinates(0x1E, 0x04));
        _PotentialSoftLocks.Add(2, new Coordinates(0x29, 0x0C));
        _PotentialSoftLocks.Add(3, new Coordinates(0x29, 0x1F));
        _PotentialSoftLocks.Add(4, new Coordinates(0x1E, 0x29));
        _PotentialSoftLocks.Add(5, new Coordinates(0x03, 0x1C));
        _PotentialSoftLocks.Add(6, new Coordinates(0x08, 0x06));
        _PotentialSoftLocks.Add(7, new Coordinates(0x24, 0x1F));
        _PotentialSoftLocks.Add(8, new Coordinates(0x03, 0x0C));
        _PotentialSoftLocks.Add(9, new Coordinates(0x0B, 0x29));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x14, 0x03));
        _FixSoftLocks.Add(1, new Coordinates(0x17, 0x03));
        _FixSoftLocks.Add(2, new Coordinates(0x26, 0x15));
        _FixSoftLocks.Add(3, new Coordinates(0x26, 0x17));
        _FixSoftLocks.Add(4, new Coordinates(0x17, 0x28));
        _FixSoftLocks.Add(5, new Coordinates(0x05, 0x17));
        _FixSoftLocks.Add(6, new Coordinates(0x15, 0x03));
        _FixSoftLocks.Add(7, new Coordinates(0x25, 0x17));
        _FixSoftLocks.Add(8, new Coordinates(0x05, 0x14));
        _FixSoftLocks.Add(9, new Coordinates(0x14, 0x28));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }
    
    private static byte[] FixStage17(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x12, 0x1C));
        _PotentialSoftLocks.Add(1, new Coordinates(0x15, 0x14));
        _PotentialSoftLocks.Add(2, new Coordinates(0x15, 0x12));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x13, 0x1B));
        _FixSoftLocks.Add(1, new Coordinates(0x15, 0x16));
        _FixSoftLocks.Add(2, new Coordinates(0x14, 0x13));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }

    private static byte[] FixStage19(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x02, 0x16));
        _PotentialSoftLocks.Add(1, new Coordinates(0x05, 0x02));
        _PotentialSoftLocks.Add(2, new Coordinates(0x1F, 0x1F));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x04, 0x16));
        _FixSoftLocks.Add(1, new Coordinates(0x05, 0x06));
        _FixSoftLocks.Add(2, new Coordinates(0x1B, 0x1C));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }

    private static byte[] FixStage23(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x0F, 0x02));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x11, 0x08));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }

    private static byte[] FixStage44(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x00, 0x01));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x01, 0x01));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }

    private static byte[] FixStage45(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x05, 0x11));
        _PotentialSoftLocks.Add(1, new Coordinates(0x1F, 0x0B));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x05, 0x0E));
        _FixSoftLocks.Add(1, new Coordinates(0x1C, 0x0B));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }
    
    private static byte[] FixStage49(byte[] coords)
    {
        #region Potential Soft Locks Coordinates
        _PotentialSoftLocks.Add(0, new Coordinates(0x18, 0x03));
        _PotentialSoftLocks.Add(1, new Coordinates(0x09, 0x0F));
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x1A, 0x03));
        _FixSoftLocks.Add(1, new Coordinates(0x0C, 0x0F));
        #endregion

        return Coordinates_Fixer(_PotentialSoftLocks, _FixSoftLocks, coords);
    }
}
