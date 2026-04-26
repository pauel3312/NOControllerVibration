using HarmonyLib;
using NOCV.Helpers;

namespace NOCV.Patches;

/// <summary>
///     Add vibration to CargoRamps
/// </summary>
[HarmonyPatch(typeof(CargoRamp))]

public class CargoRampPatches: VibChannelUser<CargoRampPatches>
{
    /// <summary>
    /// Adds vibration to opening of cargoRamps
    /// </summary>
    /// <param name="__instance"></param>
    [HarmonyPatch(nameof(CargoRamp.Opening))]
    [HarmonyPostfix]
    public static void OpeningPostfix(CargoRamp __instance)
    {
        if (!GameManager.IsLocalAircraft(__instance.GetComponentInParent<AeroPart>().parentUnit)) return;
        Channel!.SetVibration(0.5f, 0);
    }

    /// <summary>
    /// Adds vibration to open state of cargoRamps
    /// </summary>
    /// <param name="__instance"></param>
    [HarmonyPatch(nameof(CargoRamp.Open))]
    [HarmonyPostfix]
    public static void OpenPostfix(CargoRamp __instance)
    {
        if (!GameManager.IsLocalAircraft(__instance.GetComponentInParent<AeroPart>().parentUnit)) return;
        Channel!.Disable();
    }

    [HarmonyPatch(nameof(CargoRamp.Closing))]
    [HarmonyPostfix]
    public static void ClosingPostfix(CargoRamp __instance)
    {
        if (!GameManager.IsLocalAircraft(__instance.GetComponentInParent<AeroPart>().parentUnit)) return;
        if (!__instance.enabled)
        {
            Channel!.Disable();
            return;
        }
        Channel!.SetVibration(0.5f, 0);
        
    }
}