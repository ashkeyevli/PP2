using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:/Users/User/Desktop/PP2/Week2/Task2/input.txt");// .txt file for reading data
            StreamWriter sw = new StreamWriter("C:/Users/User/Desktop/PP2/Week2/Task2/output.txt"); // .txt file where data will be written
            string s = sr.ReadToEnd();//read all text in file
            string[] ss = s.Split();// array where nubers will be saved
            for (int i = 0; i < ss.Length; i++)//loop for adding prime numbers
            {
                if (IsPrime(int.Parse(ss[i])))//check for prime

                {
                    sw.Write(ss[i] + " ");//writes prime numbers in output.txt
                }

            }
                        sw.Close();//closes output file
        }

        static bool IsPrime(int x)//method for checking prime number
            {
                if (x==1)//because 1 is not prime number 
                    return false;//it is not prime number
            for (int i = 2; i <= Math.Sqrt(x); ++i)//loop for checking prime
            {
                if (x % i == 0)//prime numbers id divisible for 1 and itself
                    return false;//if it is divisible it is not prime number
            }
                return true;//default(or like else) it is prime number

            }
        
    }
}
