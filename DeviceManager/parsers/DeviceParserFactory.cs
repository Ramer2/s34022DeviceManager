using DeviceManager.parsers;

namespace DeviceManager.deviceManager;

public static class DeviceParserFactory
{
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