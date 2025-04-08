using DeviceManager.devices;

namespace DeviceManager.deviceManager;

public interface IDeviceManager
{
    /// <summary>
    /// Retrieves a device by its unique identifier.
    /// </summary>
    /// <param name="id">The unique device ID.</param>
    /// <returns>The device if found; otherwise, null.</returns>
    Device? GetDeviceById(string id);

    /// <summary>
    /// Displays all stored devices.
    /// </summary>
    void ShowAllDevices();

    /// <summary>
    /// Adds a new device to the collection.
    /// </summary>
    /// <param name="device">The device to be added.</param>
    void AddDevice(Device device);

    /// <summary>
    /// Edits an existing device with updated information.
    /// </summary>
    /// <param name="id">The unique ID of the device to be updated.</param>
    /// <param name="updatedDevice">The updated device details.</param>
    void EditDevice(string id, Device updatedDevice);

    /// <summary>
    /// Removes a device by its unique identifier.
    /// </summary>
    /// <param name="id">The unique ID of the device to be removed.</param>
    void RemoveDevice(string id);

    /// <summary>
    /// Saves the current list of devices to the specified file.
    /// </summary>
    void SaveToFile();
}