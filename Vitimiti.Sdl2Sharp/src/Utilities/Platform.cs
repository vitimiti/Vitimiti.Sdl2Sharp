using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.Utilities;

public static class Platform
{
    public static string Name => Sdl.GetPlatformName();
}