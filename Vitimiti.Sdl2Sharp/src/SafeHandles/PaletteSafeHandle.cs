using Microsoft.Win32.SafeHandles;

using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp.SafeHandles;

public sealed class PaletteSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    public PaletteSafeHandle(IntPtr ptr, bool ownsHandle = true) : base(ownsHandle)
    {
        handle = ptr;
    }

    protected override bool ReleaseHandle()
    {
        Sdl.FreePalette(handle);
        return handle == IntPtr.Zero;
    }
}