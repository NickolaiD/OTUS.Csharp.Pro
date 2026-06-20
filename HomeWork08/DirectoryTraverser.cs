using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork08
{
    public delegate void EventHandler(object sender, FileArgs e);
    public class DirectoryTraverser
    {
        public event EventHandler? FileFound;
        private bool _stopWork;
        public List<string> GetFiles(string rootPath)
        {
            var files = new List<string>();

            GetFilesRecursive(rootPath, files);
            return files;
        }

        private void GetFilesRecursive(string path, List<string> files)
        {
            if (_stopWork)
            {
                return;
            }

            FileFound += (s, e) => { };
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
                    var fileArgs = new FileArgs() { Message = $"Найден файл {file}" };
                    FileFound(this, fileArgs);
                    if (fileArgs.StopWork)
                    {
                        _stopWork = true;  // возможность отмены дальнейшего поиска
                    }
                }
            }
            catch
            {
            }
        }
    }
}