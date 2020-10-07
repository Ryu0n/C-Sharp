using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _041_Polymophism
{
    class Super
    {
        protected int num;

        // virtual이라는 키워드가 존재해야 override 키워드로 재정의가 가능하다.
        public virtual void Print()
        {
            Console.WriteLine("num:  {0}", num);
        }
    }

    class AA : Super
    {
        public int a;

        public override void Print()
        {
            base.Print(); // base 키워드 : 해당 클래스의 부모

            Console.WriteLine("AA a:  {0}", a);
        }
    }

    class BB : Super
    {
        public int b;

        public override void Print()
        {
            base.Print();

            Console.WriteLine("BB b:  {0}", b);
        }
    }


    class Program
    {
        /*
        다형성 - virtual, override

        - 객체 지향의 핵심
        - 함수의 오버라이딩 (재정의)
        - 반복문으로 객체 관리

        ex) public virtual void Print(), public override void Print()
         */

        static void Main(string[] args)
        {
            Super super = new Super();
            super.Print();
            
            Super aa = new AA();
            aa.Print(); // Super 클래스이지만 실제 객체는 AA객체이기 때문에 AA클래스에 재정의(override)된 Print()메소드를 호출한다.

            Super bb = new BB();
            bb.Print();
        }
    }
}
