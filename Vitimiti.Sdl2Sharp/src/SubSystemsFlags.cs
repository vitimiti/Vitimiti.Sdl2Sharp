namespace Vitimiti.Sdl2Sharp;

[Flags]
public enum SubSystemsFlags : uint
{
    None = 0x00000000U,
    Timer = 0x00000001U,
    Audio = 0x00000010U,
    Video = 0x00000020U,
    Joystick = 0x00000200U,
    Haptic = 0x00001000U,
    GameController = 0x00002000U,
    Events = 0x00004000U,
    Sensor = 0x00008000U,
    [Obsolete("for compatibility, this flag is ignored", false)]
    NoParachute = 0x00100000U,
    Everything = None | Timer | Audio | Video | Joystick | Haptic | GameController | Events | Sensor
}