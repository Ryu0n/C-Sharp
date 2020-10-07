using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             선입선출 FIFO
            데이터 입력 (Enqueue) 데이터 빼기 (Dequeue)
            데이터 입구 (Rear) 데이터 출구 (Front)

            인덱스 = Read % 배열의 크기 : Enqueue를 계속 실행했을 때 배열의 크기를 벗어날 경우 다시 처음으로 돌아가서 값을 삽입하기 위해
             */

            /*
             우선순위 큐 : 들어온 값의 우선순위를 통해 재정렬하는 큐
            데큐 (Double-ended Queue) : 데이터 입구랑 출구가 양쪽에 있음.  Front와 Rear가 양쪽에 각각 존재해야 한다.
             */

            ArrayQueue queue = new ArrayQueue(5);

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);

            // Overflow
            queue.Enqueue(60);
            queue.Enqueue(70);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            // Underflow
            queue.Dequeue();
            queue.Dequeue();

            queue.Enqueue(60);
            queue.Enqueue(70);

            queue.ViewQueue();

            while (true) { }
        }
    }

    class ArrayQueue
    {
        private int[] space;

        private int size;

        private int front;
        private int rear;

        public ArrayQueue(int size)
        {
            space = new int[size];

            this.size = size;

            front = -1;
            rear = -1;
        }

        public void ViewQueue()
        {
            foreach(int n in space)
            {
                Console.WriteLine(n);
            }
        }

        public void Enqueue(int value)
        {
            rear++;

            if (rear - front > size) // 가득 찬 경우
            {
                Console.WriteLine("[Warning] Overflowed");
                rear--;
                return;
            }

            space[rear % size] = value;
        }

        public int Dequeue()
        {
            front++;

            if (front > rear) // 뽑을게 없는 경우
            {
                Console.WriteLine("[Warning] Underflowed");
                front = -1;
                rear = -1;

                return 0;
            }

            int value = space[front];
            space[front % size] = 0;

            return value;
        }
    }
}
