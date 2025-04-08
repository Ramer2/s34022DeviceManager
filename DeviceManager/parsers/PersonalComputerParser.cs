using DeviceManager.devices;

namespace DeviceManager.parsers;

public class PersonalComputerParser : IDeviceParser
{
    public Device? Parse(string[] parts)
    {
        if (!bool.TryParse(parts[2].Trim(), out var isOn)) return null;
        var os = parts.Length > 3 ? parts[3].Trim() : "NoOS";
        return new PersonalComputer(parts[0].Trim(), parts[1].Trim(), isOn, os);
    }
}