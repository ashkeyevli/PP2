using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Task1

{
    class Program

    {
        static void Main(string[] args)

        {
 StreamReader sr = new StreamReader("C:/Users/User/Desktop/PP2/Week2/Task1/ababa.txt");//directory to the file with notes
            string s = sr.ReadToEnd();//READ STRING FROM .TXT FILE
            bool check = true;
            for (int i = 0; i < s.Length; i++)//loop which checks every letter in the string
             {
                if (s[i] != s[s.Length - 1 - i])//check 1st letter with the latest 
                {
                    check = false;//if it is not polindrome check is false
                }
            }
            if (check==true)//if it is polindrome
            {
                Console.WriteLine("Yes");// it will print out YES which means polindrome
            }
            else
            {
                Console.WriteLine("No");//if it is not polindrome it prints No

            }
        }
    }
}