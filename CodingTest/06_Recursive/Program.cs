using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             함수 내부에서 자기 자신을 반복적으로 호출하는 것을 의미한다.
            반복하기 때문에 종료 조건이 필요하다.
             */

            Program p = new Program();

            Console.WriteLine(p.Factorial(3));
            Console.WriteLine(p.Factorial(3));
            Console.WriteLine(p.SigmaFibonacciBottomTop(3, 0, 1, 1));
            while (true) { }
        }

        public int Factorial(int number)
        {
            int result = 0;

            if (number == 1) // 종료 조건
            {
                result = 1;
            }
            else
            {
                result = number * Factorial(number - 1);
            }

            return result;
        }

        public int SigmaFibonacciBottomTop(int endSequence, int recursive, int first, int second)
        {
            int result = 0;

            if (recursive.Equals(endSequence)) // 종료 조건
            {
                result = second;
            }
            else
            {
                recursive++;
                result = second + SigmaFibonacciBottomTop(endSequence, recursive, second, first + second);

                if (recursive.Equals(1))
                {
                    result += first;
                }            
            }

            return result;
        }


        public int Fibonacci(int sequence)
        {
            int result = 0;

            if (sequence == 1 || sequence == 2) // 종료 조건
            {
                result = 1;
            }
            else
            {
                result = Fibonacci(sequence - 1) + Fibonacci(sequence - 2);
            }

            return result;
        }

    }
}
