using System;
using System.IO.Ports;

namespace COMLibrary
{
    static class COMHelper
    {
        public static void SetPortProperty(SerialPort _serialPort, ConfigHelper _config) {
            _serialPort.PortName = _config.PortName;
            _serialPort.BaudRate = _config.BaudRate;
            _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _config.Parity);
            _serialPort.DataBits = _config.DataBits;
            _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _config.StopBits);
            _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), _config.Handshake);
            _serialPort.ReadTimeout = _config.ReadTimeout;
            _serialPort.WriteTimeout = _config.WriteTimeout;
        }


    }
}
