using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSumN(600);
            PrintSumInput();

            Console.ReadLine();
        }


        public static int PrintSumN(int n)
        {
            int sum = 0;
            if (n < 0)
                throw new ArgumentException("n must be a positive integer!");
            else
            {
                try
                {
                    while (n > 0)
                    {
                        checked { sum += n; n--; }
                    }
                }
                catch {
                    throw new ArgumentException("n is too big!");
                }
            }
            System.Console.WriteLine(sum);
            return sum;
        }


        public static bool PrintSumInput()
        {
            Console.WriteLine("please input sevral intergers, use \", \"to separate!");
            string num = Console.ReadLine();
            int sum = 0;
            try
            {
                int[] n = Array.ConvertAll(num.Split(','), s => int.Parse(s));              
                foreach (int i in n)
                {
                    sum += i;
                }
                System.Console.WriteLine(sum);
                return true;
            }
            catch {
                System.Console.WriteLine("input is illegal！");
                return false;
            }           
        }

    }
}
