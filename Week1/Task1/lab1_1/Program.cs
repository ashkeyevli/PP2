using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine()); // reading from the console variable "n", where is "n" length of array
            int[] all = new int[n]; // creating array "all" with the length "n" for all numbers
            int[] prime = new int[n]; // creating array "prime" with the length "n" where prime numbers will be saved
            string line2 = Console.ReadLine(); // reads the future elements of array
            string[] s = line2.Split(); // it splits the string to the new array
            int checker = 0;  // creating counter that called "checker"
            int cnt = 0; // creating counter that called "cnt"
            for (int i = 0; i < n; i++) // loop to make a identifing operations "n" times for the "prime" number
            {
                all[i] = int.Parse(s[i]); // it converts the splited array to another array
                if (all[i] == 1) // 1 is not prime number
                {
                    checker++; // counter increases to "1"
                }
                for (int j = 2; j <= all[i] / 2; j++) // this loop checks from "2", to the half of the number
                {
                    if (all[i] % j == 0) //checking is the current array number is divided to numbers from 2 to the half of all[i] without the rest
                    {
                        checker++; // if yes counter increses to 1
                    }

                }
                if (checker == 0) // if counter "checker" equals to "0", then it is prime number
                {
                    prime[cnt] = all[i]; // we save the prime numbers to new array
                    cnt++; // we counting the quantity of prime numbers
                }
                else // if counter "checker " more than "0", then it is not prime number
                {
                    checker = 0; // we are reseting counter to "0", we are doing it, two work with the new value of array, when loop with the "i" changes to the next
                }
            }
            Console.WriteLine(cnt); // printing the quantity of prime numbers
            for (int i = 0; i < cnt; i++) // loop for printing the numbers in second array up to quantity of prime numners
            {
                Console.Write(prime[i] + " "); // we print out this number to the console, and add the free space(" ")
            }
            Console.ReadKey();
        }
    }
}
