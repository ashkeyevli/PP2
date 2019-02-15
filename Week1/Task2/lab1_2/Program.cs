using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_2
{
    class Student
    {
        string name; // creating variable "name"
        string id; // creating variable "id"
        int year; // creating variable "year"
        public Student(string n, string i, int y)
        {
            name = n; // "name" is equal to the string n
            id = i;  //  "id" is equal to the string id
            year = y;  // "year" is equal to the integer y
        }
        public void PrintInfo()
        {
            Console.WriteLine(name + " " + id + " " + year);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); // it reads the info from console
            string id = Console.ReadLine(); // it reads the info from console
            int year = int.Parse(Console.ReadLine()); // it reads the info from console
            Student student = new Student(name, id, year + 1);
            student.PrintInfo(); // it`s making the 

        }
    }
}
