using System.Text.RegularExpressions;
using DeviceManager.exceptions;
using ArgumentException = DeviceManager.exceptions.ArgumentException;

namespace DeviceManager.devices;

/// <summary>
/// Represents an embedded device with network connectivity.
/// </summary>
public class EmbeddedDevice : Device
{
    /// <summary>
    /// IP address of the embedded device.
    /// </summary>
    public string IpAddress { get; private set; }
    
    private string _networkName { get; set; }

    /// <summary>
    /// Indicator for whether the device is connected to a network.
    /// </summary>
    public bool _isConnected { get; set; }

    /// <summary>
    /// Initializes a new instance of the EmbeddedDevice class.
    /// </summary>
    /// <param name="id">The unique device ID.</param>
    /// <param name="name">The name of the device.</param>
    /// <param name="isOn">Indicates whether the device is initially turned on.</param>
    /// <param name="ip">The IP address of the device.</param>
    /// <param name="network">The network name.</param>
    public EmbeddedDevice(string id, string name, bool isOn, string ip, string network) : base(id, name, isOn)
    {
        SetIPAddress(ip);
        _networkName = network;
        _isConnected = false;
    }

    /// <summary>
    /// Sets the IP address of the device.
    /// </summary>
    /// <param name="ip">The new IP address.</param>
    public void SetIPAddress(string ip)
    {
        if (!Regex.IsMatch(ip, @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$"))
            throw new ArgumentException();
        
        IpAddress = ip;
    }

    /// <summary>
    /// Connects the device to the network.
    /// </summary>
    public void Connect()
    {
        if (!_networkName.Contains("MD Ltd."))
            throw new ConnectionException();
        
        _isConnected = true;
        Console.WriteLine($"{_name} connected successfully.");
    }

    /// <summary>
    /// Disconnects the device from the network.
    /// </summary>
    public void Disconnect()
    {
        if (!_isConnected)
        {
            Console.WriteLine($"{_name} is already disconnected.");
            return;
        } 
        _isConnected = false;
        Console.WriteLine($"{_name} was disconnected.");
    }
    
    /// <summary>
    /// Turns the device on.
    /// </summary>
    public override void TurnOn()
    {
        Connect();
        base.TurnOn();
    }

    /// <summary>
    /// Turns the device off.
    /// </summary>
    public override void TurnOff()
    {
        Disconnect();
        base.TurnOff();
    }

    /// <summary>
    /// Returns a string representation of the device.
    /// </summary>
    /// <returns>A formatted string containing device details.</returns>
    public override string ToString()
    {
        return $"{base.ToString()} - {IpAddress} - {_networkName}";
    }
}