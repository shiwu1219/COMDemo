using System;
using System.IO.Ports;
using System.Threading;

namespace COMLibrary {
    class SendOperation : IOperation {
        public object Execute(SerialPort port, CommandsOperInfo info) {
            int i = 0;
            port.WriteLine(info.Value);
            Thread.Sleep(1000);
            while (true) {
                string readvalue1 = port.ReadExisting();
                if (readvalue1.Contains(info.ResultValue1)) {
                    Console.WriteLine(readvalue1);
                    i = 1;
                    Thread.Sleep(1000);
                    while (true) {
                        string readvalue2 = port.ReadExisting();
                        if (readvalue2.Contains(info.ResultValue2)) {
                            Console.WriteLine(readvalue2);
                            i = 2;
                            break;
                        }
                    }
                    return i;
                }
            }
        }
    }
}
