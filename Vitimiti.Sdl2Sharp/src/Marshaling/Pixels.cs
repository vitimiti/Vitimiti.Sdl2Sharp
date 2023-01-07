using System;
using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.CustomMarshalers;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Palette
    {
        public int NumberOfColors;
        public IntPtr Colors;
        public uint Version;
        public int ReferenceCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PixelFormat
    {
        public uint Format;
        public IntPtr Palette;
        public byte BitsPerPixel;
        public byte BytesPerPixel;

        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeConst = 2)]
        private readonly byte[] _padding;

        public uint RMask;
        public uint GMask;
        public uint BMask;
        public uint AMask;
        public byte RLoss;
        public byte GLoss;
        public byte BLoss;
        public byte ALoss;
        public byte RShift;
        public byte GShift;
        public byte BShift;
        public byte AShift;
        public int ReferenceCount;
        public IntPtr Next;
    }

    [DllImport(DllName, EntryPoint = "SDL_GetPixelFormatName", CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SdlStringCustomMarshaler), MarshalCookie = SdlStringCustomMarshaler.LeaveAllocatedCookie)]
    public static extern string GetPixelFormatName(uint format);

    [DllImport(DllName, EntryPoint = "SDL_PixelFormatEnumToMasks")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool PixelFormatEnumToMasks(
        uint format,
        out int bpp,
        out uint rMask,
        out uint gMask,
        out uint bMask,
        out uint aMask);

    [DllImport(DllName, EntryPoint = "SDL_MasksToPixelFormatEnum")]
    public static extern uint MasksToPixelFormatEnum(
        int bpp,
        uint rMask,
        uint gMask,
        uint bMask,
        uint aMask);

    [DllImport(DllName, EntryPoint = "SDL_AllocFormat")]
    public static extern IntPtr AllocFormat(uint pixelFormat);

    [DllImport(DllName, EntryPoint = "SDL_FreeFormat")]
    public static extern void FreeFormat(IntPtr format);

    [DllImport(DllName, EntryPoint = "SDL_AllocPalette")]
    public static extern IntPtr AllocPalette(int numberOfColors);

    [DllImport(DllName, EntryPoint = "SDL_SetPixelFormatPalette")]
    public static extern int SetPixelFormatPalette(IntPtr format, IntPtr palette);

    [DllImport(DllName, EntryPoint = "SDL_SetPaletteColors")]
    public static extern int SetPaletteColors(
        IntPtr palette,
        [In] Color[] colors,
        int firstColor,
        int numberOfColors);

    [DllImport(DllName, EntryPoint = "SDL_FreePalette")]
    public static extern void FreePalette(IntPtr palette);

    [DllImport(DllName, EntryPoint = "SDL_MapRGB")]
    public static extern uint MapRgb(IntPtr format, byte r, byte g, byte b);

    [DllImport(DllName, EntryPoint = "SDL_MapRGBA")]
    public static extern uint MapRgba(IntPtr format, byte r, byte g, byte b, byte a);

    [DllImport(DllName, EntryPoint = "SDL_GetRGB")]
    public static extern void GetRgb(uint pixel, IntPtr format, out byte r, out byte g, out byte b);

    [DllImport(DllName, EntryPoint = "SDL_GetRGBA")]
    public static extern void GetRgba(
        uint pixel,
        IntPtr format,
        out byte r,
        out byte g,
        out byte b,
        out byte a);

    [DllImport(DllName, EntryPoint = "SDL_CalculateGammaRamp")]
    public static extern void CalculateGammaRamp(
        float gamma,
        [Out] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
        ushort[] ramp);
}