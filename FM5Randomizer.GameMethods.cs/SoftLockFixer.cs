using FM5Randomizer.GameEnum;
using System.Numerics;

namespace FM5Randomizer.GameMethods;

public class SoftLockFixer
{
    private static byte[] NewCoord = new byte[2];
    public static byte[] NewCoords(long stageAddress, byte[] coords)
    {
        Array.Clear(NewCoord);

        if (stageAddress == (long)Stage.StageAddress.ST04)
           return FixStage04(coords);
        if (stageAddress == (long)Stage.StageAddress.ST06)
           return FixStage06(coords);
        if (stageAddress == (long)Stage.StageAddress.ST07)
           return FixStage07(coords);
        if (stageAddress == (long)Stage.StageAddress.ST11)
           return FixStage11(coords);
        if (stageAddress == (long)Stage.StageAddress.ST44)
           return FixStage44(coords);

        return coords;
    }

    private static byte[] FixStage04(byte[] coords)
    {
        byte em01_X = 0x08, em01_Z = 0x21;

        if (coords.ElementAt(0).Equals(em01_X) && coords.ElementAt(1).Equals(em01_Z))
        {
            NewCoord.SetValue((byte)0x0A, 0);
            NewCoord.SetValue((byte)0x21, 1);

            return NewCoord;
        }

        return coords;
    }
    
    private static byte[] FixStage06(byte[] coords) 
    {
        byte em01_X = 0x14, em01_Z = 0x02;
        
        if (coords.ElementAt(0).Equals(em01_X) && coords.ElementAt(1).Equals(em01_Z))
        {
            NewCoord.SetValue((byte)0x14, 0);
            NewCoord.SetValue((byte)0x03, 1);

            return NewCoord;
        }

        return coords;
    }
    
    private static byte[] FixStage07(byte[] coords) 
    {
        byte em01_X = 0x1C, em01_Z = 0x20;
        byte em02_X = 0x17, em02_Z = 0x13;
        byte em03_X = 0x0B, em03_Z = 0x0B;
        byte em04_X = 0x08, em04_Z = 0x08;
        byte em05_X = 0x05, em05_Z = 0x1A;
        byte em06_X = 0x07, em06_Z = 0x18;
        byte em07_X = 0x17, em07_Z = 0x0F;

        if (coords.ElementAt(0).Equals(em01_X) && coords.ElementAt(1).Equals(em01_Z))
        {
            NewCoord.SetValue((byte)0x1C, 0);
            NewCoord.SetValue((byte)0x1F, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em02_X) && coords.ElementAt(1).Equals(em02_Z))
        {
            NewCoord.SetValue((byte)0x16, 0);
            NewCoord.SetValue((byte)0x13, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em03_X) && coords.ElementAt(1).Equals(em03_Z))
        {
            NewCoord.SetValue((byte)0x0B, 0);
            NewCoord.SetValue((byte)0x0E, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em04_X) && coords.ElementAt(1).Equals(em04_Z))
        {
            NewCoord.SetValue((byte)0x08, 0);
            NewCoord.SetValue((byte)0x0F, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em05_X) && coords.ElementAt(1).Equals(em05_Z))
        {
            NewCoord.SetValue((byte)0x05, 0);
            NewCoord.SetValue((byte)0x17, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em06_X) && coords.ElementAt(1).Equals(em06_Z))
        {
            NewCoord.SetValue((byte)0x07, 0);
            NewCoord.SetValue((byte)0x17, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em07_X) && coords.ElementAt(1).Equals(em07_Z))
        {
            NewCoord.SetValue((byte)0x16, 0);
            NewCoord.SetValue((byte)0x0F, 1);

            return NewCoord;
        }

        return coords;
    }
    
    private static byte[] FixStage11(byte[] coords) 
    {
        byte em01_X = 0x1E, em01_Z = 0x29;
        byte em02_X = 0x29, em02_Z = 0x1F;
        byte em03_X = 0x29, em03_Z = 0x0C;
        byte em04_X = 0x1E, em04_Z = 0x04;
        byte em05_X = 0x08, em05_Z = 0x02;
        byte em06_X = 0x03, em06_Z = 0x1C;

        if (coords.ElementAt(0).Equals(em01_X) && coords.ElementAt(1).Equals(em01_Z))
        {
            NewCoord.SetValue((byte)0x17, 0);
            NewCoord.SetValue((byte)0x28, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em02_X) && coords.ElementAt(1).Equals(em02_Z))
        {
            NewCoord.SetValue((byte)0x26, 0);
            NewCoord.SetValue((byte)0x17, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em03_X) && coords.ElementAt(1).Equals(em03_Z))
        {
            NewCoord.SetValue((byte)0x26, 0);
            NewCoord.SetValue((byte)0x15, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em04_X) && coords.ElementAt(1).Equals(em04_Z))
        {
            NewCoord.SetValue((byte)0x17, 0);
            NewCoord.SetValue((byte)0x03, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em05_X) && coords.ElementAt(1).Equals(em05_Z))
        {
            NewCoord.SetValue((byte)0x14, 0);
            NewCoord.SetValue((byte)0x03, 1);

            return NewCoord;
        }
        
        if (coords.ElementAt(0).Equals(em06_X) && coords.ElementAt(1).Equals(em06_Z))
        {
            NewCoord.SetValue((byte)0x05, 0);
            NewCoord.SetValue((byte)0x17, 1);

            return NewCoord;
        }

        return coords;
    }

    private static byte[] FixStage44(byte[] coords)
    {
        byte em01_X = 0x00, em01_Z = 0x01;

        if (coords.ElementAt(0).Equals(em01_X) && coords.ElementAt(1).Equals(em01_Z))
        {
            NewCoord.SetValue((byte)0x01, 0);
            NewCoord.SetValue((byte)0x01, 1);

            return NewCoord;
        }

        return coords;
    }
}
