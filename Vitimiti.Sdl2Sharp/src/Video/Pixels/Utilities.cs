using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.Video.Pixels;

public static class Utilities
{
    public static uint DefinePixelFourCC(byte a, byte b, byte c, byte d)
    {
        return Sdl.FourCC(a, b, c, d);
    }

    public static uint DefinePixelFormat(
        Type type,
        uint order,
        uint layout,
        byte bits,
        byte bytes)
    {
        return (uint)((1 << 28)
            | ((byte)type << 24)
            | ((byte)order << 20)
            | ((byte)layout << 16)
            | (bits << 8)
            | (bytes << 0));
    }

    public static uint DefinePixelFormat(
        Type type,
        uint order,
        PackedLayout layout,
        byte bits,
        byte bytes)
    {
        return DefinePixelFormat(type, order, (uint)layout, bits, bytes);
    }

    public static uint DefinePixelFormat(
        Type type,
        ArrayOrder order,
        uint layout,
        byte bits,
        byte bytes)
    {
        return DefinePixelFormat(type, (uint)order, layout, bits, bytes);
    }

    public static uint DefinePixelFormat(
        Type type,
        ArrayOrder order,
        PackedLayout layout,
        byte bits,
        byte bytes)
    {
        return DefinePixelFormat(type, (uint)order, (uint)layout, bits, bytes);
    }

    public static uint DefinePixelFormat(
        Type type,
        BitmapOrder order,
        uint layout,
        byte bits,
        byte bytes)
    {
        return DefinePixelFormat(type, (uint)order, layout, bits, bytes);
    }

    public static uint DefinePixelFormat(
        Type type,
        BitmapOrder order,
        PackedLayout layout,
        byte bits,
        byte bytes)
    {
        return DefinePixelFormat(type, (uint)order, (uint)layout, bits, bytes);
    }

    public static uint DefinePixelFormat(
        Type type,
        PackedOrder order,
        uint layout,
        byte bits,
        byte bytes)
    {
        return DefinePixelFormat(type, (uint)order, layout, bits, bytes);
    }

    public static uint DefinePixelFormat(
        Type type,
        PackedOrder order,
        PackedLayout layout,
        byte bits,
        byte bytes)
    {
        return DefinePixelFormat(type, (uint)order, (uint)layout, bits, bytes);
    }

    public static byte PixelFlag(uint pixel)
    {
        return (byte)((pixel >> 28) & 0x0F);
    }

    public static byte PixelType(uint pixel)
    {
        return (byte)((pixel >> 24) & 0x0F);
    }

    public static byte PixelOrder(uint pixel)
    {
        return (byte)((pixel >> 20) & 0x0F);
    }

    public static byte PixelLayout(uint pixel)
    {
        return (byte)((pixel >> 16) & 0x0F);
    }

    public static byte BitsPerPixel(uint pixel)
    {
        return (byte)((pixel >> 8) & 0xFF);
    }

    public static byte BytesPerPixel(uint pixel)
    {
        return (byte)(IsPixelFormatFourCC(pixel)
            ? pixel == PixelFormats.Yuy2 || pixel == PixelFormats.Uyvy || pixel == PixelFormats.Yvyu
                ? 2
                : 1
            : (byte)((pixel >> 0) & 0xFF));
    }

    public static bool IsPixelFormatIndexed(uint format)
    {
        return !IsPixelFormatFourCC(format)
            && (Type)PixelType(format) is Type.Index1 or Type.Index4 or Type.Index8;
    }

    public static bool IsPixelFormatPacked(uint format)
    {
        return !IsPixelFormatFourCC(format)
            && (Type)PixelType(format) is Type.Packed8 or Type.Packed16 or Type.Packed32;
    }

    public static bool IsPixelFormatArray(uint format)
    {
        return !IsPixelFormatFourCC(format)
            && (Type)PixelType(format)
                is Type.ArrayU8
                or Type.ArrayU16
                or Type.ArrayU32
                or Type.ArrayF16
                or Type.ArrayF32;
    }

    public static bool IsPixelFormatAlpha(uint format)
    {
        return (IsPixelFormatPacked(format)
                && (PackedOrder)PixelOrder(format)
                    is PackedOrder.Argb or PackedOrder.Rgba or PackedOrder.Abgr or PackedOrder.Bgra)
            || (IsPixelFormatArray(format)
                && (ArrayOrder)PixelOrder(format)
                    is ArrayOrder.Argb or ArrayOrder.Rgba or ArrayOrder.Abgr or ArrayOrder.Bgra);
    }

    public static bool IsPixelFormatFourCC(uint format)
    {
        return (format == 0) && (PixelFlag(format) != 1);
    }
}