using System;
using System.Threading.Tasks;
using Rewired;

namespace NOCV.Features;

/// <summary>
///     Service that contains all the vibration helper functions
/// </summary>
public static class VibService
{
    /// <summary>
    /// Sets vibration for a motor after waiting a delay
    /// </summary>
    /// <param name="mi">motor Index</param>
    /// <param name="ml">Level (0 to 1)</param>
    /// <param name="dur">duration (milliseconds)</param>
    /// <param name="delay">delay to wait before sending the vibration</param>
    public static async void SetVibrationAfter(int mi, float ml, float dur, int delay)
    {
        try
        {
            await Task.Delay(delay);
            GameManager.playerInput.SetVibration(mi, ml, dur);
        }
        catch (Exception) { /* Ignored */ }
    }

    /// <summary>
    /// Starts a gun vibration effect for the given duration.
    /// </summary>
    /// <param name="dur">Duration of the effect in milliseconds.</param>
    public static async void GunVibrationEffectFor(float dur)
    {
        try
        {
            for (var i = 0; i < dur; i += 200)
            {
                GameManager.playerInput.SetVibration(1, 0.5f, 0.2f);
                GameManager.playerInput.SetVibration(0, 1f, 0.1f);
                await Task.Delay(200);
            }
        }
        catch (Exception) { /* Ignored */ }
    }
}