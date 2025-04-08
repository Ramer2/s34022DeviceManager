using DeviceManager.devices;

namespace DeviceManager.parsers;

/// <summary>
/// Interface defining a device parser.
/// </summary>
public interface IDeviceParser
{
    /// <summary>
    /// Parses a string array into a Device instance.
    /// </summary>
    /// <param name="parts">The array containing device data.</param>
    /// <returns>A parsed Device instance, or null if parsing fails.</returns>
    Device? Parse(string[] parts);
}