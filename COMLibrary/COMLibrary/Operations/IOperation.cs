using System;
using System.IO.Ports;

namespace COMLibrary {
    public interface IOperation {

        object Execute(SerialPort port, CommandsOperInfo info);

    }
}
