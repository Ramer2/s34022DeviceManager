namespace DeviceManager.parsers;

/// <summary>
/// Factory class for creating device parsers based on device ID prefixes.
/// </summary>
public static class DeviceParserFactory
{
    /// <summary>
    /// Retrieves the appropriate parser for a given device ID.
    /// </summary>
    /// <param name="deviceId">The device identifier.</param>
    /// <returns>An instance of IDeviceParser or null if no suitable parser is found.</returns>
    public static IDeviceParser? GetParser(string deviceId)
    {
        return deviceId.Split('-')[0] switch
        {
            "SW" => new SmartWatchParser(),
            "P" => new PersonalComputerParser(),
            "ED" => new EmbeddedDeviceParser(),
            _ => null
        };
    }
}