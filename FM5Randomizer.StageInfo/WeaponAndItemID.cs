namespace FM5Randomizer.GameEnum;

public class WeaponAndItemID
{
    public class Support
    {
        public enum BackPackID : byte
        {
            BackPack0x01 = 0x01,    //"Turbo Rank 1-4"
            BackPack0x02 = 0x02,    //"Turbo Rank 4-8"
            BackPack0x03 = 0x03,    //"Turbo Rank 8-12"
            BackPack0x04 = 0x04,    //"Turbo Item Rank 1-4"
            BackPack0x05 = 0x05,    //"Turbo Item Rank 4-8"
            BackPack0x06 = 0x06,    //"Turbo Item Rank 8-12"
            BackPack0x07 = 0x07,    //"Item Turbo Rank 1-4"
            BackPack0x08 = 0x08,    //"Item Turbo Rank 4-8"
            BackPack0x09 = 0x09,    //"Item Turbo Rank 8-12"
            BackPack0x0A = 0x0A,    //"Repair Light Rank 1-4"
            BackPack0x0B = 0x0B,    //"Repair Light Rank 4-8"
            BackPack0x0C = 0x0C,    //"Repair Light Rank 8-12"
            BackPack0x0D = 0x0D,    //"Repair Rank 1-4"
            BackPack0x0E = 0x0E,    //"Repair Rank 4-8"
            BackPack0x0F = 0x0F,    //"Repair Rank 8-12"
            BackPack0x10 = 0x10,    //"Repair EMP Rank 1-4"
            BackPack0x11 = 0x11,    //"Repair EMP Rank 4-8"
            BackPack0x12 = 0x12,    //"Repair EMP Rank 8-12"
            BackPack0x13 = 0x13,    //"Sensor & Sensor EMP Rank 1-4"
            BackPack0x14 = 0x14,    //"Sensor & Sensor EMP Rank 4-8"
            BackPack0x15 = 0x15,    //"Sensor & Sensor EMP Rank 8-12"
            BackPack0x16 = 0x16,    //"EMP Rank 1-4"
            BackPack0x17 = 0x17,    //"EMP Rank 4-8"
            BackPack0x18 = 0x18,    //"EMP Rank 8-12"
            BackPack0x19 = 0x19,    //"EMP Repair Rank 1-4"
            BackPack0x1A = 0x1A,    //"EMP Repair Rank 4-8"
            BackPack0x1B = 0x1B     //"EMP Repair Rank 8-12"
        }

        public enum ItemRepair : byte
        {
            Repair_300 = 1,
            Repair_500,
            Repair_800,
            Repair_1200,
            Repair_Max,
            Mini_Repair_Max,
            All_Repair_200,
            All_Repair_400,
            All_Repair_Max,
            Removere = 0x12
        }

        public enum ItemAmmo : byte
        {
            GR_Reload_3 = 0x0A,
            GR_Reload_Max,
            BZ_Reload_10,
            BZ_Reload_Max,
            RK_Reload_2,
            RK_Reload_Max,
            MS_Reload_3,
            MS_Reload_Max,
            Universal_Bullet = 0x14    // can reload all
        }
    }
    
    public class FireArm
    {
        public enum MachineGunID : byte
        {
            MG0x01 = 0x01,  //"Raptor"
            MG0x02 = 0x02,  //"Raptor EX"
            MG0x03 = 0x03,  //"Raptor FX"
            MG0x04 = 0x04,  //"Grave"
            MG0x05 = 0x05,  //"Grave 2"
            MG0x06 = 0x06,  //"Grave SP"
            MG0x07 = 0x07,  //"Leosocial"
            MG0x08 = 0x08,  //"Leosocial SD"
            MG0x09 = 0x09,  //"Leosocial L"
            MG0x0A = 0x0A,  //"Artassaut"
            MG0x0B = 0x0B,  //"Artassaut C"
            MG0x0C = 0x0C,  //"Artassaut SP"
            MG0x0D = 0x0D,  //"Cemetery"
            MG0x0E = 0x0E,  //"Cemetery LW"
            MG0x0F = 0x0F,  //"Cemetery 10"
            MG0x10 = 0x10,  //"Chronik"
            MG0x11 = 0x11,  //"Chronik 10"
            MG0x12 = 0x12,  //"Chronik 20"
            MG0x97 = 0x97   //"AI-Using"
        }

        public enum ShotGunID : byte
        {
            SG0x13 = 0x13,  //"Gale"
            SG0x14 = 0x14,  //"Gake LC"
            SG0x15 = 0x15,  //"Gale II"
            SG0x16 = 0x16,  //"Catsray L"
            SG0x17 = 0x17,  //"Catsray"
            SG0x18 = 0x18,  //"Catsray XX"
            SG0x19 = 0x19,  //"Kirishima 55"
            SG0x1A = 0x1A,  //"Kirishima 55 SD"
            SG0x1B = 0x1B,  //"Kirishima 58"
            SG0x1C = 0x1C,  //"Girino"
            SG0x1D = 0x1D,  //"Girino HC"
            SG0x1E = 0x1E,  //"Girino 2"
            SG0x1F = 0x1F,  //"State"
            SG0x20 = 0x20,  //"State EX"
            SG0x21 = 0x21,  //"State EX-AC"
            SG0x22 = 0x22,  //"Covet"
            SG0x23 = 0x23,  //"Peak Gaza"
            SG0x24 = 0x24   //"Covet V200"
        }

        public enum GatlingGunID : byte
        {
            GG0x25 = 0x25,  //"Leostun"
            GG0x26 = 0x26,  //"Leostun D"
            GG0x27 = 0x27,  //"Leostun E"
            GG0x28 = 0x28,  //"FV-24"
            GG0x29 = 0x29,  //"FV-24A"
            GG0x2A = 0x2A,  //"FV-24B FV-24C"
            GG0x2B = 0x2B,  //"Glaux"
            GG0x2C = 0x2C,  //"Glaux B"
            GG0x2D = 0x2D,  //"Glaux 2"
            GG0x2E = 0x2E,  //"Uhlan"
            GG0x2F = 0x2F,  //"Uhlan L"
            GG0x30 = 0x30,  //"Uhlan 20 Uhlan 80"
            GG0x31 = 0x31,  //"Fujan"
            GG0x32 = 0x32,  //"Fujan M200"
            GG0x33 = 0x33,  //"Fujan M500"
            GG0x34 = 0x34,  //"Burchel"
            GG0x35 = 0x35,  //"Burchel F"
            GG0x36 = 0x36   //"Burchel FX"
        }

        public enum FlameThrowerID : byte
        {
            FT0x37 = 0x37,  //"Hot River" 
            FT0x38 = 0x38,  //"Hot River HG"
            FT0x39 = 0x39,  //"Hot River SD"
            FT0x3A = 0x3A,  //"Warmer"
            FT0x3B = 0x3B,  //"Warmer LC"
            FT0x3C = 0x3C,  //"Warmer F1 Warmer F2"
            FT0x3D = 0x3D,  //"Heat Rat"
            FT0x3E = 0x3E,  //"Heat Rat S"
            FT0x3F = 0x3F,  //"Heat Rat EX"
            FT0x40 = 0x40,  //"Fire Ant"
            FT0x41 = 0x41,  //"Fire Ant F"
            FT0x42 = 0x42   //"Fire Ant S"
        }

        public enum RifleID : byte
        {
            RF0x5B = 0x5B,  //"Iguchi Type 5"
            RF0x5C = 0x5C,  //"Iguchi Type 502"
            RF0x5D = 0x5D,  //"Iguchi Type 503"
            RF0x5E = 0x5E,  //"Winee"
            RF0x5F = 0x5F,  //"Winee R"
            RF0x60 = 0x60,  //"Winee RR"
            RF0x61 = 0x61,  //"Glowtusk"
            RF0x62 = 0x62,  //"Glowtusk AS"
            RF0x63 = 0x63,  //"Glowtusk SS"
            RF0x64 = 0x64,  //"Ibis"
            RF0x65 = 0x65,  //"Ibis P"
            RF0x66 = 0x66,  //"Ibis 2"
            RF0x67 = 0x67,  //"Firebird"
            RF0x68 = 0x68,  //"Firebird 2"
            RF0x69 = 0x69,  //"Firebird V"
            RF0x6A = 0x6A,  //"Srab"
            RF0x6B = 0x6B,  //"Srab DH"
            RF0x6C = 0x6C   //"Srab B"
        }

        public enum BazookaID : byte
        {
            BZ0x6D = 0x6D,  //"Boa"
            BZ0x6E = 0x6E,  //"Boa MI"
            BZ0x6F = 0x6F,  //"Boa 36  Boa 44"
            BZ0x70 = 0x70,  //"Gnautz"
            BZ0x71 = 0x71,  //"Gnautz 3"
            BZ0x72 = 0x72,  //"Gnautz 10"
            BZ0x73 = 0x73,  //"Be-11"
            BZ0x74 = 0x74,  //"Be-11 SD"
            BZ0x75 = 0x75,  //"Be-11 XP"
            BZ0x76 = 0x76,  //"Banish"
            BZ0x77 = 0x77,  //"Banish CH"
            BZ0x78 = 0x78,  //"Banish 3"
            BZ0x79 = 0x79,  //"Grom"
            BZ0x7A = 0x7A,  //"Grom A"
            BZ0x7B = 0x7B,  //"Grom II Grom III"
            BZ0x7C = 0x7C,  //"Burgiba"
            BZ0x7D = 0x7D,  //"Burgiba 2"
            BZ0x7E = 0x7E   //"Burgiba UL"
        }
    }

    public class CloseCombat
    {
        public enum KnuckleID : byte
        {
            KN0x43 = 0x43,  //"Bone Buster Bone Buster FM"
            KN0x44 = 0x44,  //"Rock Buster"
            KN0x45 = 0x45,  //"Steel Buster"
            KN0x46 = 0x46,  //"Iron Lump Iron Lump F"
            KN0x47 = 0x47,  //"Iron Lump B"
            KN0x48 = 0x48,  //"Iron Lump B DX"
            KN0x49 = 0x49,  //"Soul Buster Soul Buster SD"
            KN0x4A = 0x4A,  //"Soul Buster X  Soul Buster XF"
            KN0x4B = 0x4B,  //"Soul Buster 2"
            KN0x4C = 0x4C,  //"Double Nail"
            KN0x4D = 0x4D,  //"Double Blade"
            KN0x4E = 0x4E   //"Double Fang"
        }

        public enum RodID : byte
        {
            RD0x4F = 0x4F,  //"F_1 Hand Rod F_1 Hand Rod F"
            RD0x50 = 0x50,  //"F_4 Hand Rod"
            RD0x51 = 0x51,  //"F_5 Hand Rod"
            RD0x52 = 0x52,  //"Ogon"
            RD0x53 = 0x53,  //"Ogon S"
            RD0x54 = 0x54,  //"Ogon F"
            RD0x55 = 0x55,  //"Crusader Crusader SD"
            RD0x56 = 0x56,  //"Crusader II Crusader II F"
            RD0x57 = 0x57,  //"Crusader II EX"
            RD0x58 = 0x58,  //"Keen Saber G Keen Saber F"
            RD0x59 = 0x59,  //"Keen Saber"
            RD0x5A = 0x5A   //"Keen Saber X"
        }

        public enum ShieldID : byte
        {
            SD0x7F = 0x7F,  //"Light Shield"
            SD0x80 = 0x80,  //"Light Shield ARG"
            SD0x81 = 0x81,  //"Light Shield 2"
            SD0x82 = 0x82,  //"WS"
            SD0x83 = 0x83,  //"WS-AMS"
            SD0x84 = 0x84,  //"WS-100 WS-200AMS"
            SD0x85 = 0x85,  //"SN"
            SD0x86 = 0x86,  //"SN-AMS"
            SD0x87 = 0x87,  //"SN-SD"
            SD0x88 = 0x88,  //"SP06"
            SD0x89 = 0x89,  //"SP06-V"
            SD0x8A = 0x8A   //"SP06-SD"
        }

        public enum PileBunkerID : byte
        {
            PB0x8B = 0x8B,  //"Heavy Pile"
            PB0x8C = 0x8C,  //"Heavy Pile SD"
            PB0x8D = 0x8D,  //"Heavy Pile F"
            PB0x8E = 0x8E,  //"Press Needle Press Needle FM"
            PB0x8F = 0x8F,  //"Hot Neddle"
            PB0x90 = 0x90,  //"Press Sting"
            PB0x91 = 0x91,  //"Last Stake S Last Stake F"
            PB0x92 = 0x92,  //"Last Stake"
            PB0x93 = 0x93,  //"Last Stake SP"
            PB0x94 = 0x94,  //"Battle Tusk Battle Tusk SD"
            PB0x95 = 0x95,  //"Battle Tusk J Battle Tusk JF"
            PB0x96 = 0x96   //"Battle Tusk 2"
        }
    }

    public class Launcher
    {
        public enum MissileID : byte
        {
            MS0x01 = 0x01,  //"Donkey Donkey L"
            MS0x02 = 0x02,  //"Donkey DX"
            MS0x03 = 0x03,  //"Donkey DX2"
            MS0x04 = 0x04,  //"Sunowl"
            MS0x05 = 0x05,  //"Sundog"
            MS0x06 = 0x06,  //"Sunglow"
            MS0x07 = 0x07,  //"MGR MGR-M"
            MS0x08 = 0x08,  //"MGR-2"
            MS0x09 = 0x09,  //"MGR-3"
            MS0x0A = 0x0A,  //"Piz 3"
            MS0x0B = 0x0B,  //"Piz 4"
            MS0x0C = 0x0C,  //"Piz 4R"
            MS0x0D = 0x0D,  //"Goldias"
            MS0x0E = 0x0E,  //"Goldias S"
            MS0x0F = 0x0F,  //"Goldias L"
            MS0x10 = 0x10,  //"Magic Box"
            MS0x11 = 0x11,  //"Magic Box 2A"
            MS0x12 = 0x12   //"Magic Box 2B"
        }

        public enum RocketID : byte
        {
            RK0x13 = 0x13,  //"Galbados"
            RK0x14 = 0x14,  //"Galbados 2"
            RK0x15 = 0x15,  //"Galbados 3"
            RK0x16 = 0x16,  //"Wildgoose"
            RK0x17 = 0x17,  //"Wildgoose 3"
            RK0x18 = 0x18,  //"Wildgoose 2"
            RK0x19 = 0x19,  //"Egret"
            RK0x1A = 0x1A,  //"Egret E"
            RK0x1B = 0x1B,  //"Egret F"
            RK0x1C = 0x1C,  //"Albatross"
            RK0x1D = 0x1D,  //"Albatross R"
            RK0x1E = 0x1E   //"Albatross S"
        }

        public enum GrenadeID : byte
        {
            GR0x1F = 0x1F,  //"Thunderbolt"
            GR0x20 = 0x20,  //"Thunderbolt 2"
            GR0x21 = 0x21,  //"Thunderbolt 3"
            GR0x22 = 0x22,  //"Iguchi Type 82"
            GR0x23 = 0x23,  //"Iguchi Type 82B"
            GR0x24 = 0x24,  //"Iguchi Type 82A"
            GR0x25 = 0x25,  //"Skua"
            GR0x26 = 0x26,  //"Skua G"
            GR0x27 = 0x27,  //"High Skua"
            GR0x28 = 0x28,  //"Lazy Horn"
            GR0x29 = 0x29,  //"Bar Horn"
            GR0x2A = 0x2A   //"Wis Horn"
        }
    }
    
    public class NonWanzer
    {
        public enum CannonID : byte
        {
            CN0x2C = 0x2C,
            CN0x2D = 0x2D,
            CN0x3C = 0x3C,
            CN0x3E = 0x3E,
            CN0x3F = 0x3F,
            CN0x40 = 0x40,
            CN0x41 = 0x41,
            CN0x42 = 0x42,
            CN0x43 = 0x43,
            CN0x45 = 0x45,
            CN0x46 = 0x46
        }

        public enum HELIID : byte
        {
            HL0x2A = 0x2A,
            HL0x2B = 0x2B,
            HL0x36 = 0x36,
            HL0x37 = 0x37,
            HL0x3A = 0x3A
        }

        public enum Tank : byte
        {
            TN0x2A = 0x2A,
            TN0x2B = 0x2B,
            TN0x2C = 0x2C,
            TN0x2D = 0x2D,
            TN0x2E = 0x2E,
            TN0x36 = 0x36,
            TN0x3A = 0x3A,
            TN0x3C = 0x3C,
            TN0x3E = 0x3E
        }

        //public enum Explosive_Container : byte
        //{
        //    None = 0,
        //    EC0x3B = 0x3B,      // Low-650 Damge
        //    EC0x44 = 0x44       // High-2700 Damage
        //}
    }
}

