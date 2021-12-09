using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TextAdventure.FileHandler
{
    static class Handler
    {
        private static string currentSavePath = Environment.CurrentDirectory;

        public static void OverwriteFile (string relPath, string dataName, string text) {
            string directoryPath = currentSavePath + relPath;
            string path = currentSavePath + relPath + "/" +  dataName;
            if (File.Exists(path))
            {
                File.WriteAllText(path, text);
            } else {
                Directory.CreateDirectory(directoryPath);
                File.WriteAllText(path, text);
            }           
        }
        public static void WriteLineToFile(string relPath, string dataName, string text)
        {
            string directoryPath = currentSavePath + relPath;
            string path = currentSavePath + relPath + "/" + dataName;
            if (File.Exists(path))
            {
                string oldText = File.ReadAllText(path) + "\r\n";
                File.WriteAllText(path, oldText + text);
            } else {
                Directory.CreateDirectory(directoryPath);                
                File.WriteAllText(path, text);
            } 
        }
        public static string ReadFile(string relPath, string dataName)
        {
            string s = "";
            string path = currentSavePath + relPath + "/" +  dataName;
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path)) {
                    while (!sr.EndOfStream) {
                        s += " " + sr.ReadLine();
                    }
                }
            }
            return s;
        }

        public static void ReadJSON (string relPath, string dataName) {

        }
    }

    
}