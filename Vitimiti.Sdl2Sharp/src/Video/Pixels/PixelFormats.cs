using Vitimiti.Sdl2Sharp.Marshaling;
using Vitimiti.Sdl2Sharp.Utilities;

namespace Vitimiti.Sdl2Sharp.Video.Pixels;

public struct PixelFormats
{
    public static uint Unknown => 0U;
    public static uint Index1Lsb => Utilities.DefinePixelFormat(Type.Index1, BitmapOrder.HighToLowBit, 0U, 1, 0);
    public static uint Index1Msb => Utilities.DefinePixelFormat(Type.Index1, BitmapOrder.LowToHighBit, 0U, 1, 0);
    public static uint Index4Lsb => Utilities.DefinePixelFormat(Type.Index4, BitmapOrder.HighToLowBit, 0U, 4, 0);
    public static uint Index4Msb => Utilities.DefinePixelFormat(Type.Index4, BitmapOrder.LowToHighBit, 0U, 4, 0);
    public static uint Index8 => Utilities.DefinePixelFormat(Type.Index8, 0U, 0U, 8, 1);
    public static uint Rgb332 => Utilities.DefinePixelFormat(Type.Packed8, PackedOrder.Xrgb, PackedLayout.L332, 8, 1);
    public static uint Xrgb4444 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Xrgb, PackedLayout.L4444, 12, 2);
    public static uint Rgb444 => Xrgb4444;
    public static uint Xbgr4444 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Xbgr, PackedLayout.L4444, 12, 2);
    public static uint Bgr444 => Xbgr4444;
    public static uint Xrgb1555 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Xrgb, PackedLayout.L1555, 15, 2);
    public static uint Rgb555 => Xrgb1555;
    public static uint Xbgr1555 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Xbgr, PackedLayout.L1555, 15, 2);
    public static uint Bgr555 => Xbgr1555;
    public static uint Argb4444 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Argb, PackedLayout.L4444, 16, 2);
    public static uint Rgba4444 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Rgba, PackedLayout.L4444, 16, 2);
    public static uint Abgr4444 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Abgr, PackedLayout.L4444, 16, 2);
    public static uint Bgra4444 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Bgra, PackedLayout.L4444, 16, 2);
    public static uint Argb1555 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Argb, PackedLayout.L1555, 16, 2);
    public static uint Rgba5551 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Rgba, PackedLayout.L5551, 16, 2);
    public static uint Abgr1555 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Abgr, PackedLayout.L1555, 16, 2);
    public static uint Bgra5551 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Abgr, PackedLayout.L1555, 16, 2);
    public static uint Rgb565 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Xrgb, PackedLayout.L565, 16, 2);
    public static uint Bgr565 => Utilities.DefinePixelFormat(Type.Packed16, PackedOrder.Xbgr, PackedLayout.L565, 16, 2);
    public static uint Rgb24 => Utilities.DefinePixelFormat(Type.ArrayU8, ArrayOrder.Rgb, 0U, 24, 3);
    public static uint Bgr24 => Utilities.DefinePixelFormat(Type.ArrayU8, ArrayOrder.Bgr, 0U, 24, 3);
    public static uint Xrgb8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Xrgb, PackedLayout.L8888, 24, 4);
    public static uint Rgb888 => Xrgb8888;
    public static uint Rgbx8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Rgbx, PackedLayout.L8888, 24, 4);
    public static uint Xbgr8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Xbgr, PackedLayout.L8888, 24, 4);
    public static uint Bgr888 => Xbgr8888;
    public static uint Bgrx8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Bgrx, PackedLayout.L8888, 24, 4);
    public static uint Argb8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Argb, PackedLayout.L8888, 32, 4);
    public static uint Rgba8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Rgba, PackedLayout.L8888, 32, 4);
    public static uint Abgr8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Rgba, PackedLayout.L8888, 32, 4);
    public static uint Bgra8888 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Bgra, PackedLayout.L8888, 32, 4);
    public static uint Argb2101010 => Utilities.DefinePixelFormat(Type.Packed32, PackedOrder.Argb, PackedLayout.L2101010, 32, 4);
    public static uint Rgba32 => BitConverter.IsLittleEndian ? Abgr8888 : Rgba8888;
    public static uint Argb32 => BitConverter.IsLittleEndian ? Bgra8888 : Argb8888;
    public static uint Bgra32 => BitConverter.IsLittleEndian ? Argb8888 : Bgra8888;
    public static uint Abgr32 => BitConverter.IsLittleEndian ? Abgr8888 : Rgba8888;
    public static uint Yv12 => Utilities.DefinePixelFourCC((byte)'Y', (byte)'V', (byte)'1', (byte)'2');
    public static uint Iyuv => Utilities.DefinePixelFourCC((byte)'I', (byte)'Y', (byte)'U', (byte)'V');
    public static uint Yuy2 => Utilities.DefinePixelFourCC((byte)'Y', (byte)'U', (byte)'Y', (byte)'2');
    public static uint Uyvy => Utilities.DefinePixelFourCC((byte)'U', (byte)'Y', (byte)'V', (byte)'Y');
    public static uint Yvyu => Utilities.DefinePixelFourCC((byte)'Y', (byte)'V', (byte)'Y', (byte)'U');
    public static uint Nv12 => Utilities.DefinePixelFourCC((byte)'N', (byte)'V', (byte)'1', (byte)'2');
    public static uint Nv21 => Utilities.DefinePixelFourCC((byte)'N', (byte)'V', (byte)'2', (byte)'1');
    public static uint ExternalOes => Utilities.DefinePixelFourCC((byte)'O', (byte)'E', (byte)'S', (byte)' ');

    public static string GetName(uint format)
    {
        return Sdl.GetPixelFormatName(format);
    }

    public static ColorMask ToMasks(uint format)
    {
        var valid = Sdl.PixelFormatEnumToMasks(
            format,
            out var bpp,
            out var rMask,
            out var gMask,
            out var bMask,
            out var aMask);

        return valid ? new ColorMask
        {
            BitsPerPixel = bpp,
            R = rMask,
            G = gMask,
            B = bMask,
            A = aMask
        } : throw new SdlSharpException(Sdl.GetError());
    }

    public static uint FromMasks(ColorMask mask)
    {
        return Sdl.MasksToPixelFormatEnum(
            mask.BitsPerPixel,
            mask.R,
            mask.G,
            mask.B,
            mask.A);
    }
}