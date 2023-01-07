namespace Vitimiti.Sdl2Sharp.Video.Pixels;

public readonly struct ColorLoss : IEquatable<ColorLoss>
{
    public readonly byte R { get; init; }
    public readonly byte G { get; init; }
    public readonly byte B { get; init; }
    public readonly byte A { get; init; }

    public bool Equals(ColorLoss other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        return obj is ColorLoss colorLoss && Equals(colorLoss);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(ColorLoss left, ColorLoss right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ColorLoss left, ColorLoss right)
    {
        return !(left == right);
    }
}