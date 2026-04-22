using HarmonyLib;

namespace NOCV.Patches;

/// <summary>
/// Game manager patches
/// </summary>
[HarmonyPatch(typeof(GameManager))]
public class GameManagerPatches
{
    /// <summary>
    /// Test entrypoint, will try to send vibration when the game loads a mission.
    /// </summary>
    /// <param name="__instance"></param>
    [HarmonyPostfix]
    [HarmonyPatch(nameof(GameManager.SetupGame))]
    public static void SetupGamePostfix()
    {
        NOCV.Logger.LogDebug("In postfix");
        foreach (var controller in GameManager.playerInput.controllers.Joysticks)
        {
            NOCV.Logger.LogDebug($"{controller._hardwareName};{controller.hatCount};{controller.axisCount};{controller.axis2DCount};{controller.vibrationMotorCount}");
        }
    }
}