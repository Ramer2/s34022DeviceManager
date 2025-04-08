using DeviceManager.devices;
using DeviceManager.parsers;

namespace DeviceManager.deviceManager;

/// <summary>
/// Manages a collection of devices, including adding, editing, removing,
/// and persisting devices to a file.
/// </summary>
public class DeviceManager : IDeviceManager
{
    private readonly List<Device> _devices = [];
    private const int MaxDevices = 15;
    private readonly string _filePath;

    /// <summary>
    /// Initializes a new instance of the DeviceManager class.
    /// </summary>
    /// <param name="path">The file path for loading and saving devices.</param>
    private DeviceManager(string path)
    {
        _filePath = path;
        LoadDevices();
    }

    /// <summary>
    /// Creates a new instance of the DeviceManager class.
    /// </summary>
    /// <param name="path">The file path for storing device data.</param>
    /// <returns>A new instance of DeviceManager.</returns>
    public static DeviceManager Create(string path)
    {
        return new DeviceManager(path);
    }
    
    /// <summary>
    /// Loads devices from the specified file.
    /// </summary>
    private void LoadDevices()
    {
        if (!File.Exists(_filePath)) return;
    
        foreach (var line in File.ReadAllLines(_filePath))
        {
            var parts = line.Split(',');
    
            var parser = DeviceParserFactory.GetParser(parts[0].Trim());
            var device = parser?.Parse(parts);
    
            if (device != null) AddDevice(device);
        }
    }
    
    /// <summary>
    /// Retrieves a device by its unique identifier.
    /// </summary>
    /// <param name="id">The unique device ID.</param>
    /// <returns>The device if found; otherwise, null.</returns>
    public Device? GetDeviceById(string id)
    {
        return _devices.FirstOrDefault(d => d._id == id);
    }

    /// <summary>
    /// Adds a new device to the collection.
    /// </summary>
    /// <param name="device">The device to be added.</param>
    public void AddDevice(Device device)
    {
        if (_devices.Count >= MaxDevices)
        {
            Console.WriteLine("Device storage full.");
            return;
        }
    
        if (_devices.Any(d => d._id == device._id))
        {
            Console.WriteLine($"Device with ID {device._id} already exists. Cannot add duplicate.");
            return;
        }
    
        _devices.Add(device);
        Console.WriteLine($"Device {device._id} successfully added.");
    }

    /// <summary>
    /// Edits an existing device with updated information.
    /// </summary>
    /// <param name="id">The unique ID of the device to be updated.</param>
    /// <param name="updatedDevice">The updated device details.</param>
    public void EditDevice(string id, Device updatedDevice)
    {
        var existingDevice = _devices.FirstOrDefault(d => d._id == id);
        if (existingDevice == null)
        {
            Console.WriteLine($"No device found with ID {id}.");
            return;
        }
        
        _devices.Remove(existingDevice);
        updatedDevice._id = id;
        
        AddDevice(updatedDevice);
        Console.WriteLine($"Device {id} successfully updated.");
    }

    /// <summary>
    /// Removes a device by its unique identifier.
    /// </summary>
    /// <param name="id">The unique ID of the device to be removed.</param>
    public void RemoveDevice(string id)
    {
        _devices.RemoveAll(d => d._id == id);
        Console.WriteLine($"Device {id} removed.");
    }

    /// <summary>
    /// Displays all stored devices.
    /// </summary>
    public void ShowAllDevices()
    {
        foreach (var device in _devices)
            Console.WriteLine(device);
    }

    /// <summary>
    /// Saves the current list of devices to the specified file.
    /// </summary>
    public void SaveToFile()
    {
        try
        {
            using (var writer = new StreamWriter(_filePath, false))
            {
                foreach (var device in _devices)
                {
                    writer.WriteLine(device.ToString());
                }
            }
            Console.WriteLine("Devices successfully saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }
}

/// <summary>
/// Factory class for creating instances of DeviceManager.
/// </summary>
public static class DeviceManagerFactory
{
    /// <summary>
    /// Creates a new DeviceManager instance with the given file path.
    /// </summary>
    /// <param name="filePath">The file path where devices are stored.</param>
    /// <returns>An instance of DeviceManager.</returns>
    public static IDeviceManager CreateDeviceManager(string filePath)
    {
        return DeviceManager.Create(filePath);
    }
}
