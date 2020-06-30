using System;
using System.IO;

namespace VCManager.Core
{
    public class Logger
    {
        private static string filePath = @"C:\tmp\VSManager.txt";
        public static void Write(string str)
        {
            try
            {
                using (StreamWriter sw= new StreamWriter(new FileStream(filePath, FileMode.Append)))
                {
                    string record = $"{DateTime.Now.ToString("O")}:{str}";
                    sw.Write(Environment.NewLine);
                    sw.Write(record);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
