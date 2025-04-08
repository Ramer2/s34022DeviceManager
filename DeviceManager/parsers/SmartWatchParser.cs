using DeviceManager.devices;

namespace DeviceManager.parsers;

/// <summary>
/// Parses data to create an instance of SmartWatch class.
/// </summary>
public class SmartWatchParser : IDeviceParser
{
    /// <summary>
    /// Parses a string array into a SmartWatch instance.
    /// </summary>
    /// <param name="parts">The array containing device data.</param>
    /// <returns>A parsed SmartWatch instance, or null if parsing fails.</returns>
    public Device? Parse(string[] parts)
    {
        if (parts.Length < 4) return null;
        if (!bool.TryParse(parts[2].Trim(), out var isOn)) return null;
        if (!int.TryParse(parts[3].Replace("%", "").Trim(), out var battery)) return null;
        return new SmartWatch(parts[0].Trim(), parts[1].Trim(), isOn, battery);
    }
}