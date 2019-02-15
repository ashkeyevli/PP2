
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.IO;

namespace Task3

{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:/Users/User/Desktop/PP2/Week1/Task1");//directory for presenting information
            PrintInfo(dir, 0);//calls method PrintInfo
        }
        static void PrintInfo(FileSystemInfo fsi, int k)//method for showing files and directories
        {
            string s = new string(' ', k);//string with gap
            Console.WriteLine(s + fsi.Name);//wrotes with gap files
            if (fsi.GetType() == typeof(DirectoryInfo))// if it's have an directory also in it
            {
                FileSystemInfo[] arr = ((DirectoryInfo)fsi).GetFileSystemInfos();//array for showing files in directory
                for (int i = 0; i < arr.Length; i++)//shows files and directories in root directory
                {
                    PrintInfo(arr[i], k + 3);// and 3 ' ' before new directory files
                }
            }
        }
    }
}