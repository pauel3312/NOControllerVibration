using HarmonyLib;

namespace NOCV.Patches;

/// <summary>
///     Patches the AoA feedback class to add vibration feedback.
/// </summary>
[HarmonyPatch(typeof(AoAFeedback))]
public class AoAFeedbackPatch
{
    /// <summary>
    /// Main AoA feedback patch (this function alone is like 80% of the feeling of vibration feedback lol)
    /// </summary>
    /// <param name="aircraft"></param>
    [HarmonyPatch(nameof(AoAFeedback.RunAoAFeedback))]
    [HarmonyPostfix]
    public static void AoAFeedbackPostfix(Aircraft aircraft)    
    {
        if (aircraft == null) return;
        GameManager.playerInput.SetVibration(1, AoAFeedback.shake*(1/AoAFeedback.aoaEffects.ShakeFactor));
    }
    
    // [HarmonyPatch(nameof(AoAFeedback.SetupAircraft))]
    // [HarmonyPostfix]
    // public static void SetupAircraftPostfix(Aircraft aircraft)
    // {
    //     if (aircraft == null) return;
    // //     NOCV.Logger.LogDebug($"{AoAFeedback.aoaEffects.OnsetSpeed}:{AoAFeedback.aoaEffects.FullVolumeSpeed}");
    // //     NOCV.Logger.LogDebug($"{AoAFeedback.aoaEffects.OnsetAlpha}:{AoAFeedback.aoaEffects.FullVolumeAlpha}");
    // //     NOCV.Logger.LogDebug(AoAFeedback.aoaEffects.ShakeFactor);
    // NOCV.Logger.LogDebug(aircraft.name);
    // }
}