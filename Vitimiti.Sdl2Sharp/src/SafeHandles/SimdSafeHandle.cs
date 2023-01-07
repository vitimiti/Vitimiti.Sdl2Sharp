using Microsoft.Win32.SafeHandles;

using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.SafeHandles;

public sealed class SimdSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    public SimdSafeHandle(IntPtr ptr, bool ownsHandle = true) : base(ownsHandle)
    {
        handle = ptr;
    }

    protected override bool ReleaseHandle()
    {
        Sdl.SimdFree(handle);
        return handle == IntPtr.Zero;
    }
}