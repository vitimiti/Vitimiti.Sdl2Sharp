using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.Marshaling;
using Vitimiti.Sdl2Sharp.SafeHandles;
using Vitimiti.Sdl2Sharp.Utilities;

namespace Vitimiti.Sdl2Sharp.Video.Pixels;

public class PixelFormat
{
    private Palette? _palette;

    public PixelFormatSafeHandle SafeHandle { get; private set; }
    public uint Format { get; private set; }
    public Palette? Palette
    {
        get => _palette;
        set
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value), $"{nameof(value)} cannot be a null object");
            }

            var formatPtr = SafeHandle.DangerousGetHandle();
            var palettePtr = value.SafeHandle.DangerousGetHandle();
            var code = Sdl.SetPixelFormatPalette(formatPtr, palettePtr);
            if (code < 0)
            {
                throw new SdlSharpException(Sdl.GetError(), code);
            }

            _palette = new Palette(new PaletteSafeHandle(palettePtr));
            SafeHandle = new PixelFormatSafeHandle(formatPtr);
            (
                Format,
                _,
                BytesPerPixel,
                ColorMask,
                ColorLoss,
                ColorShift,
                ReferenceCount,
                Next) = Initialize(SafeHandle);
        }
    }

    public byte BytesPerPixel { get; private set; }
    public ColorMask ColorMask { get; private set; }
    public ColorLoss ColorLoss { get; private set; }
    public ColorShift ColorShift { get; private set; }
    public int ReferenceCount { get; private set; }
    public PixelFormat? Next { get; private set; }

    private static Sdl.PixelFormat ToManaged(IntPtr ptr)
    {
        var nativePixelFormat = new Sdl.PixelFormat();
        Marshal.PtrToStructure(ptr, nativePixelFormat);
        return nativePixelFormat;
    }

    private static (
        uint Format,
        Palette? Palette,
        byte BytesPerPixel,
        ColorMask ColorMask,
        ColorLoss ColorLoss,
        ColorShift ColorShift,
        int ReferenceCount,
        PixelFormat? Next) Initialize(PixelFormatSafeHandle handle)
    {
        var nativePixelFormat = ToManaged(handle.DangerousGetHandle());
        var palette = nativePixelFormat.Palette == IntPtr.Zero
            ? null
            : new Palette(new PaletteSafeHandle(nativePixelFormat.Palette));

        var colorMask = new ColorMask
        {
            BitsPerPixel = nativePixelFormat.BitsPerPixel,
            R = nativePixelFormat.RMask,
            G = nativePixelFormat.GMask,
            B = nativePixelFormat.BMask,
            A = nativePixelFormat.AMask
        };

        var colorLoss = new ColorLoss
        {
            R = nativePixelFormat.RLoss,
            G = nativePixelFormat.GLoss,
            B = nativePixelFormat.BLoss,
            A = nativePixelFormat.ALoss
        };

        var colorShift = new ColorShift
        {
            R = nativePixelFormat.RShift,
            G = nativePixelFormat.GShift,
            B = nativePixelFormat.BShift,
            A = nativePixelFormat.AShift
        };

        var next = nativePixelFormat.Next == IntPtr.Zero
            ? null
            : new PixelFormat(new PixelFormatSafeHandle(nativePixelFormat.Next));

        return (
            nativePixelFormat.Format,
            palette,
            nativePixelFormat.BytesPerPixel,
            colorMask,
            colorLoss,
            colorShift,
            nativePixelFormat.ReferenceCount,
            next);
    }

    private PixelFormat(PixelFormatSafeHandle handle)
    {
        if (handle.IsInvalid)
        {
            throw new ArgumentNullException(nameof(handle), $"{nameof(handle)} must point to a valid handle");
        }

        SafeHandle = handle;
        (
            Format,
            _palette,
            BytesPerPixel,
            ColorMask,
            ColorLoss,
            ColorShift,
            ReferenceCount,
            Next) = Initialize(handle);
    }

    public static Span<ushort> CalculateGammaRamp(float gamma)
    {
        var array = new ushort[256];
        Sdl.CalculateGammaRamp(gamma, array);
        return array;
    }

    public PixelFormat(uint pixelFormat)
    {
        var handle = new PixelFormatSafeHandle(Sdl.AllocFormat(pixelFormat));
        if (handle.IsInvalid)
        {
            throw new SdlSharpException(Sdl.GetError());
        }

        SafeHandle = handle;
        (
            Format,
            _palette,
            BytesPerPixel,
            ColorMask,
            ColorLoss,
            ColorShift,
            ReferenceCount,
            Next) = Initialize(handle);
    }

    public uint MapRgb(System.Drawing.Color color)
    {
        return Sdl.MapRgb(SafeHandle.DangerousGetHandle(), color.R, color.G, color.B);
    }

    public uint MapRgba(System.Drawing.Color color)
    {
        return Sdl.MapRgba(SafeHandle.DangerousGetHandle(), color.R, color.G, color.B, color.A);
    }

    public System.Drawing.Color GetRgb(uint pixel)
    {
        Sdl.GetRgb(pixel, SafeHandle.DangerousGetHandle(), out var r, out var g, out var b);
        return System.Drawing.Color.FromArgb(r, g, b);
    }

    public System.Drawing.Color GetRgba(uint pixel)
    {
        Sdl.GetRgba(
            pixel,
            SafeHandle.DangerousGetHandle(),
            out var r,
            out var g,
            out var b,
            out var a);

        return System.Drawing.Color.FromArgb(r, g, b, a);
    }
}