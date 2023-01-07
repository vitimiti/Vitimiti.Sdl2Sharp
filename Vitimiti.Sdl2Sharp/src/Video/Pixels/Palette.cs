using System.Runtime.InteropServices;
using System.Security.AccessControl;

using Vitimiti.Sdl2Sharp.Marshaling;
using Vitimiti.Sdl2Sharp.SafeHandles;
using Vitimiti.Sdl2Sharp.Utilities;

namespace Vitimiti.Sdl2Sharp.Video.Pixels;

public class Palette : IDisposable
{
    private bool _disposedValue;

    public PaletteSafeHandle SafeHandle { get; private set; }
    public System.Drawing.Color[] Colors { get; private set; }
    public uint Version { get; private set; }
    public int ReferenceCount { get; private set; }

    private static Sdl.Palette ToManaged(IntPtr ptr)
    {
        var nativePalette = new Sdl.Palette();
        Marshal.PtrToStructure(ptr, nativePalette);
        return nativePalette;
    }

    private static (
        System.Drawing.Color[] Colors,
        uint Version,
        int ReferenceCount) Initialize(PaletteSafeHandle handle)
    {
        var nativePalette = ToManaged(handle.DangerousGetHandle());

        var ptr = nativePalette.Colors;
        var arraySize = nativePalette.NumberOfColors;
        var nativeColors = new Sdl.Color[arraySize];
        var colors = new System.Drawing.Color[arraySize];
        for (var i = 0; i < arraySize; i++)
        {
            nativeColors[i] = new Sdl.Color();
        }

        var ptrArray = new IntPtr[arraySize];
        for (var i = 0; i < arraySize; i++)
        {
            ptrArray[i] = Marshal.AllocHGlobal(Marshal.SizeOf<Sdl.Color>());
        }

        try
        {
            Marshal.Copy(ptr, ptrArray, 0, arraySize);
            for (var i = 0; i < arraySize; i++)
            {
                nativeColors[i] = Color.ToManaged(ptrArray[i]);
            }

            for (var i = 0; i < arraySize; i++)
            {
                colors[i] = System.Drawing.Color.FromArgb(
                    nativeColors[i].R,
                    nativeColors[i].G,
                    nativeColors[i].B,
                    nativeColors[i].A);
            }

            return (colors, nativePalette.Version, nativePalette.ReferenceCount);
        }
        finally
        {
            foreach (var arrayPtr in ptrArray)
            {
                Marshal.FreeHGlobal(arrayPtr);
            }
        }
    }

    internal Palette(PaletteSafeHandle handle)
    {
        if (handle.IsInvalid)
        {
            throw new ArgumentNullException(nameof(handle), $"{nameof(handle)} must point to a valid handle");
        }

        SafeHandle = handle;
        (Colors, Version, ReferenceCount) = Initialize(handle);
    }

    public Palette(int numberOfColors)
    {
        var handle = new PaletteSafeHandle(Sdl.AllocPalette(numberOfColors));
        if (handle.IsInvalid)
        {
            throw new SdlSharpException(Sdl.GetError());
        }

        SafeHandle = handle;
        (Colors, Version, ReferenceCount) = Initialize(handle);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                SafeHandle.Dispose();
            }

            _disposedValue = true;
        }
    }

    ~Palette()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public void SetColors(System.Drawing.Color[] colors, int firstColor, int numberOfColors)
    {
        var nativeColors = new Sdl.Color[colors.Length];
        for (var i = 0; i < colors.Length; i++)
        {
            nativeColors[i].R = colors[i].R;
            nativeColors[i].G = colors[i].G;
            nativeColors[i].B = colors[i].B;
            nativeColors[i].A = colors[i].A;
        }

        var ptr = SafeHandle.DangerousGetHandle();
        var code = Sdl.SetPaletteColors(ptr, nativeColors, firstColor, numberOfColors);
        if (code < 0)
        {
            throw new SdlSharpException(Sdl.GetError(), code);
        }

        SafeHandle = new(ptr);
        (Colors, Version, ReferenceCount) = Initialize(SafeHandle);
    }
}