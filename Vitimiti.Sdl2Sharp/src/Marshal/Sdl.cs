using System.Runtime.InteropServices;

namespace Vitimiti.Sdl2Sharp.Marshal;

internal static partial class Sdl
{
    public const string DllName = "SDL2";

    [DllImport(DllName, EntryPoint = "SDL_Init")]
    public static extern int Init(SystemFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_InitSubSystem")]
    public static extern int InitSubSystems(SystemFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_QuitSubSystem")]
    public static extern void QuitSubSystems(SystemFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_WasInit")]
    public static extern SystemFlags WasInit(SystemFlags flags);

    [DllImport(DllName, EntryPoint = "SDL_Quit")]
    public static extern void Quit();
}