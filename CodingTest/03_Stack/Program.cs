using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             선입후출, 후입선출, FILO, LIFO

            PUSH, POP, IsFull, IsEmpty, Peek (값은 빼지않고 확인만)
            최상단은 TOP
             */

            ArrayStack stack = new ArrayStack(10);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while(stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }







            // .Net Framework에서 제공하는 스택
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(10);
            stack1.Push(100);
            Console.WriteLine(stack1.Peek());
            Console.WriteLine(stack1.Peek());
            Console.WriteLine(stack1.Peek());








            while (true) { }
        }
    }

    class ArrayStack
    {
        private int[] space;
        private int top;
        public int Count // 전체 자료의 갯수를 의미.
        {
            get
            {
                return top + 1;
            }
        }

        public ArrayStack(int size)
        {
            space = new int[size];
            top = -1;
        }

        public void Push(int value)
        {
            top++;
            space[top] = value;
        }

        public int Pop()
        {
            int value = space[top];

            space[top] = 0;

            top--;

            return value;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == space.Length - 1;
        }
    }
}
