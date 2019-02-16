using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager2
{
    class Layer
    {
        private int selectedItem;
        public int SelectedItem
        {
            get
            {
                return selectedItem;//property for getting selected item
            }
            set
            {
                if (value >= Content.Count)
                {
                    selectedItem = 0;//novigation if you in the end of directories you will return to up
                }
                else if (value < 0)
                {
                    selectedItem = Content.Count - 1;//if you at the top you will return to down
                }
                else
                {
                    selectedItem = value;//just novigation
                }
            }
        }


        public List<FileSystemInfo> Content// method for content
        {
            get;
            set;
        }
        public void Rename(FileSystemInfo fInfo)//method for renaming
        {
            if (fInfo.GetType() == typeof(DirectoryInfo))
            {
                DirectoryInfo y = fInfo as DirectoryInfo;
                for (int i = 1; i <= 2; i++) // creating space for writing name from console
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("Enter new name:"); //writing in console for user 

                string s = Console.ReadLine(); // name that user enter
                string path = y.Parent.FullName;
                string newname = Path.Combine(path, s); // because there is no command in c# for juct renaming name od diredctory
                y.MoveTo(newname); // we will move file to the same path with new name
            }
            else
            {
                FileInfo y = fInfo as FileInfo; // creatin class fileinfo
                for (int i = 1; i <= 2; i++) // creating space for writing name from console
                {
                    Console.WriteLine();
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("  ");
                }
                Console.Write("Enter new name:"); //writing in console for user 

                string s = Console.ReadLine();//reading from console
                string newname = Path.Combine(y.Directory.FullName, s);
                y.MoveTo(newname);//renaming to ne name
            }
        }


        public void DeleteSelectedItem()//method for deleting files
        {
            FileSystemInfo fileSystemInfo = Content[selectedItem];
            if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
            {
                Directory.Delete(fileSystemInfo.FullName, true);//deletes directory
            }
            else
            {
                File.Delete(fileSystemInfo.FullName);//deletes file
            }
            Content.RemoveAt(selectedItem);//remove item
            selectedItem--;//makes interface after deleting file(directory)
        }
        public void Draw()//method ofr visualization
        {
            Console.BackgroundColor = ConsoleColor.Black;//in interface background will be color
            Console.Clear();
            for (int i = 0; i < Content.Count; ++i)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Red;//selected item will be red color
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;//if it is not selected it is as background black
                }
                Console.WriteLine((i + 1) + ". " + Content[i].Name);//shows items(files and directory) in console(EX. 1. PP2)
            }
        }
    }
    enum FARMode//declare an enumeration
    {
        DIR,//directory
        FILE//files
    }
    class Program
    {
        static void Main(string[] args)
        {
            FARMode mode = FARMode.DIR;
            DirectoryInfo root = new DirectoryInfo(@"C:/Users/User/test2");//directory which showed
            Stack<Layer> history = new Stack<Layer>();//by stack princep last in first out
            history.Push(
                    new Layer
                    {
                        Content = root.GetFileSystemInfos().ToList(),
                        SelectedItem = 0
                    }
                );
            while (true)
            {
                if (mode == FARMode.DIR)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)//controling by keybord
                {
                    case ConsoleKey.Delete://key delete
                        history.Peek().DeleteSelectedItem();//deletes directory or file
                        break;
                    case ConsoleKey.UpArrow://arraw up
                        history.Peek().SelectedItem--;//novigation to up of list
                        break;
                    case ConsoleKey.DownArrow://arrow down
                        history.Peek().SelectedItem++;//novigation to down of list
                        break;
                    case ConsoleKey.F2: // console key for renaming
                        history.Peek().Rename(history.Peek().Content[history.Peek().SelectedItem]);
                        break;//renames file or directory
                    case ConsoleKey.Backspace://key backspase
                        if (mode == FARMode.DIR)
                        {
                            history.Pop();//novigation to privews directory
                        }
                        else
                        {
                            mode = FARMode.DIR;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Enter://selecting file or directory
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))//if selected item is directory
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
                            history.Push(
                               new Layer
                               {
                                   Content = directoryInfo.GetFileSystemInfos().ToList(),
                                   SelectedItem = 0
                               });//novigation by directory
                        }
                        else
                        {
                            mode = FARMode.FILE;//if it is file
                            Console.BackgroundColor = ConsoleColor.White;//background of file
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;//foreground of file
                            using (StreamReader sr = new StreamReader(fileSystemInfo.FullName))//reads selected item
                            {
                                Console.WriteLine(sr.ReadToEnd());//readsallfile
                            }
                        }
                        break;

                }
            }
        }
    }
}