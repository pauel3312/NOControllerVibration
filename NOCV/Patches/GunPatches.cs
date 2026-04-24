using HarmonyLib;

namespace NOCV.Patches;

[HarmonyPatch(typeof(Gun))]
public class GunPatches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Gun.SpawnBullet))]
    public static void SpawnBulletPrefix(Gun __instance, float timeOffset)
    {
        GameManager.playerInput.SetVibration(0, 1f, 0.1f, false);
    }
}