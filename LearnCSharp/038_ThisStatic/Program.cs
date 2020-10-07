using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _038_ThisStatic
{
    class Program
    {
        /*
         
        this : 객체 자신을 참조하는 키워드
        사용처 : 함수의 파라미터 이름과 멤버 변수 이름이 동일, 클래스 내부에서 멤버변수를 접근
         
         */
        static void Main(string[] args)
        {
            AA aa = new AA(10);

            aa.Print();

            // static 멤버들은 객체 생성없이 접근이 가능하다.
            BB.a = 10;
            BB.b = 100;
            BB.Print();


            CC cc = new CC();
            cc.Print();

            CopyRefClass(cc);
            cc.Print();

            CC tempCC = CopyDeepClass(cc);
            tempCC.Print();

            while (true) { }
        }

        // 얕은 복사 : 특정 객체에 대한 레퍼런스만 만들어서 값을 변경
        static void CopyRefClass(CC cc)
        {
            CC refCC = cc;
            refCC.a = 100;
            refCC.b = 10000;
        }

        // 깊은 복사 : 특정 객체와 같은 객체를 복사, 기존에 존재하던 객체에는 영향 X
        static CC CopyDeepClass(CC cc)
        {
            CC tempCC = new CC();

            tempCC.a = cc.a;
            tempCC.b = cc.b;

            return tempCC;
        }
    }

    class AA
    {
        int a;

        public AA(int a)
        {
            this.a = a; // 객체 자신 a (this.a)에 파라미터로 입력받은 a를 입력.
        }

        public void Print()
        {
            int a = 100;
            this.a = 1000;

            Console.WriteLine("a : {0}", a);
            Console.WriteLine("this.a : {0}", this.a);
        }
    }

    class BB
    {
        public static int a;
        public static int b;
        public static readonly int c = 200; // 읽기 전용

        // static 키워드가 없기 때문에 객체 생성을 해야한다.
        public int num;

        // static 메소드 내에 있는 변수도 당연히 static
        public static void Print()
        {
            Console.WriteLine("a : {0}", a);
            Console.WriteLine("b : {0}", b);

            // num = 100; // static 메소드 내에는 static 필드가 와야한다.
        }
    }

    class CC
    {
        public int a;
        public int b;

        public CC()
        {
            a = 0;
            b = 0;
        }

        public void Print()
        {
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
