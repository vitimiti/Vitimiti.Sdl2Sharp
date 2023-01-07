namespace Vitimiti.Sdl2Sharp.Utilities.Power;

public readonly struct BatteryLife
{
    public readonly int Seconds { init; get; }
    public readonly int Percentage { init; get; }
}