using DeviceManager.devices;

namespace DeviceManager.parsers;

public interface IDeviceParser
{
    Device? Parse(string[] parts);
}