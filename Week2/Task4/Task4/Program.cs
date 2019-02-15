using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
       {
            string path = @"C:/Users/User/Desktop/PP2/Week2/Task4/original.txt";//original path
            string pathcopy = @"C:/Users/User/Desktop/PP2/Week2/Task4/";//path for copy
            DirectoryInfo dirInfo = new DirectoryInfo(pathcopy);//class directory info
            FileInfo fi = new FileInfo(path);//class file info
            if (fi.Exists && dirInfo.Exists)//checking for necessary conditions by property .exists of class directoryinfo and fileinfo
            {
                fi.CopyTo(pathcopy + @"/Copy.txt", true);//copys original.txt to Copy.txt
                fi.Delete();//deletes original.txt
            }
            else
                Console.WriteLine("path or path1 not found:(");//if it has not necessary conditions, warning message
        }
    }
}