using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
리스트는 동적 배열이라고도 부른다.
리스트는 삽입할 데이터의 타입에 구애받지 않는다.

 리스트는 크게 3가지가 있다.
1. ArrayList
2. LinkedList
3. List<T> (제네릭 타입)
 
.Net Framework 안의 
System.Colletions : ArrayList
System.Collections.Generic : List<T>

Boxing : 값 형식을 참조 형식으로 변환하는 것
Unboxing : 참조 형식을 값 형식으로 변환하는 것

힙, 스택에 대해 알아야 한다. 

인자로 변수를 넘기는 경우 : 스택이라는 메모리에 저장. 이것을 인자로 받은 함수 내에서 아무리 수정해도 실제 값은 수정되지 않아요.
하지만, 배열이나 객체를 인자를 받으면 call by reference 참조를 받게 되죠. 배열이나 객체는 함수 내부에서 변경하면 변경이 반영된다.
 */

namespace _01_List
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList list = new ArrayList();
            int alpha = 3;

            Program p = new Program();

            p.EditList(list); // Call by reference : 객체를 넘기게 되면 객체의 레퍼런스를 넘기게 된다.
            p.EditAlpha(alpha); // Call by value : 변수를 넘기게 되면 변수를 복사하여 인자를 넘기게 된다.

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine(alpha);


            // object 타입을 박스라고 생각하자.
            int n = 100;
            // 어레이 리스트에서는 박싱, 언박싱 현상이 많이 일어난다. (타입에 상관없이 받으므로)
            // 단순히 참조에 할당하는 것보다 20배 언박싱은 4배 시간이 소요
            // 그래서 제네릭 리스트 사용을 권고한다.
            object o = n; // 박싱 
            int b = (int)o; // 언박싱 / 캐스팅 : 자식은 부모를 알 수 없다. 부모는 자식을 알지만. 그래서 캐스팅을 명시적으로 하는 것.


            // 제네릭 리스트는 런타임에서 타입이 정해진다.
            // 속도도 빠르고 타입이 정의되어 있다.
            List<int> listInt = new List<int>();
            listInt.Add(5);
            listInt.Add(3);
            listInt.Add(10);

            listInt.Sort();
            listInt.Reverse();

            foreach(int i in listInt)
            {
                Console.WriteLine(i);
            }
            



            while (true)
            {

            }

        }

        // Call by reference
        private void EditList(ArrayList list)
        {

            list.Add(1); list.Add(2); list.Add("string");

            list.Insert(1, "here i am");

            list.RemoveAt(0); // 0번째 인덱스 삭제
            list.Remove("string"); // 해당 벨류가 가장 처음으로 발견되는 것을 삭제
        }

        // Call by value
        private void EditAlpha(int alpha)
        {
            alpha = 4;
        }

        
    }  
}
