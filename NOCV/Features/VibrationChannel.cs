namespace NOCV.Features;

/// <summary>
/// Class for declaring vibration channels for deconfliction.
/// </summary>
public class VibrationChannel
{
    /// <summary>
    /// Vibration amount for low intensity rumble
    /// </summary>
    public float LowAmount;
    /// <summary>
    /// Vibration amount for high intensity rumble
    /// </summary>
    public float HighAmount;

    /// <summary>
    /// Duration the effect on this channel lasts in seconds. 
    /// </summary>
    public float Duration = float.PositiveInfinity;

    /// <summary>
    /// Whether this is outputting something
    /// </summary>
    public bool Enabled => LowAmount != 0 || HighAmount != 0;
    
    /// <summary>
    /// Sets the vibration for this channel.
    /// </summary>
    /// <param name="low"></param>
    /// <param name="high"></param>
    public void SetVibration(float low, float high) => SetVibration(low, high, float.PositiveInfinity);

    /// <summary>
    /// Sets the vibration for this channel.
    /// </summary>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <param name="dur">duration in seconds</param>
    public void SetVibration(float low, float high, float dur)
    {
        LowAmount = low;
        HighAmount = high;
        Duration = dur;
    }

    /// <summary>
    /// Sets vibration motor amount based on vibration motor indices like before
    /// </summary>
    /// <param name="motor"></param>
    /// <param name="magnitude"></param>
    public void setVibrationOnMotorIndex(int motor, float magnitude)
    {
        switch (motor)
        {
            case 0:
                HighAmount = magnitude;
                break;
            case 1:
                LowAmount = magnitude;
                break;
        }
        Duration = float.PositiveInfinity;
    }

    /// <summary>
    ///     Disable this channel.
    /// </summary>
    public void Disable()
    {
        LowAmount = 0;
        HighAmount = 0;
        Duration = float.PositiveInfinity;
    }
    
}