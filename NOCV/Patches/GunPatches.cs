using System.Linq;
using HarmonyLib;
using NOCV.Helpers;

namespace NOCV.Patches;

/// <summary>
/// Adds vibration feedback on gunshots 
/// </summary>
[HarmonyPatch(typeof(PilotPlayerState))]
public class GunPatches: VibChannelUser<GunPatches>
{
    private static bool? _shouldVibrateNextFrame = PluginConfig.GunVibrationToggleFrame.Value ? true : null;
    
    /// <summary>
    ///     Vibration feedback on bullet spawn.
    /// </summary>
    /// <param name="__instance"></param>
    /// <param name="pilot"></param>
    [HarmonyPostfix]
    [HarmonyPatch(nameof(PilotPlayerState.UpdateState))]
    // ReSharper disable once InconsistentNaming
    public static void PilotUpdateStatePostfix(PilotPlayerState __instance, Pilot pilot)
    {
        if (pilot.aircraft.weaponStations.SelectMany(station => station.Weapons.OfType<Gun>()).Any(gun => gun.enabled))
        {
            Channel!.SetVibration(0f, PluginConfig.GunFiringAmount.Value * (_shouldVibrateNextFrame ?? true ? 1f : 0f));
            _shouldVibrateNextFrame = !_shouldVibrateNextFrame;
        }        
        else
        {
            Channel!.Disable();
            _shouldVibrateNextFrame = _shouldVibrateNextFrame == null ? null : true;
        }    
    }
}