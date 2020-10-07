using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            //int[] data = { 20, 15, 1, 5, 10 };
            //int[] data = { 25, 15, 60, 45, 10, 20, 5, 30 };
            int[] data = { 20, 35, 15, 5, 40, 10, 25, 30 };

            //p.BubbleSort(data);

            //p.SelectionSort(data);

            //p.InsertionSort(data);

            p.QuickSort(data, 0, data.Length - 1);

            //p.CreateHeap(data);
            //p.Show(data);
            //int[] sorted = p.HeapTree2Array(data);
            //p.Show(sorted);

            while (true) { }
        }


        public void Show(int[] data)
        {
            foreach (int num in data)
            {
                Console.Write(num + " ");
            }
            Console.Write("\n");
        }


        /*
        ref 키워드 : 변수의 레퍼런스를 인자로 넘기기 위함.
        레퍼런스는 해당 변수를 가르키기 때문에 레퍼런스를 인자로 넘긴 함수 내에서
        변수를 수정하면 실제 변수에도 영향을 끼친다. (Call by reference)
         */
        public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /*
         * 버블정렬
         서로 <이웃한 데이터들을 비교>하며 <가장 큰 데이터를 가장 뒤로> 보내는 방식

        1. 첫 번째 데이터와 두 번째 데이터를 비교하여 첫 번째 값이 더 크면 두 번째 데이터와 교환한다.
        2. 두 번째 데이터와 세 번재 데이터를 비교하여 더 큰수를 뒤로 보낸다.
        3. 이렇게 끝까지 진행하면 제일 큰 숫자가 맨 뒤로 가게 된다.
        4. 이렇게 계속 처음부터 n-1, n-2, n-3 ... 번째 데이터를 비교해서 정렬하는 알고리즘이다.

        시간복잡도 : O(n^2)
         */
        public void BubbleSort(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - 1 - i; j++)
                {
                    if (data[j] > data[j+1])
                    {
                        Swap(ref data[j], ref data[j+1]);
                    }
                    Show(data);
                }
            }
        }

        /*
         * 선택정렬
         정렬되지 않은 데이터들에 대해 <가장 작은 데이터를 찾아> <가장  앞의 데이터와 교환>해 나가는 방식

        1. 리스트에서 최소값을 찾는다.
        2. 최소값을 맨 앞의 값과 교체한다.
        3. 교체한 맨 앞의 데이터는 정렬된 것으로 간주하고
        다음 인덱스부터 1, 2, 행위를 끝까지 반복한다.

        시간복잡도 : O(n^2)
         */
        public void SelectionSort(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < data.Length; j++)
                {
                    if (data[j] < data[min])
                    {
                        min = j; // i 번째 뒤로 최소값의 인덱스를 찾는다.
                    }
                }

                Swap(ref data[i], ref data[min]);
            }
        }


        /*
         * 삽입정렬
        <앞의 숫자가 나보다 큰지> 비교하면서 자신의 위치에 삽입하는 정렬 방법.
        앞의 값과 비교를 하기 때문에 전체 배열 중 0번 인덱스가 아닌 <1번 인덱스부터> 앞의 값과 비교

        key 변수를 사용하는 이유 : 기준(나)의 위치가 Swap을 할때마다 변하기 때문.
         */
        public void InsertionSort(int[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                int key = i;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (data[key] < data[j])
                    {
                        Swap(ref data[key], ref data[j]);
                        key = j;
                    }
                    Show(data);
                }
            }
        }


        /*
         * 퀵 정렬
        <피봇을 기준으로> 작거나 같은 값을 지닌 데이터는 앞으로, 
        큰 값을 지닌 데이터는 뒤로 가도록 하여
        작은 값을 갖는 데이터와 큰 값을 갖는 데이터로 <분리>해가며 정렬하는 방법이다.
         
        1. 분할 정복 알고리즘
        2. 일반적으로 빠른 알고리즘

        시간복잡도 : O(nlogn ~ n^2)
         */
        public void QuickSort(int[] data, int first, int last)
        {
            Console.WriteLine("First : " + first + " Last : " + last);

            if (first < last)
            {
                int pivotIndex = FuncPartition(data, first, last);

                // 시작~피벗전, 피벗후~끝 : 피벗은 정렬이 완료된 것이므로
                QuickSort(data, first, pivotIndex - 1);
                QuickSort(data, pivotIndex + 1, last);
            }
        }

        public int FuncPartition(int[] data, int first, int last)
        {
            int low, high, pivot;

            pivot = data[last]; // 맨 마지막 값을 피벗

            low = first;
            high = last - 1;

            while(low <= high)
            {
                while (data[low] < pivot) // 피벗보다 큰 값을 아래서부터 위로 찾기 위함
                    low++;

                while (data[high] > pivot) // 피벗보다 작은 값을 위에서부터 아래로 찾기 위함
                    high--;

                if (low <= high)
                {
                    Swap(ref data[low], ref data[high]); // 왼쪽에는 피벗보다 작은값, 오른쪽에는 피벗보다 큰값으로 정렬
                }
            }
            Swap(ref data[low], ref data[last]); // low와 high가 교차하여 더 이상 Swap할 것이 없으면 low와 pivot을 Swap
            Show(data);

            return low;
        }

        /*
        public void Q(int[] data, int first, int last)
        {
            if (first < last)
            {
                int pivotIdx = F(data, first, last);

                Q(data, first, pivotIdx - 1);
                Q(data, pivotIdx + 1, last);
            }
        }

        public int F(int[] data, int first, int last)
        {
            int pivot;
            int low, high;

            pivot = data[last];
            low = first; high = last - 1;

            while(low <= high)
            {
                while (data[low] < pivot)
                    low++;

                while (data[high] > pivot)
                    high--;

                if (low <= high)
                    Swap(ref data[low], ref data[high]);
            }

            Swap(ref data[low], ref data[last]);

            return low;
        }
        */

        /*
         * 힙정렬
        힙은 완전 이진트리구조를 가진 자료구조이다.
        이 힙의 특성을 이용하여 정렬을 하는 것이 힙정렬이다.

        최소값 혹은 최대값을 빠르게 가져오기 위해 고안됨.
        형제 노드 사이에서는 아무런 대소관계가 정해져 있지 않음. (부모와 자식 사이에 대소관계만 존재)
         */
        public void CreateHeap(int[] data)
        {
            // i의 범위는 최하위 노드의 직속 부모부터 최상단 루트 노드까지
            // 힙트리 정렬은 재귀적으로 자식들을 찾아가면서 정렬하기 때문이다.
            for (int i = (data.Length - 1) / 2; i >= 0; --i)
            {
                SortingHeapTree(data, i, data.Length);
            }
        }

        public void SortingHeapTree(int[] heap, int root, int max)
        {
            while (root < max)
            {
                // 루트(현재 기준)노드의 자식 노드
                // 기본은 좌측 자식으로 한다.
                int child = root * 2 + 1;

                // 우측 노드가 최대치 보다 적고
                // 우측 노드가 좌측 노드보다 크다면
                // 자식을 우측 자식 노드로 결정
                if (child + 1 < max && heap[child] < heap[child + 1])
                    ++child;

                // 루트(현재 기준)노드보다 자식노드가 크다면
                // 그 둘을 맞바꾸고
                // 현재 기준을 그 자식으로 변경한다.
                if (child < max && heap[root] < heap[child])
                {
                    Swap(ref heap[root], ref heap[child]);
                    root = child;
                }
                else
                    break;
            }
        }


        public int[] HeapTree2Array(int[] heap)
        {
            int[] sorted = new int[heap.Length];

            for (int i = heap.Length - 1; i > 0; --i)
            {
                // 최상단 노드를 배열에 담는다.
                sorted[i] = heap[0];

                // 최상단 노드와 최하위 노드를 맞바꾼다.
                Swap(ref heap[0], ref heap[i]);

                // 최상단부터 다시 정렬한다.
                // (최하위에 있던 작은 값의 노드가 맨 위로 올라왔으므로 다시 제자리를 찾아주기 위함.)
                SortingHeapTree(heap, 0, i);
            }

            return sorted;
        }











        /*
        public void SortHeap()
        {
            int[] data = { 20, 35, 15, 5, 40, 10, 25, 30 };

            for (int i = (data.Length - 1) / 2; i >= 0; --i)
            {
                CalcHeap(data, i, data.Length);
            }

            for (int i = data.Length - 1; i > 0; --i)
            {
                SwapHeap(ref data[i], ref data[0]);
                CalcHeap(data, 0, i);
            }
        }

        public void SwapHeap(ref int nData1, ref int nData2)
        {
            int nTemp = nData1;
            nData1 = nData2;
            nData2 = nTemp;
        }

        public void CalcHeap(int[] data, int nRoot, int nMax)
        {
            while (nRoot < nMax)
            {
                // 왼쪽 자식 노드
                int nChild = nRoot * 2 + 1;

                // 오른쪽 자식노드가 더 크면 오른쪽 선택
                if (nChild + 1 < nMax && data[nChild] < data[nChild + 1])
                    ++nChild;

                if (nChild < nMax && data[nRoot] < data[nChild])
                {
                    SwapHeap(ref data[nRoot], ref data[nChild]);
                    nRoot = nChild;
                }
                else
                    break;
            }
        }
        */
    }
}
