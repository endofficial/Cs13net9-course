namespace Packt.Shared;

[Flags]
public enum WondersOfTheAncientWorld: byte //può eriditare da byte, sbyte, Int16, UInt16, Int32, UInt32, Int64, UInt64; Int128 e Uint128 non sono supportati
{
    None                      = 0b_0000_0000, // 0
    PiramideGiza              = 0b_0000_0001, // 1
    HangingGardensBabylon     = 0b_0000_0010, // 2
    StatueZeusOlympia         = 0b_0000_0100, // 4
    TempleArtemisEphesus      = 0b_0000_1000, // 8
    MausoleumHalicarnassus    = 0b_0001_0000, // 16
    ColossusRhodes            = 0b_0010_0000, // 32
    LighthouseAlexandria      = 0b_1000_0000, // 64 
}