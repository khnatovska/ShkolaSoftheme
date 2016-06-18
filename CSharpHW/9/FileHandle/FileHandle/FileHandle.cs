using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandle
{
    public struct FileHandle
    {
        public int FileSize;
        public string FileName;
        public string FilePath;
        public FileAccessEnum FileAccess;

        public FileHandle(string name, int size, string path, FileAccessEnum access)
        {
            FileName = name;
            FileSize = size;
            FilePath = path;
            FileAccess = access;
        }

        public FileHandle(string path, FileAccessEnum access)
        {
            FilePath = path;
            FileAccess = access;
            FileSize = 1;
            FileName = ParseFileNameFromPath(path);
        }

        static string ParseFileNameFromPath(string path)
        {
            var splitPath = path.Split('\\', '.');
            return splitPath[splitPath.Length - 2];
        }

        public bool AccessMode(FileAccessEnum access)
        {
            return FileAccess.HasFlag(access);
        }
    }
}
