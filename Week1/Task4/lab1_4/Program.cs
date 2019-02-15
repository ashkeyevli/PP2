using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // reading the variable "n"  from console 
            string[,] a = new string[n, n]; // creating two-dimesional array with the lengthes "n" that called "a"
            for (int i = 0; i < n; i++) // loop from "0" to "n"
            {
                for (int j = 0; j <= i; j++) // second loop from "0" to "i"
                {
                    a[i, j] = "[*]"; // saves in array at the cordinate [i,j] symbol "*"
                    Console.Write(a[i, j]); // prints in console "*" in [i,j] cordinates
                }
                Console.WriteLine(); // pulls down one line
            }

        }
    }
}
