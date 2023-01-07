using System;
using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    [DllImport(DllName, EntryPoint = "SDL_GetCPUCount")]
    public static extern int GetCpuCount();

    [DllImport(DllName, EntryPoint = "SDL_GetCPUCacheLineSize")]
    public static extern int GetCpuCacheLineSize();

    [DllImport(DllName, EntryPoint = "SDL_HasRDTSC")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasRdtsc();

    [DllImport(DllName, EntryPoint = "SDL_HasAltiVec")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAltiVec();

    [DllImport(DllName, EntryPoint = "SDL_HasMMX")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasMmx();

    [DllImport(DllName, EntryPoint = "SDL_Has3DNow")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool Has3DNow();

    [DllImport(DllName, EntryPoint = "SDL_HasSSE")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse();

    [DllImport(DllName, EntryPoint = "SDL_HasSSE2")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse2();

    [DllImport(DllName, EntryPoint = "SDL_HasSSE3")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse3();

    [DllImport(DllName, EntryPoint = "SDL_HasSSE41")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse41();

    [DllImport(DllName, EntryPoint = "SDL_HasSSE42")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasSse42();

    [DllImport(DllName, EntryPoint = "SDL_HasAVX")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAvx();

    [DllImport(DllName, EntryPoint = "SDL_HasAVX2")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAvx2();

    [DllImport(DllName, EntryPoint = "SDL_HasAVX512F")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasAvx512F();

    [DllImport(DllName, EntryPoint = "SDL_HasARMSIMD")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static extern bool HasArmSimd();

    [DllImport(DllName, EntryPoint = "SDL_GetSystemRAM")]
    public static extern int GetSystemRam();

    [DllImport(DllName, EntryPoint = "SDL_SIMDGetAlignment")]
    public static extern uint SimdGetAlignment();

    [DllImport(DllName, EntryPoint = "SDL_SIMDAlloc")]
    public static extern IntPtr SimdAlloc(uint length);

    [DllImport(DllName, EntryPoint = "SDL_SIMDRealloc")]
    public static extern IntPtr SimdRealloc(IntPtr memory, uint length);

    [DllImport(DllName, EntryPoint = "SDL_SIMDFree")]
    public static extern void SimdFree(IntPtr ptr);
}