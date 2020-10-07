using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _049_Collection
{
    /*
     
    콜렉션 (Collection)
    - 데이터 저장, 검색, 기타 데이터 처리 특화
    - 가변형 자료구조
    - 선언방법, 참조방법, 중요 메소드
     


     */

    class Program
    {
        static void Main(string[] args)
        {
            // 어레이 리스트
            // 어레이 리스트를 만들 수 있는 두 가지 방법

            // 1. 객체 생성하는 방법
            ArrayList arrList = new ArrayList();
            // 2. 생성된 배열을 어레이 리스트의 생성자에 인자로 넣는 방법
            int[] arrData = { 100, 200, 300 };
            ArrayList arrCopyList = new ArrayList(arrData);

            // Add는 모든 타입을 다 받을 수 있다.
            arrList.Add("Hello");
            arrList.Add(10f);

            for (int i = 0; i < 10; i++)
            {
                arrList.Add(i);
            }

            foreach (object data in arrList)
            {
                Console.WriteLine("arrList data : " + data);
            }
            
            foreach (object data in arrCopyList)
            {
                Console.WriteLine(data);
            }




            // 큐
            // 큐를 생성할 수 있는 두 가지 방법
            // 1. 객체 생성
            Queue queue = new Queue();
            // 2. 생성자에 배열 인자 대입
            Queue queueCopy = new Queue(arrData);

            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            // peek() : 꺼내지 않고 최전방 확인
            Console.WriteLine("queue data : {0}", queue.Peek());

            while (queue.Count > 0)
            {
                Console.WriteLine("queue data : {0}, queue count : {1}", queue.Dequeue(), queue.Count);
            }




            // 스택
            Stack stack = new Stack();

            Stack stackCopy = new Stack(arrData);

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            // peek() : 꺼내지 않고 최전방 확인
            Console.WriteLine("stack data : {0}", stack.Peek());

            while (stack.Count > 0)
            {
                Console.WriteLine("stack data : {0}, stack count : {1}", stack.Pop(), queue.Count);
            }




            // 해쉬 테이블
            // 키와 값이 쌍으로 구성되는 데이터
            // 탐색 속도가 빠르다
            Hashtable hashTable = new Hashtable();
            hashTable.Add("pos", 10);
            hashTable.Add("name", "Jack");
            hashTable["weight"] = 10.8f;

            foreach(object key in hashTable.Keys)
            {
                Console.WriteLine("key : {0}, data : {1}", key, hashTable[key]);
            }

            Hashtable hashTableCopy = new Hashtable
            {
                ["pos"] = 10,
                ["name"] = "Jane",
                ["weight"] = 10.8f
            };

            foreach (object key in hashTableCopy.Keys)
            {
                Console.WriteLine("key : {0}, data : {1}", key, hashTableCopy[key]);
            }


            while (true) { }
        }
    }
}
