using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;

namespace COMLibrary {
    public class CommandLoader {
       
        private SerialPort port;
        private string operationName;
        private string configJson;
        private CommandAssemble commandsAssemble;
        private const string assemblyName= "COMLibrary";

        public string ExecuteOper(SerialPort portTemp, string operName) {
            Init(portTemp, operName);
             string result = null;
            CommandsInfo commandsInfo = FindOperationCommandByName();

            foreach (CommandsOperInfo operinfo in commandsInfo.CommandsOperation) {
                string opername = operinfo.OperationName;
                Assembly assembly = Assembly.Load(assemblyName);
                Type type = assembly.GetType(assemblyName + "." + opername);
                IOperation op = (IOperation)Activator.CreateInstance(type);
                result =op.Execute(portTemp, operinfo).ToString();
            }
            return result;
        }


        public CommandLoader(string commandCfgName) {
            configJson = FileHelper.ReadConfigFile(commandCfgName);
            commandsAssemble = JsonConvert.DeserializeObject<CommandAssemble>(configJson);
        }

        private void Init(SerialPort portTemp, string operNameTemp) {
            port = portTemp;
            operationName = operNameTemp;
        }


        private CommandsInfo FindOperationCommandByName() {
            CommandsInfo commandsInfo = commandsAssemble.Commands.Where(o => o.CommandsName == operationName).FirstOrDefault();
            return commandsInfo;
        }
    }

    public class CommandAssemble {
        public List<CommandsInfo> Commands { get; set; }
    }

    public class CommandsInfo {
        public string CommandsName { get; set; }

        public List<CommandsOperInfo> CommandsOperation { get; set; }

    }

    public class CommandsOperInfo {
        public string OperationName { get; set; }

        public string Value { get; set; }

        public string ResultValue1 { get; set; }
        public string ResultValue2 { get; set; }
    }
}
