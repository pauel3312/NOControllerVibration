using HarmonyLib;

namespace NOCV.Patches;

[HarmonyPatch(typeof(AoAFeedback))]
public class AoAFeedbackPatch
{
    [HarmonyPatch(nameof(AoAFeedback.RunAoAFeedback))]
    [HarmonyPostfix]
    public static void AoAFeedbackPostfix(Aircraft aircraft)    
    {
        if (aircraft == null) return;
        if (aircraft.name == "AttackHelo1")
        {
            NOCV.Logger.LogDebug(AoAFeedback.shake);
            return; // TODO figure out a custom formula maybe
        }
        GameManager.playerInput.SetVibration(1, AoAFeedback.shake*(1/AoAFeedback.aoaEffects.ShakeFactor));
    }

    [HarmonyPatch(nameof(AoAFeedback.SetupAircraft))]
    [HarmonyPostfix]
    public static void SetupAircraftPostfix(Aircraft aircraft)
    {
        if (aircraft == null) return;
    //     NOCV.Logger.LogDebug($"{AoAFeedback.aoaEffects.OnsetSpeed}:{AoAFeedback.aoaEffects.FullVolumeSpeed}");
    //     NOCV.Logger.LogDebug($"{AoAFeedback.aoaEffects.OnsetAlpha}:{AoAFeedback.aoaEffects.FullVolumeAlpha}");
    //     NOCV.Logger.LogDebug(AoAFeedback.aoaEffects.ShakeFactor);
    NOCV.Logger.LogDebug(aircraft.name);
    }
}