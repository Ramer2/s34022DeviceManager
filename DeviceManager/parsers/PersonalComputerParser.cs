using DeviceManager.devices;

namespace DeviceManager.parsers;

/// <summary>
/// Parses data to create an instance of PersonalComputer class.
/// </summary>
public class PersonalComputerParser : IDeviceParser
{
    /// <summary>
    /// Parses a string array into a PersonalComputer instance.
    /// </summary>
    /// <param name="parts">The array containing device data.</param>
    /// <returns>A parsed PersonalComputer instance, or null if parsing fails.</returns>
    public Device? Parse(string[] parts)
    {
        if (!bool.TryParse(parts[2].Trim(), out var isOn)) return null;
        var os = parts.Length > 3 ? parts[3].Trim() : "NoOS";
        return new PersonalComputer(parts[0].Trim(), parts[1].Trim(), isOn, os);
    }
}