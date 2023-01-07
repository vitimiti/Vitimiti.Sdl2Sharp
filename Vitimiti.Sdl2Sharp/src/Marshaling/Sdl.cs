using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2Sharp.Marshaling;

internal static partial class Sdl
{
    public const string DllName = "SDL2";

    [DllImport(DllName, EntryPoint = "SDL_Init")]
    public static extern int Init(SubSystemsFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_InitSubSystem")]
    public static extern int InitSubSystems(SubSystemsFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_QuitSubSystem")]
    public static extern void QuitSubSystems(SubSystemsFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_WasInit")]
    public static extern SubSystemsFlags WasInit(SubSystemsFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_Quit")]
    public static extern void Quit();
}