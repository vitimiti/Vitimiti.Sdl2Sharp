using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using Vitimiti.Sdl2Sharp.Marshaling;

namespace Vitimiti.Sdl2Sharp;

public sealed class Systems : IDisposable
{
    private bool _disposedValue;

    public static SubSystemsFlags InitializedSystemFlags => Sdl.WasInit(SubSystemsFlags.Everything);

    public Systems(SubSystemsFlags flags)
    {
        var code = Sdl.Init(flags);
        if (code < 0)
        {
            throw new ExternalException(Sdl.GetError(), code);
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
            throw new ExternalException(Sdl.GetError(), code);
        }
    }

    [SuppressMessage("Performance", "CA1822: Mark members as static", Justification = "Avoid using this function outside of the dispose pattern.")]
    public void StopSubSystems(SubSystemsFlags flags)
    {
        Sdl.QuitSubSystems(flags);
    }
}