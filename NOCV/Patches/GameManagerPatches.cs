using HarmonyLib;
using NOCV.Features;
using NOCV.Helpers;

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
     [HarmonyPostfix]
     [HarmonyPatch(nameof(GameManager.SetupGame))]
     public static void SetupGamePostfix()
     {
         foreach (var controller in GameManager.playerInput.controllers.Joysticks)
         {
             NOCV.Logger.LogDebug($"{controller._hardwareName}; has {controller.vibrationMotorCount} motors; {(controller.supportsVibration ? "supports vibration" : "Does not support vibration")}");
         }
         VibOnAudioSources.Initialize();
         VibrationService.Initialize();
         AoAFeedbackPatch.Setup();
         BayDoorPatches.Setup();
         GearVibrationPatch.Setup();
         GunPatches.Setup();
         MountedMissilePatches.Setup();
         VRSWarningPatch.Setup();
     }
}   