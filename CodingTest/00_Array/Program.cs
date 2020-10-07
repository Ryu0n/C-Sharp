using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Lotto lotto = new Lotto();
        }
    }

    class Lotto
    {
        private int[] numbers;

        public Lotto()
        {
            GetNumber();
            ShowResults();
        }

        private void GetNumber()
        {
            Random random = new Random();
            numbers = new int[6];

            int index = 0;

            while (index < numbers.Length)
            {
                int randomNumber = random.Next(1, 46);

                Console.WriteLine("New number is : " + randomNumber);

                if (!IsContainNumber(randomNumber))
                {
                    numbers[index] = randomNumber;
                    index++;
                }
            }
        }

        private bool IsContainNumber(int randomNumber)
        {
            foreach (int number in numbers)
            {
                if (number.Equals(randomNumber))
                {
                    Console.WriteLine(randomNumber + " is already contained!");
                    return true;
                }
            }
            return false;
        }

        private void ShowResults()
        {
            Console.WriteLine("\n <RESEULT> \n");

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            while (true)
            {

            }
        }
    }





    //    // int 자료형의 최대, 최소값
    //    int max = int.MaxValue;
    //    int min = int.MinValue;
}
