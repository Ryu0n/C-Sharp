using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _051_GeneralProgramming
{

    /*
     
    일반화 (Generic)
    클래스, 함수 일반화 가능
    
    키워드: 
    <T> 
    
    장점 : 
    Boxing, Unboxing을 줄일 수 있음.
    불필요한 오버로딩을 줄일 수 있음.
    








    dynamic 키워드 : 일종의 타입
    - 어떤 타입이든 대응이 가능하다
    - 런타임에 변수 형식 변경 가능
    - 일반화 함수에서 변수타입 대응 가능

    - object 타입과의 차이점
    >> object 타입은 구체적 타입의 속성과 메서드를 사용하기 전에 반드시 캐스팅을 통해 구체적 타입으로 변경 후 사용해야 한다.
    >> dynamic 타입은 캐스팅이 없이도 직접 실제 타입(underlying type)의 메서드와 속성을 사용할 수 있다는 점이다.




    default 키워드
    - value type은 0으로 초기화 한다.
    - reference type은 null로 초기화 한다.











    where 키워드 (한정자)
    매개변수 제한 기능

    // T에 올 수 있는 것은 값 형식으로 제한하겠다는 의미
    class AA<T> where T : struct
    {
        private T sData;
    }

    // T에 올 수 있는 것은 참조 형식으로 제한하겠다는 의미
    class BB<T> where T : class 
    {
        private T sRef;
    }


    // T에 올 수 있는 것은 해당 인터페이스로 제한하겠다는 의미
    // >> 해당 인터페이스를 상속받는 클래스들로 제한.
    interface II 
    {
        void IIPrint();
    }

    class CC<T> where T : II
    {

    }









    일반화 컬렉션 ( using System.Colletions.Generic; )
    컬렉션은 모든 object 타입을 받기 때문에 넣는 순간 박싱과 언박싱 현상이 빈번하게 일어난다.
    이를 해결하기 위해 컬렉션을 일반화 시켜야 한다!
    List<T>
    Queue<T>
    Stack<T>
    Dictionary<T>








     */





    class GenericClass<T>
    {
        private T num;
        public T GetNum()
        {
            return num;
        }

        public void SetNum(T data)
        {
            num = data;
        }
    }







    class REF
    {

    }

    class AA<T> where T : struct //값형식으로 제한
    {
        private T sData;
        public AA()
        {
            sData = default(T);
        }
        public void Print()
        {
            Console.WriteLine("" + sData);
        }
    }

    class BB<T> where T : class //참조 형식으로 제한
    {
        private T sRefData;
        public BB()
        {
            sRefData = default(T);
        }
        public void Print()
        {
            if (sRefData == null) Console.WriteLine("Null sRefData");
            else Console.WriteLine("sRefData: " + sRefData);
        }
    }






    interface II
    {
        void IIPrint();
    }

    class CC<T> where T : II //interface로 제한
    {
        public T _interface;
    }

    class DD : II
    {
        public void IIPrint()
        {
            Console.WriteLine("DDbase: ");
        }
    }





















    class Program
    {
        // 메소드의 일반화
        static void GenericPrint<T>(T data)
        {
            Console.WriteLine(data);
        }

        static void GenericPrint<T>(T[] datas)
        {
            foreach(T data in datas)
            {
                Console.WriteLine(data);
            }
        }






        static T AddArray<T>(T[] arrDatas)
        {
            //T temp = 0; 에러 발생 : 정수형 타입이 아닐 경우 대입할 수 없기 때문에
            //object aaa = 0; //박싱, 언박싱 발생

            // T가 value type이면 0
            // T가 reference type이면 null
            dynamic temp = default(T);
            
            // 오류나는 이유 : 일반화를 했기 때문에 var를 쓰면 특정 타입으로 고정되기 때문
            //var temp = default(T);


            for (int i = 0; i < arrDatas.Length; i++)
            {
                temp += arrDatas[i];
            }
            return temp;
        }

        static T SumArray<T>(T[] arrDatas)
        {
            T temp = default(T);

            for (int i = 0; i < arrDatas.Length; i++)
            {
                temp += (dynamic)arrDatas[i];
            }
            return temp;
        }

        static void PrintArray<T>(T[] arrDatas)
        {
            foreach (var data in arrDatas)
            {
                Console.WriteLine("data: {0}", data);
            }
        }












        static void Main(string[] args)
        {
            int[] datas = { 100, 200, 300 };

            GenericPrint<int>(datas);

            GenericClass<int> intClass = new GenericClass<int>();
            GenericClass<float> floatClass = new GenericClass<float>();

            intClass.SetNum(10);
            floatClass.SetNum(10.01f);

            Console.WriteLine(intClass.GetNum());
            Console.WriteLine(floatClass.GetNum());









            // dynamic은 런타임 도중에도 어떤 타입이든 대응이 가능하다.
            dynamic v = 1;
            Console.WriteLine(v);

            v = "string";
            Console.WriteLine(v);

            // dynamic은 casting이 필요없다.
            object o = 10;
            o = (int)o + 20; // object는 캐스팅이 필요한 반면..

            dynamic d = 10; // dynamic은 캐스팅이 필요하지 않다.
            d = d + 10;












            int[] arrNums = { 1, 2, 3, 4, 5 };
            string[] arrStrs = { "a", "b", "c" };

            Console.WriteLine("AddArray: {0}", AddArray(arrNums));
            Console.WriteLine("SumArray: {0}", SumArray(arrNums));
            Console.WriteLine("SumArray: {0}", SumArray(arrStrs));
            PrintArray(arrNums);











            // 이 세가지를 명확히 이해하자.

            // var은 value를 대입한 순간 해당 value에 대한 타입으로 판정.
            var vv = "aaa";
            
            // object는 value를 대입해도 object 타입 그대로 판정
            object oo = "bb";

            // dynamic은 value를 대입해도 런타임에서 타입이 선정되기 때문에
            // 컴파일러에서는 타입이 정해져있지 않다.
            dynamic dd = "dd";










            // where struct를 통해 값 형식으로 제한했으므로 reference 타입은 올 수 없다.
            //AA<REF> aa = new AA<REF>();
            AA<int> aa = new AA<int>();

            BB<REF> bb = new BB<REF>();
            // where class를 통해 참조 형식으로 제한했으므로 value 타입은 올 수 없다.
            //BB<int> bb = new BB<int>();



            CC<II> cc = new CC<II>();
            cc._interface = new DD(); // II를 상속받으면 무엇이든 올 수 있다!
            cc._interface.IIPrint();










            // 컬렉션의 일반화

            // 어레이 리스트 대신에 int타입의 리스트를 사용하면
            // int 타입만 대입이 가능하기 때문에
            // 박싱과 언박싱 과정이 불필요하다.
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);

            string[] arrData = { "a", "b", "c" };
            List<string> listStr = new List<string>(arrData);

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Peek();
            queue.Dequeue();
            queue.Dequeue();

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Peek();
            stack.Pop();
            stack.Pop();

            // HashTable 대신에 Dictionary를 사용한다.
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Jack", 100);
            dictionary.Add("Jane", 101);
            dictionary.Add("Noan", 102);
            dictionary["Jack"] = 103;

            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine(dictionary[key]);
            }

            Dictionary<int, string> dic = new Dictionary<int, string>()
            {
                [0] = "Jack",
                [1] = "John",
                [2] = "Hale"
            };





















            while (true) { }
        }
    }
}
