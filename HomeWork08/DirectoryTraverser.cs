using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork08
{
    public delegate void OnFileFound(object sender, OnFileFoundEventArgs e);
    public class DirectoryTraverser
    {
        public event OnFileFound OnFileFound;
        public List<string> GetFiles(string rootPath)
        {
            var files = new List<string>();
            GetFilesRecursive(rootPath, files);
            return files;
        }

        private void GetFilesRecursive(string path, List<string> files)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    GetFilesRecursive(dir, files);
                }

                string[] currentFiles = Directory.GetFiles(path);
                foreach (string file in currentFiles)
                {
                    files.Add(file);
                    OnFileFound(this, new OnFileFoundEventArgs() { Message = "Найден файл" });
                }
            }
            catch
            {
            }
        }
    }

    public class OnFileFoundEventArgs : EventArgs
    {
        public string Message { get; set; } = string.Empty;
    }
}