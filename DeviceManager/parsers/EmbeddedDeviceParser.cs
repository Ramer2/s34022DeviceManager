using System.Text.RegularExpressions;
using DeviceManager.devices;

namespace DeviceManager.parsers;

/// <summary>
/// Parses data to create an instance of EmbeddedDevice class.
/// </summary>
public class EmbeddedDeviceParser : IDeviceParser
{
    /// <summary>
    /// Parses a string array into an EmbeddedDevice instance.
    /// </summary>
    /// <param name="parts">The array containing device data.</param>
    /// <returns>A parsed EmbeddedDevice instance, or null if parsing fails.</returns>
    public Device? Parse(string[] parts)
    {
        if (parts.Length < 4) return null;
        var ip = parts[2].Trim();
        var network = parts[3].Trim();
        if (!Regex.IsMatch(ip, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$")) return null;
        return new EmbeddedDevice(parts[0].Trim(), parts[1].Trim(), false, ip, network);
    }
}