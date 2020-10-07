using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 1, 2, 3, 5, 12, 13, 31, 53, 56 };

            Program p = new Program();

            Console.WriteLine(data[p.BinarySearch(data, 31)]);

            while(true) { }
        }

        /*
         탐색의 큰 분류 2가지

        
        1. 선형 탐색 알고리즘 - 정렬되어 있음을 전재로 한다.
        eg. 리스트, 어레이, 스택, 큐 ..

        (1) 선형탐색 Linear Search
        (2) 이진탐색 Binary Search
        (3) 해싱 Hashing

        2. 비선형 탐색 알고리즘
        eg. 트리, 그래프

        (1) DFS : 스택 사용
        (2) BFS : 큐 사용

        우선 DFS와 BFS를 사용하기 위해서는 인접행렬 혹은 인접리스트를 만들어야 한다.
         */

        public int BinarySearch(int[] data, int find)
        {
            int right = data.Length - 1;

            for (int left = 0; left <= right;)
            {
                // 우측과 좌측의 중앙값
                int middle = (left + right) / 2;

                // 찾고자 하는 값이 중앙값보다 크냐 작냐에 따라 탐색을 하고자 하는 범위를 좁혀나간다.
                switch (Compare(find, data[middle]))
                {
                    case '>': left = middle + 1; break;
                    case '<': right = middle - 1; break;
                    case '=': return middle;
                }
            }

            return -1;
        }

        public char Compare(int x, int y)
        {
            if (x > y)
                return '>';
            else if (x < y)
                return '<';
            else
                return '=';
        }


        public void DFS_Recursive(int[][] connection, Boolean[] visited, int vertex)
        {
            int size = connection.Length - 1;

            visited[vertex] = true;

            for (int i = 0; i <= size; i++)
            {
                if (connection[vertex][i] == 1 && !visited[i])
                {
                    DFS_Recursive(connection, visited, i);
                }
            }
        }

        public void DFS(int[][] connection, Boolean[] visited, int vertex, Boolean flag)
        {
            Stack<int> stack = new Stack<int>();

            int size = connection.Length - 1;

            stack.Push(vertex);
            visited[vertex] = true;

            while (!stack.Count.Equals(0))
            {
                int vv = stack.Peek();
                flag = false;

                for (int i = 0; i <= size; i++)
                {
                    if (connection[vv][i] == 1 && !visited[i])
                    {
                        stack.Push(i);
                        visited[i] = true;
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    stack.Pop();
                }
            }
        }

        public void BFS(int[][] connection, Boolean[] visited, int vertex)
        {
            Queue<int> queue = new Queue<int>();

            int size = connection.Length - 1;

            queue.Enqueue(vertex);
            visited[vertex] = true;

            while (!queue.Count.Equals(0))
            {
                vertex = queue.Dequeue();

                for (int i = 0; i <= size; i++)
                {
                    if (connection[vertex][i] == 1 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
    }
}
