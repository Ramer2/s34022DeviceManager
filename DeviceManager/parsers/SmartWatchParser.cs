using DeviceManager.devices;

namespace DeviceManager.parsers;

public class SmartWatchParser : IDeviceParser
{
    public Device? Parse(string[] parts)
    {
        if (parts.Length < 4) return null;
        if (!bool.TryParse(parts[2].Trim(), out var isOn)) return null;
        if (!int.TryParse(parts[3].Replace("%", "").Trim(), out var battery)) return null;
        return new SmartWatch(parts[0].Trim(), parts[1].Trim(), isOn, battery);
    }
}