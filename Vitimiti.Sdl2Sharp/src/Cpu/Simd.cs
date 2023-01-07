using Vitimiti.Sdl2Sharp.Marshaling;
using Vitimiti.Sdl2Sharp.SafeHandles;
using Vitimiti.Sdl2Sharp.Utilities;

namespace Vitimiti.Sdl2Sharp.Cpu;

public sealed class Simd : IDisposable
{
    private bool _disposedValue;

    public static uint Alignment => Sdl.SimdGetAlignment();

    public SimdSafeHandle SafeHandle { get; private set; }

    public Simd(uint length)
    {
        SafeHandle = new SimdSafeHandle(Sdl.SimdAlloc(length));
        if (SafeHandle.IsInvalid)
        {
            throw new SdlSharpException(Sdl.GetError());
        }
    }

    private void Dispose(bool disposing)
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

    ~Simd()
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

    public void Reallocate(uint length)
    {
        var ptr = SafeHandle.DangerousGetHandle();
        SafeHandle = new SimdSafeHandle(Sdl.SimdRealloc(ptr, length));
        if (SafeHandle.IsInvalid)
        {
            throw new SdlSharpException(Sdl.GetError());
        }
    }
}