using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.Video.Pixels;

internal static class Color
{
    internal static Sdl.Color ToManaged(IntPtr ptr)
    {
        var nativeColor = new Sdl.Color();
        Marshal.PtrToStructure(ptr, nativeColor);
        return nativeColor;
    }
}