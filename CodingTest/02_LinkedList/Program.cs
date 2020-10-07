using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _02_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            list.AddFirst(0);

            Node<int> find = list.Find(3);

            list.AddAfter(find, 100);
            list.Remove(find);

            Console.WriteLine(find.Data);
            Console.WriteLine(list.ToString());





            // 이중 연결 리스트 : .Net Framework 안에는 내부적으로 이중 연결로 구현.
            LinkedList<int> number = new LinkedList<int>();
            number.AddFirst(10);
            number.AddLast(20);
            number.AddLast(30);
            number.AddFirst(9);

            LinkedListNode<int> nodeTemp = number.Find(20);

            number.AddAfter(nodeTemp, 21);
            number.AddBefore(nodeTemp, 19);

            number.Remove(10);

            for(var node = number.First; node != null; node = node.Next)
            {
                Console.WriteLine(node.Value);
            }



            // 원형 연결 리스트 : 이중 연결 리스트 구조 + 처음 노드와 마지막 노드가 연결되어 있는 구조
            // 마지막 노드.Next = 처음 노드 , 처음 노드.Before = 마지막 노드
            





            while (true) { }
        }
    }

    // 단순 연결 리스트 : 단방향 연결이기 때문에 순차적으로 탐색을 할 수 밖에 없다.
    public class SinglyLinkedList<T>
    {
        private Node<T> head;

        override
        public string ToString()
        {
            var temp = head;
            string data = "";

            while (temp != null)
            {
                data += (temp.Data.ToString())+" ";
                temp = temp.Next;
            }

            return data;
        }

        public void AddLast(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> last = head;

                while(last.Next != null) // 맨 마지막까지 순회 : 맨 마지막 노드는 다음이 없기 (NULL) 때문에
                {
                    last = last.Next;
                }

                last.Next = node;
            }
        }

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);

            node.Next = head;

            head = node;
        }

        public void AddAfter(Node<T> findNode, T value)
        {
            Node<T> node = new Node<T>(value);

            node.Next = findNode.Next;

            findNode.Next = node;
        }

        public Node<T> Find(T value)
        {
            if (head != null)
            {
                Node<T> valueNode = new Node<T>(value);
                Node<T> node = head;

                while(node != null)
                {
                    if (node.Data.Equals(valueNode.Data))
                    {
                        break;
                    }

                    node = node.Next;
                }

                return node;
            }
            else
            {
                return null;
            }
        }

        public void Remove(Node<T> removeNode)
        {
            Node<T> node = head;
            Node<T> beforeNode = null;

            while (node != removeNode)
            {
                beforeNode = node;
                node = node.Next;
            }

            if (beforeNode == null)
            {
                head = removeNode.Next;
            }
            else
            {
                beforeNode.Next = removeNode.Next;
                removeNode = null;
            }
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        // 생성자
        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
