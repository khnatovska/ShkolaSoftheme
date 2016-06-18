using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = "C:\\Program Files\\folder\\inner\\name here.html";
            var read = OpenForRead(line);
            var write = OpenForWrite(line);
            var readWrite = OpenFile(line, FileAccessEnum.Write | FileAccessEnum.Read);

            Console.WriteLine("File open for read");
            Console.WriteLine("Read mode: {0}", read.AccessMode(FileAccessEnum.Read));
            Console.WriteLine("Write mode: {0}", read.AccessMode(FileAccessEnum.Write));

            Console.WriteLine("File open for write");
            Console.WriteLine("Read mode: {0}", write.AccessMode(FileAccessEnum.Read));
            Console.WriteLine("Write mode: {0}", write.AccessMode(FileAccessEnum.Write));

            Console.WriteLine("File open for read/write");
            Console.WriteLine("Read mode: {0}", readWrite.AccessMode(FileAccessEnum.Read));
            Console.WriteLine("Write mode: {0}", readWrite.AccessMode(FileAccessEnum.Write));
            
            Console.ReadLine();
        }

        public static FileHandle OpenForRead(string path)
        {
            return new FileHandle(path, FileAccessEnum.Read);
        }

        public static FileHandle OpenForWrite(string path)
        {
            return new FileHandle(path, FileAccessEnum.Write);
        }

        public static FileHandle OpenFile(string path, FileAccessEnum access)
        {
            return new FileHandle(path, access);
        }
    }
}
