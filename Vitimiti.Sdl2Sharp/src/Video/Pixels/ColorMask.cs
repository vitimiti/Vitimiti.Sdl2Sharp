namespace Vitimiti.Sdl2Sharp.Video.Pixels;

public readonly struct ColorMask : IEquatable<ColorMask>
{
    public readonly int BitsPerPixel { get; init; }
    public readonly uint R { get; init; }
    public readonly uint G { get; init; }
    public readonly uint B { get; init; }
    public readonly uint A { get; init; }

    public bool Equals(ColorMask other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        return obj is ColorMask colorMask && Equals(colorMask);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(ColorMask left, ColorMask right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ColorMask left, ColorMask right)
    {
        return !(left == right);
    }
}