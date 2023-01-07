namespace Vitimiti.Sdl2Sharp.Video.Blending;

public enum BlendFactor
{
    Zero = 0x1,
    One = 0x2,
    SourceColor = 0x3,
    OneMinusSourceColor = 0x4,
    SourceAlpha = 0x5,
    OneMinusSourceAlpha = 0x6,
    DestinationColor = 0x7,
    OneMinusDestinationColor = 0x8,
    DestinationAlpha = 0x9,
    OneMinusDestinationAlpha = 0xA
}