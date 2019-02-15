
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace lab1_3

{

    class Program

    {

        private static void Dublikat(string[] s, int n) // Method dublicate with 2 parameters

        {
            int j = 0;//variable j for array ss
            string[] ss = new string[n * 2]; // String array 

            for (int i = 0; i < n; ++i)//loop to repeat every element in array

            {

                ss[j++] = s[i]; // Doubling

                ss[j++] = s[i];

            }

            for (int i = 0; i < 2 * n; ++i)//loop to print out all elements(dublicate and original)

                Console.Write(ss[i] + " ");//print out all elements(dublicate and original)


        }

        static void Main(string[] args)

        {

            int n = int.Parse(Console.ReadLine()); // reading first line

            string[] a = Console.ReadLine().Split(); // reading second line an array of string by split

            Dublikat(a, n); // Method thats dubplicate each of element

        }

    }

}