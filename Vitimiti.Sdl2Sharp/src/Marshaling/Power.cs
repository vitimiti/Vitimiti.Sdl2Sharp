using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.Utilities.Power;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    [DllImport(DllName, EntryPoint = "SDL_GetPowerInfo")]
    public static extern State GetPowerInformation(out int seconds, out int percentage);
}