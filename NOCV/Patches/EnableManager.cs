using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;
using NOCV.Features;
using NuclearOption.Networking;

namespace NOCV.Patches;

[HarmonyPatch]
internal class EnableManager
{
    [HarmonyPatch]
    public static class EjectionVibrationPatch
    {
        [UsedImplicitly]
        public static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(Aircraft), nameof(Aircraft.StartEjectionSequence));
            yield return AccessTools.Method(typeof(Aircraft), nameof(Aircraft.CmdStartEjectionSequence));
        }

        [HarmonyPrefix]
        [HarmonyPriority(Priority.High)]
        internal static void DisableVibrationOnEject(Aircraft __instance)
        {
            if (!(__instance.GetPlayer()?.IsLocalPlayer ?? false)) return;
            VibrationService.Instance?.enabled = false;
        }
    }

    [HarmonyPatch(typeof(Pilot), nameof(Pilot.ApplyDamage))]
    [HarmonyPostfix]
    internal static void DisableVibrationOnPilotDead(Pilot __instance, float pierceDamage, float blastDamage,
        float fireDamage, float impactDamage)
    {
        if (!__instance.dead || __instance.ejected || !(__instance.player?.IsLocalPlayer ?? false)) return;
        VibrationService.Instance?.enabled = false;
    }

    [HarmonyPatch(typeof(QuitMissionButton), nameof(QuitMissionButton.onClick))]
    [HarmonyPostfix]
    internal static void DisableVibrationOnQuitMission(QuitMissionButton __instance)
    {
        VibrationService.Instance?.enabled = false;
    }
    
    [HarmonyPatch(typeof(Player), nameof(Player.SetAircraft))]
    [HarmonyPrefix]
    public static void PlayerSetAircraftPrefix(Player __instance, Aircraft aircraft)
    {
        if (!__instance.IsLocalPlayer) return;
        VibrationService.Instance?.enabled = true;
    }
}