using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace NOCV.Features;

/// <summary>
///     Generic vibration service.
///     This is made to avoid conflicts of several different things trying to set vibration concurrently.
/// </summary>
public class VibrationService: MonoBehaviour
{
    /// <summary>
    /// The current instance of this class in game.
    /// </summary>
    public static VibrationService? Instance { get; set; }

    private static HashSet<VibrationChannel> _channels = []; 

    /// <summary>
    ///     Initializes the service.
    /// </summary>
    public static void Initialize()
    {
        if (Instance != null) return;

        var go = new GameObject("VibrationService");
        Instance = go.AddComponent<VibrationService>();
    }

    /// <summary>
    ///     Destroy the vibration service
    /// </summary>
    public static void Destroy()
    {
        if (Instance == null)
            return;
        Destroy(Instance.gameObject);
        Instance = null;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this) 
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Add a channel to this vibration service
    /// </summary>
    /// <returns>the new channel. Can be used later to send vibration values.</returns>
    public static void AddChannel(VibrationChannel channel)
    {
        _channels.Add(channel);
    }

    /// <inheritdocs/>
    public void FixedUpdate()
    {
        var totalHiVib = 0f;
        var totalLowVib = 0f;
        foreach (var channel in _channels.Where(channel => channel.Enabled))
        {
            if(!float.IsPositiveInfinity(channel.Duration))
            {
                channel.Duration -= Time.fixedDeltaTime;
                if (channel.Duration <= 0f)
                {
                    channel.SetVibration(0f, 0f);
                }
            }
            totalHiVib += channel.HighAmount;
            totalLowVib += channel.LowAmount;
        }
        GameManager.playerInput.SetVibration(0, Mathf.Clamp(totalHiVib, 0f, 1f), false);
        GameManager.playerInput.SetVibration(1, Mathf.Clamp(totalLowVib, 0f, 1f), false);
    }
}