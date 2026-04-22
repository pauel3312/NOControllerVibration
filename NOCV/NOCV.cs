using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace NOCV;


/// <summary>
/// Main plugin class.
/// </summary>
[BepInPlugin(PluginInfo.PLUGIN_GUID,PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
// ReSharper disable once InconsistentNaming
public class NOCV: BaseUnityPlugin
{

    private static Harmony? Harmony { get; set; }
    private static bool IsPatched { get; set; }
    internal new static ManualLogSource Logger { get; private set; } = null!;

    private void Awake()
    {
        Logger = base.Logger;

        PluginConfig.InitSettings(Config);
        PatchAll();
    }
    
    private static void PatchAll()
    {
        if (IsPatched)
        {
            Logger.LogWarning("Already patched!");
            return;
        }

        Logger.LogDebug("Patching...");

        Harmony ??= new Harmony(PluginInfo.PLUGIN_GUID);

        try
        {
            Harmony.PatchAll();
            IsPatched = true;
            Logger.LogDebug("Patched!");
        }
        catch (Exception e)
        {
            Logger.LogError($"Aborting server launch: Failed to Harmony patch the game. Error trace:\n{e}");
        }
    }
    
    private void UnpatchSelf()
    {
        if (Harmony == null)
        {
            Logger.LogError("Harmony instance is null!");
            return;
        }
        
        if (!IsPatched)
        {
            Logger.LogWarning("Already unpatched!");
            return;
        }

        Logger.LogDebug("Unpatching...");

        Harmony.UnpatchSelf();
        IsPatched = false;

        Logger.LogDebug("Unpatched!");
    }


}