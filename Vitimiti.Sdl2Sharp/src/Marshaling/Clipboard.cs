using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.CustomMarshalers;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    [SuppressMessage("Globalization", "CA2101: Specify marshalling for P/Invoke string arguments", Justification = "It is not possible to mark the CharSet here")]
    [DllImport(DllName, EntryPoint = "SDL_SetClipboardText")]
    public static extern int SetClipboardText(
        [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SdlStringCustomMarshaler))]
        string text
    );

    [DllImport(DllName, EntryPoint = "SDL_GetClipboardText", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SdlStringCustomMarshaler), MarshalCookie = SdlStringCustomMarshaler.LeaveAllocatedCookie)]
    public static extern string GetClipboardText();

    [DllImport(DllName, EntryPoint = "SDL_HasClipboardText")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasClipboardText();
}