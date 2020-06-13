using System;
using System.IO.Ports;
using System.Threading;

namespace COMLibrary {
    class ReadyOperation : IOperation {
        public int MyProperty {
            get {
                throw new NotImplementedException();
            }

            set {
                throw new NotImplementedException();
            }
        }

        public object Execute(SerialPort port, CommandsOperInfo info) {
            string result = null;
            while (true) {
                int outTime = 10000;
                port.WriteLine(info.Value);
                Thread.Sleep(1000);
                while (true) {
                    string readvalue = port.ReadExisting();
                    if (readvalue.Contains(info.ResultValue1)) {
                        Console.WriteLine(readvalue);
                        result = "OK";
                        return result;
                    }
                    outTime -= 1000;
                    if (outTime == 0) {
                        break;
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
