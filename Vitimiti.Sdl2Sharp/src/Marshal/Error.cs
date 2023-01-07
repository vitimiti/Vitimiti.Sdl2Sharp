using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.CustomMarshalers;

namespace Vitimiti.Sdl2Sharp.Marshal;

internal static partial class Sdl
{
    [DllImport(DllName, EntryPoint = "SDL_GetError", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SdlStringCustomMarshaler), MarshalCookie = SdlStringCustomMarshaler.LeaveAllocatedCookie)]
    public static extern string GetError();
}