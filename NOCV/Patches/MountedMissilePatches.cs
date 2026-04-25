using HarmonyLib;
using UnityEngine;

namespace NOCV.Patches;

/// <summary>
/// Add vibration to missile launches
/// </summary>
[HarmonyPatch(typeof(MountedMissile))]
public class MountedMissilePatches
{
    /// <summary>
    /// Add vibration on missile shots.
    /// </summary>
    /// <param name="__instance"></param>
    /// <param name="owner"></param>
    /// <param name="target"></param>
    /// <param name="inheritedVelocity"></param>
    /// <param name="weaponStation"></param>
    /// <param name="aimpoint"></param>
    [HarmonyPrefix]
    [HarmonyPatch(nameof(MountedMissile.Fire))]
    public static void FirePatch(MountedMissile __instance, Unit owner, Unit target, Vector3 inheritedVelocity,
        WeaponStation weaponStation, GlobalPosition aimpoint)
    {
        if (!owner.IsLocalPlayer || __instance.fired) return;
        GameManager.playerInput.SetVibration(0, 1f, 0.1f, false);
    }
}