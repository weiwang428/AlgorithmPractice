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
            GetSumN(600);
            PrintSumInput();

            Console.ReadLine();
        }

        /// <summary>
        /// Calculate the sum from 1 to n.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The sum from 1 to n.</returns>
        public static int GetSumN(int n)
        {
            int sum = 0;
            if (n < 0)
                throw new ArgumentException("n must be a positive integer!");
            else
            {
                try
                {                
                    checked { sum = n * (n + 1) / 2; }
                }
                catch {
                    throw new ArgumentException("n is too big!");
                }
            }
            System.Console.WriteLine(sum);
            return sum;
        }

        /// <summary>
        /// Print the sum of user input.
        /// </summary>
        /// <returns>If convert succesfully, return true.</returns>
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

        /// <summary>
        /// Find the element which just occurs one time in an array.
        /// </summary>
        /// <param name="input">the list you want to search</param>
        /// <returns>A list includs all the odds elements</returns>
        public static List<int> FindOddElm(List<int> input)
        {
            return input.GroupBy(x => x).Where(i => i.Count() == 1).Select(k => k.Key).ToList();
        }


        /// <summary>
        /// Find the most frequently occurring element in a list.
        /// </summary>
        /// <param name="input">The list you want to search</param>
        /// <returns>the elements occurs the most times</returns>
        public static int FindMaxOccurrenceElm(List<int> input)
        {
            return input.GroupBy(x => x).OrderBy(i => i.Count()).Select(k => k.Key).LastOrDefault<int>();
        }

        /// <summary>
        /// Find the most frequently occurring element in a list.
        /// </summary>
        /// <param name="M">The biggist number in the input array.</param>
        /// <param name="A">An array just includs positive number.</param>
        /// <returns></returns>
        public static int FindMaxOccurrenceElm1(int M, int[] A)
        {
            int n = A.Length;
            int[] count = new int[M + 1];
            for (int i = 0; i <= M; i++)
                count[i] = 0;
            int index = 0;
            int maxOccurence = 1;
            int tmp = 1;
            for (int i = 0; i < n; i++)
            {
                if (count[A[i]] > 0)
                {
                    tmp = count[A[i]] + 1;
                    if (tmp > maxOccurence)
                    {
                        maxOccurence = tmp;
                        index = i;
                    }
                    count[A[i]] = tmp;
                }
                else
                    count[A[i]] = 1;

            }
            return A[index];
        }

        /// <summary>
        /// Given a date time, return different strings by judging the time span between the given time and current time.
        /// </summary>
        /// <param name="date">Input time.</param>
        /// <param name="current">String to describe the input time.</param>
        /// <returns></returns>
        public static string Format(DateTime date, DateTime current)
        {
            // Define some constants here.
            const int MINUTES_IN_7_DAYS = 7 * 24 * 60;
            const int MINUTES_IN_1_DAYS = 1 * 24 * 60;
            const int MINUTES_IN_1_HOURS = 60;
            TimeSpan t_span = current - date;
            int total_minutes = Convert.ToInt32(Math.Floor(t_span.TotalMinutes));
            if (total_minutes >= MINUTES_IN_7_DAYS)
                return date.ToString("yyyy-MM-dd HH:mm");
            else if (total_minutes >= MINUTES_IN_1_DAYS)
                return String.Format("{0} day(s) ago", total_minutes / MINUTES_IN_1_DAYS);
            else if (total_minutes >= MINUTES_IN_1_HOURS)
                return String.Format("{0} hour(s) ago", total_minutes / MINUTES_IN_1_HOURS);
            else if (total_minutes > 0)
                return String.Format("{0} minute(s) ago", total_minutes);
            else if (total_minutes == 0)
                return "now";
            else
                throw new ArgumentException("The given date information for the function call is invalid.");
        }



        /// <summary>
        /// Given an array of N integers, return the smallest positive integer that does not occur in A.
        /// </summary>
        /// <param name="ary">The given array you want to search</param>
        /// <returns>The smallest integer which is missing in the input array.</returns>
        public static int FindSmallestMissingNum(int[] ary)
        {
            int i = 1;
            int len = ary.Length;
            while (true)
            {
                bool ifExist = false;
                for (int n = 0; n < len; n++)
                {
                    if (ary[n] == i)
                    {
                        ifExist = true;
                        break;
                    }
                }
                if (ifExist)
                    i++;
                else
                    return i;
            }
        }





    }
}
