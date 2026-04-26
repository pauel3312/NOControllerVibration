using NOCV.Features;

namespace NOCV.Helpers;

/// <summary>
/// Base class for vibration channel users.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class VibChannelUser<T> where T : VibChannelUser<T>
{
    internal static VibrationChannel? Channel;

    /// <summary>
    /// Sets up the vibration feedback by creating a channel in the vibration service.
    /// </summary>
    public static void Setup()
    {
        if (Channel != null) return;
        Channel = new VibrationChannel();
        VibrationService.AddChannel(Channel);
    }
}