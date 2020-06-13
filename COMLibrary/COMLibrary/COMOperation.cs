using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace COMLibrary {
    public class COMOperation
    {
        private static SerialPort port;
        private const string configName = "config.json";
        private const string commandCfgName = "Commands.json";
        private static CommandLoader loader = new CommandLoader(commandCfgName);

        public int IdlePort(string command) {
            try {
               // ConnectCOM();

                Dictionary<string, string> dic = new Dictionary<string, string>();
                
                string result = loader.ExecuteOper(port, command).ToString();
                if (result != null) {
                    return 0;
                }
              
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
               
            }
            return 1;
        }

        public void ExecuteOperation(string command) {
            loader.ExecuteOper(port, command);
        }

        public void ConnectCOM(string configPath) {
            InitCOM(configPath);
            OpenPort();
        }

        private void InitCOM(string configPath) {
            string loadConfig = configPath + configName;
            string json = FileHelper.ReadConfigFile(configName);

            ConfigHelper config = JsonConvert.DeserializeObject<ConfigHelper>(json);
            port = new SerialPort();
            COMHelper.SetPortProperty(port, config);
        }

        private void OpenPort() {
            port.Open();
        }
    }
}
