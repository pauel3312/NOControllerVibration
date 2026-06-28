using HarmonyLib;
using NOCV.Features;
using NuclearOption.Networking;

namespace NOCV.Patches;

[HarmonyPatch(typeof(Aircraft))]
internal class CleanupOnAircraftDisable
{
    [HarmonyPatch(nameof(Aircraft.DisableUnit))]
    [HarmonyPrefix]
    [HarmonyPriority(Priority.High)]
    internal static void DisableVibration(Aircraft __instance)
    {
        if (!(__instance.GetPlayer()?.IsLocalPlayer ?? false)) return;
        VibrationService.Instance?.Cancel();
    }
}