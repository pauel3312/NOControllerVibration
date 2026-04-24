using HarmonyLib;

namespace NOCV.Patches;

[HarmonyPatch(typeof(BayDoor))]
public class BayDoorPatches
{
    [HarmonyPatch(nameof(BayDoor.OpenDoor))]
    [HarmonyPostfix]
    public static void OpenDoorPatch(BayDoor __instance, float duration)
    {
        GameManager.playerInput.SetVibration(1, 0.25f, duration, false);
    }
}