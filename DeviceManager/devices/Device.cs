namespace DeviceManager.devices;

/// <summary>
/// Represents a generic device with basic properties and functionality.
/// </summary>
public class Device
{
    /// <summary>
    /// Unique identifier of the device.
    /// </summary>
    public string _id {get; set;}
    
    /// <summary>
    /// Name of the device.
    /// </summary>
    public string _name {get; set;}
    
    /// <summary>
    /// Indicator for whether the device is turned on.
    /// </summary>
    public bool _isOn {get; set;}

    /// <summary>
    /// Initializes a new instance of the Device class.
    /// </summary>
    /// <param name="id">The unique device ID.</param>
    /// <param name="name">The name of the device.</param>
    /// <param name="isOn">Indicator for whether the device is initially turned on.</param>
    public Device(string id, string name, bool isOn)
    {
        _id = id;
        _name = name;
        _isOn = isOn;
    }
    
    /// <summary>
    /// Turns the device on.
    /// </summary>
    public virtual void TurnOn() => _isOn = true;
    
    /// <summary>
    /// Turns the device off.
    /// </summary>
    public virtual void TurnOff() => _isOn = false;

    /// <summary>
    /// Returns a string representation of the device.
    /// </summary>
    /// <returns>A formatted string containing device details.</returns>
    public override string ToString()
    {
        return $"{_id} - {_name} - {(_isOn ? "On" : "Off")}";
    }
}