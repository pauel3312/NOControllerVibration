using HarmonyLib;
using NuclearOption.Networking;

namespace NOCV.Patches;

/// <summary>
/// Adds vibration feedback on gunshots 
/// </summary>
[HarmonyPatch(typeof(Gun))]
public class GunPatches
{
    /// <summary>
    ///     Vibration feedback on bullet spawn.
    /// </summary>
    /// <param name="__instance"></param>
    /// <param name="timeOffset"></param>
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Gun.SpawnBullet))]
    // ReSharper disable once InconsistentNaming
    public static void SpawnBulletPrefix(Gun __instance, float timeOffset)
    {
        if (!(__instance.attachedUnit.GetPlayer()?.IsLocalPlayer ?? false)) return;
        GameManager.playerInput.SetVibration(0, 1f, 0.1f, false);
    }
}