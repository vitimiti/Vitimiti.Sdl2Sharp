using System.Diagnostics.CodeAnalysis;

using Vitimiti.Sdl2Sharp.Marshaling;
using Vitimiti.Sdl2Sharp.Utilities;

namespace Vitimiti.Sdl2Sharp;

public sealed class Systems : IDisposable
{
    private bool _disposedValue;

    public static SubSystemsFlags InitializedSystemFlags => Sdl.WasInit(SubSystemsFlags.Everything);

    public static Version Version
    {
        get
        {
            Sdl.GetVersion(out var version);
            return new Version(version.Major, version.Minor, version.Patch);
        }
    }

    public static string Revision => Sdl.GetRevision();
    public static Version SupportedVersion => new(2, 0, 20);

    public Systems(SubSystemsFlags flags)
    {
        var code = Sdl.Init(flags);
        if (code < 0)
        {
            throw new SdlSharpException(Sdl.GetError(), code);
        }
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
            }

            Sdl.Quit();
            _disposedValue = true;
        }
    }

    ~Systems()
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

    [SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "Avoid using this function outside of the dispose pattern.")]
    public void StartSubSystems(SubSystemsFlags flags)
    {
        var code = Sdl.InitSubSystems(flags);
        if (code < 0)
        {
            throw new SdlSharpException(Sdl.GetError(), code);
        }
    }

    [SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "Avoid using this function outside of the dispose pattern.")]
    public void StopSubSystems(SubSystemsFlags flags)
    {
        Sdl.QuitSubSystems(flags);
    }
}