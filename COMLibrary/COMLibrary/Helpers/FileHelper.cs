using System;

namespace COMLibrary
{
   static  class FileHelper
    {
        public static string enviromentPath = Environment.CurrentDirectory;
        public static string ReadConfigFile(string filePath) {
            string file = null;
           // string path = enviromentPath + "\\" + fileName;
            Console.WriteLine(filePath);
            if (System.IO.File.Exists(filePath)) {
                file = System.IO.File.ReadAllText(filePath);
            }
            else { 
            
            }
            return file;
        }
    }
}
