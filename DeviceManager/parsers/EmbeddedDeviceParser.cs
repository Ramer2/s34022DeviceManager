using System.Text.RegularExpressions;
using DeviceManager.devices;

namespace DeviceManager.parsers;

public class EmbeddedDeviceParser : IDeviceParser
{
    public Device? Parse(string[] parts)
    {
        if (parts.Length < 4) return null;
        var ip = parts[2].Trim();
        var network = parts[3].Trim();
        if (!Regex.IsMatch(ip, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$")) return null;
        return new EmbeddedDevice(parts[0].Trim(), parts[1].Trim(), false, ip, network);
    }
}