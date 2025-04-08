using DeviceManager.exceptions;

namespace DeviceManager.devices;

/// <summary>
/// Represents a personal computer device.
/// </summary>
public class PersonalComputer : Device
{
    private string _operatingSystem { get; set; }

    /// <summary>
    /// Initializes a new instance of the PersonalComputer class.
    /// </summary>
    /// <param name="id">The unique device ID.</param>
    /// <param name="name">The name of the device.</param>
    /// <param name="isOn">Indicates whether the device is initially turned on.</param>
    /// <param name="os">The operating system of the computer.</param>
    public PersonalComputer(string id, string name, bool isOn, string os) : base(id, name, isOn)
    {
        _operatingSystem = os;
    }

    /// <summary>
    /// Turns on the computer, ensuring the operating system is set.
    /// </summary>
    public override void TurnOn()
    {
        if (string.IsNullOrEmpty(_operatingSystem))
            throw new EmptySystemException();
        
        base.TurnOn();
    }
    
    /// <summary>
    /// Returns a string representation of the device.
    /// </summary>
    /// <returns>A formatted string containing device details.</returns>
    public override string ToString()
    {
        return $"{base.ToString()} - {_operatingSystem}";
    }
}