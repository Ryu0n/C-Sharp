using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _045_AbstractClass
{
    /*
     
    추상 클래스
    - 인스턴스 생성 불가 (참조 가능)
    - 구현부 없음 (abstract 키워드가 존재하면)
    - 상속 받는 클래스의 규격

    인터페이스와 매우 유사하다.. 클래스의 규격을 정하기 위함.

    차이점은 뭘까?
    ⓐ 클래스이기 때문에 다중상속이 안된다.
    ⓑ 필드를 가질 수 있다.
    ⓒ 접근 제한자가 사용 가능하다.
    ⓓ abstract 키워드 이외에도 다른 것들을 사용할 수 있다.

     */


    abstract class AbstractAA
    {
        protected int num;

        public AbstractAA() { }

        public AbstractAA(int num)
        {
            this.num = num;
            Console.WriteLine("AbstractAA.num : {0}", this.num);
        }

        public abstract void AbstractPrint();

        public virtual void VirtualPrint()
        {
            Console.WriteLine("AbstractAA VirtualPrint()");
        }

        public void Print()
        {
            Console.WriteLine("AbstractAA Print()");
        }
    }

    class AA : AbstractAA
    {
        public AA(int num) : base(num+10) // 생성자에 : 를 사용하면 호출, this를 쓰면 자기 자신을 호출, 현재는 부모 클래스의 생성자 호출, 부모 생성자부터 실행된다, 부모의 num은 10이 더해진 상태
        {
            this.num = num; // AbstractAA로부터 상속받은 protected num
            Console.WriteLine("AA.num : {0}", this.num);
        }

        // 필수적으로 재정의를 해야함
        public override void AbstractPrint()
        {
            Console.WriteLine("abstractPrint");
        }

        // 선택적으로 재정의를 함
        public override void VirtualPrint()
        {
            base.VirtualPrint();

            Console.WriteLine("override void virtualPrint()");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            AA aa = new AA(10);

            while(true) { }
        }
    }
}
