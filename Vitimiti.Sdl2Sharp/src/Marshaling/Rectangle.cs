using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle
    {
        public int X;
        public int Y;
        public int W;
        public int H;
    }

    [DllImport(DllName, EntryPoint = "SDL_EnclosePoints")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool EnclosePoints(
        [In] Point[] points,
        int count,
        ref Rectangle clip,
        out Rectangle result);

    [DllImport(DllName, EntryPoint = "SDL_IntersectRectAndLine")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool IntersectRectangleAndLine(
        ref Rectangle rectangle,
        ref int x1,
        ref int y1,
        ref int x2,
        ref int y2);
}