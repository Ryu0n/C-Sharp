using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _044_Interface
{
    /*
    
    - 인터페이스 
    (O) : 메소드, 이벤트 , 인덱서, 프로퍼티(get, set)
    (X) : 필드 사용 불가, 접근 제한자 사용 불가
    구현부 없음 (정의)
    인스턴스 생성 불가 (참조 가능)
    인터페이스에서 사용하는 메소드들은 "반드시 재정의" 해야한다.
    
    인터페이스는 왜 쓸까? 
    ①메소드 재정의를 해야할 강제성을 두기 위함. (규칙을 위해)
    virtual, override 키워드를 사용하면 재정의를 해야할 강제성이 없기 때문에
    ②다중상속의 대안으로 존재. (인터페이스는 다중 상속이 가능하다.)

     */

    interface IAA
    {
        //public int a; // 필드 사용 불가
        //private void IPrint() { } // 구현부 사용 불가
        //public void IPrint(); // 접근 제한자 사용 불가

        int a { get; set; }

        void IAAPrint();
    }

    interface IBB
    {
        void IBBPrint();
    }

    class Super
    {
        protected int num;

        public virtual void Print()
        {
            Console.WriteLine("==============================================");
        }
    }

    class AA : IAA
    {

        public int a { get; set; }

        public void IAAPrint()
        {
            Console.WriteLine("AA IAAPrint Override");
        }
    }

    class BB : IAA, IBB
    {
        public int a { get; set; } // 람다식 사용

        public void IAAPrint()
        {
            Console.WriteLine("BB IAAPrint Override");
        }

        public void IBBPrint()
        {
            Console.WriteLine("BB IBBPrint Override");
        }
    }

    class CC : Super, IAA, IBB
    {
        public int a { get => a; set => a = value; } // 람다식 사용

        public void IAAPrint()
        {
            Console.WriteLine("CC IAAPrint Override");
        }

        public void IBBPrint()
        {
            Console.WriteLine("CC IBBPrint Override");
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("CC Print Override");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            AA aa = new AA() { a = 10 };
            Console.WriteLine(aa.a);
            aa.IAAPrint();

            BB bb = new BB() { a = 20 };
            Console.WriteLine(bb.a);
            bb.IAAPrint();
            bb.IBBPrint();

            //IAA iaa = new IAA(); // 인터페이스는 생성 불가
            IAA Iaa = new AA();
            Iaa.IAAPrint();

            IBB Ibb = bb as IBB;
            Ibb.IBBPrint();

            CC cc = new CC();
            cc.Print();
            cc.IAAPrint();
            cc.IBBPrint();

            IAA IAAcc = cc as IAA;
            IAAcc.IAAPrint();

            IBB IBBcc = cc as IBB;
            IBBcc.IBBPrint();



            while (true) { }
        }
    }
}
