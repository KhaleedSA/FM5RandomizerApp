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
            (long)Stage.StageAddress.ST44 => FixStage44(coords),
            (long)Stage.StageAddress.ST45 => FixStage45(coords),
            _ => coords,
        };
    }

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
        #endregion

        #region Fix Soft Locks Coordinates
        _FixSoftLocks.Add(0, new Coordinates(0x14, 0x03));
        _FixSoftLocks.Add(1, new Coordinates(0x17, 0x03));
        _FixSoftLocks.Add(2, new Coordinates(0x26, 0x15));
        _FixSoftLocks.Add(3, new Coordinates(0x26, 0x17));
        _FixSoftLocks.Add(4, new Coordinates(0x17, 0x28));
        _FixSoftLocks.Add(5, new Coordinates(0x05, 0x17));
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
}
