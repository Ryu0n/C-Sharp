using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _050_Indexer
{

    // 인덱서 : 배열이나 컬렉션의 외부 접근을 용이하게 하기 위함.
    // 키워드 : get, set, return, value, this[int index]

    class MyClass
    {
        private const int MAX = 10;
        private string name;

        private int[] data = new int[MAX];

        // 인덱서 정의
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= MAX) // 예외처리 
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return data[index];
                }
            }

            set
            {
                if (!(index < 0 || index >= MAX))
                {
                    data[index] = value;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass cls = new MyClass();

            cls[0] = 10;

            Console.WriteLine(cls[0]);
        }
    }
}
