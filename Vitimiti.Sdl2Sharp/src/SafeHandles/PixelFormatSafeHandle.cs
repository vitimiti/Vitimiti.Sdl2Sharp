using Microsoft.Win32.SafeHandles;

using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.SafeHandles;

public sealed class PixelFormatSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    public PixelFormatSafeHandle(IntPtr ptr, bool ownsHandle = true) : base(ownsHandle)
    {
        handle = ptr;
    }

    protected override bool ReleaseHandle()
    {
        Sdl.FreeFormat(handle);
        return handle == IntPtr.Zero;
    }
}