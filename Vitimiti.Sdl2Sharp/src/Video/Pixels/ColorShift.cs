namespace Vitimiti.Sdl2Sharp.Video.Pixels;

public readonly struct ColorShift : IEquatable<ColorShift>
{
    public readonly byte R { get; init; }
    public readonly byte G { get; init; }
    public readonly byte B { get; init; }
    public readonly byte A { get; init; }

    public bool Equals(ColorShift other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        return obj is ColorShift colorShift && Equals(colorShift);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(ColorShift left, ColorShift right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ColorShift left, ColorShift right)
    {
        return !(left == right);
    }
}