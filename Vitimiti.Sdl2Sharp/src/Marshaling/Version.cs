using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.CustomMarshalers;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Version
    {
        public byte Major;
        public byte Minor;
        public byte Patch;
    }

    [DllImport(DllName, EntryPoint = "SDL_GetVersion")]
    public static extern void GetVersion(out Version version);

    [DllImport(DllName, EntryPoint = "SDL_GetRevision", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SdlStringCustomMarshaler), MarshalCookie = SdlStringCustomMarshaler.LeaveAllocatedCookie)]
    public static extern string GetRevision();
}