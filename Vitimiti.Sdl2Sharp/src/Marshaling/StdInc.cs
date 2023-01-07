namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    public static uint FourCC(byte a, byte b, byte c, byte d)
    {
        return (uint)((a << 0) | (b << 8) | (c << 16) | (d << 24));
    }
}