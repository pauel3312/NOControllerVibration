using BepInEx.Configuration;

namespace NOCV;

/// <summary>
/// Plugin configuration class
/// </summary>
public static class PluginConfig
{
    internal static ConfigEntry<float> MachMultiplier = null!;
    private const float DefaultMachMultiplier = 1f;

    internal static ConfigEntry<float> AoAMultiplier = null!;
    private const float DefaultAoAMultiplier = 1f;
    
    // ReSharper disable InconsistentNaming
    internal static ConfigEntry<float> VRSThreshold = null!;
    private const float DefaultVRSThreshold = 0.1f;

    internal static ConfigEntry<float> VRSMult = null!;
    private const float DefaultVRSMult = 1f;
    // ReSharper restore InconsistentNaming
    

    internal static ConfigEntry<float> BayDoorVibrationValue = null!;
    private const float DefaultBayDoorVibrationValue = 0.25f;

    internal static ConfigEntry<float> CargoRampVibrationValue = null!;
    private const float DefaultCargoRampVibrationValue = 0.5f;

    internal static ConfigEntry<float> DetachPartVibrationValue = null!;
    private const float DefaultDetachPartVibrationValue = 1f;

    internal static ConfigEntry<float> DetachPartVibrationDuration = null!;
    private const float DefaultDetachPartVibrationDuration = 0.1f;


    internal static ConfigEntry<float> LatchGearVibrationAmount = null!;
    private const float DefaultLatchGearVibrationAmount = 0.4f;

    internal static ConfigEntry<float> RollingVibMax = null!;
    private const float DefaultRollingMax = 0.1f;

    internal static ConfigEntry<float> SliddingVibMax = null!;
    private const float DefaultSliddingMax = 0.5f;

    internal static ConfigEntry<float> GearMovingMax = null!;
    private const float DefaultGearMovingMax = 0.15f;



    internal static ConfigEntry<float> GunFiringAmount = null!;
    private const float DefaultGunFiringAmount = 1f;

    internal static ConfigEntry<float> GunFiringDuration = null!;
    private const float DefaultGunFiringDuration = 0.1f;

    internal static ConfigEntry<float> MissileFiringAmount = null!;
    private const float DefaultMissileFiringAmount = 0.5f;

    internal static ConfigEntry<float> MissileFiringDuration = null!;
    private const float DefaultMissileFiringDuration = 0.1f;
    
    internal static void InitSettings(ConfigFile config)
    {
        MachMultiplier = config.Bind("Aerodynamics", "Mach mult", DefaultMachMultiplier, "Vibration multiplier for the near-mach effects.");
        AoAMultiplier = config.Bind("Aerodynamics", "AoA multiplier", DefaultAoAMultiplier, "Vibration multiplier for the AoA effects.");
        VRSThreshold = config.Bind("Aerodynamics", "VRS threshold", DefaultVRSThreshold, "Vibration threshold for the VRS effects. Values are between 0 and 1.");
        VRSMult = config.Bind("Aerodynamics", "VRS multiplier", DefaultVRSMult, "Multiplier for the VRS vibration");
        
        BayDoorVibrationValue = config.Bind("Mechanical", "Bay door value", DefaultBayDoorVibrationValue, "Vibration value for bay doors (between 0 and 1).");
        CargoRampVibrationValue = config.Bind("Mechanical", "Cargo ramp value", DefaultCargoRampVibrationValue, "Vibration value for cargo ramps (between 0 and 1).");
        DetachPartVibrationValue = config.Bind("Mechanical", "Part break value", DefaultDetachPartVibrationValue, "Vibration value for parts breaking off your aircraft (between 0 and 1).");
        DetachPartVibrationDuration = config.Bind("Mechanical", "Part break duration", DefaultDetachPartVibrationDuration, "Vibration duration for parts breaking off your aircraft (in seconds).");
        
        LatchGearVibrationAmount = config.Bind("Landing Gear", "Gear latch", DefaultLatchGearVibrationAmount, "Vibration value for latch gear (between 0 and 1).");
        RollingVibMax = config.Bind("Landing Gear", "Rolling vibration", DefaultRollingMax, "Maximum vibration value for rolling (between 0 and 1).");
        SliddingVibMax = config.Bind("Landing Gear", "Slidding vibration", DefaultSliddingMax, "Maximum vibration value for slidding (between 0 and 1).");
        GearMovingMax = config.Bind("Landing Gear", "Gear moving vibration", DefaultGearMovingMax, "Maximum vibration value for gear moving (between 0 and 1).");
        
        GunFiringAmount = config.Bind("Weapons", "Gun firing", DefaultGunFiringAmount, "Vibration amount for gun fire (between 0 and 1).");
        GunFiringDuration = config.Bind("Weaponry", "Gun fire duration", DefaultGunFiringDuration, "Vibration duration for gun fire (in seconds). Triggered for every bullet.");
        MissileFiringAmount = config.Bind("Weapons", "Missile firing", DefaultMissileFiringAmount, "Vibration amount for Missile fire (between 0 and 1).");
        MissileFiringDuration = config.Bind("Weaponry", "Missile fire duration", DefaultMissileFiringDuration, "Vibration duration for Missile fire (in seconds). Triggered for every bullet.");

    }
}