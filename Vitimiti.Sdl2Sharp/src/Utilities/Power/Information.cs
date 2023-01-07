using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.Utilities.Power;

public static class Information
{
    public static (State, BatteryLife) Update()
    {
        var state = Sdl.GetPowerInformation(out var seconds, out var percentage);
        return (state, new BatteryLife { Seconds = seconds, Percentage = percentage });
    }
}