using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            키와 각 밸류가 쌍을 이룬다.
            키값이 해쉬함수를 통해 밸류값이 매핑되어 있는 구조

            value := hashFunc(key)

            키 값을 해쉬함수에 넣으면 변경된 해쉬 코드가 나온다. 
            그리고 해시코드를 버킷이라는 저장공간의 인덱스에 매핑을 시켜서 해당 인덱스에 데이터를 저장한다.

            해시함수는 여러가지 방법으로 구현이 가능하다. 
            ex) 키의 값을 아스키코드로 변경한 후 더해서 해시코드를 생성하는 방식
            ex) 키의 값을 2진수로 변경해서 n승을 하는 방식
            방법은 여러가지..

            .Net에 구현된 좋은 효율의 해시함수를 사용할 것이다.

            Hash Collison : 해시 충돌 
            ex) index = hash % size의 경우...
            101 % 10, 91 % 10 과 같이 인덱스가 충돌하는 경우이다.

            해결법으로는 Seperate Chaining이라는 것이 있다.
            만약 값을 넣으려고 하는 인덱스에 이미 데이터가 존재하면 충돌할 것이다. 
            이 경우, 해당 인덱스의 위치에 Linked List를 통해 들어올 값을 이미 존재하는 값에 연결하여 해결하는 방법이다.

            두 번째 방법으로 Open Addressing
            충돌이 나면 그 다음 버킷 공간이 비어있는지 검사 후 넣는 방식이다.
             */

            /*
            해시테이블 구조는 박싱, 언박싱이 일어나기 때문에
            제네릭 타입을 사용하는 딕셔너리를 사용하는 것을 권고한다.

            해시테이블과 딕셔너리의 특징
            - 키를 가지고 빠르게 값에 전급하기에 좋다.
            - 순서나 중복되는 데이터가 있는 경우에는 맞지 않다.
            - 미리 저장공간을 확보하기 때문에 메모리 효율이 좋지 않다. (검색 효율은 좋다.)
             */

            Hashtable hash = new Hashtable();

            hash.Add(0, "정현");
            hash.Add(1, "패스트캠프");
            hash.Add(2, "C#");
            hash.Add(3, "자료구조");

            Console.WriteLine(hash[0]);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("정현", "010-0000-0001");
            dic.Add("패캠", "010-0000-0002");
            dic.Add("C#", "010-0000-0003");

            // 딕셔너리는 중복 불가
            //dic.Add("정현", "010-2222-2221");

            if (!dic.ContainsKey("용희"))
            {
                dic.Add("용희", "010-2222-3333");
            }

            dic.Remove("C#");

            foreach (var key in dic.Keys)
            {
                Console.WriteLine(key + " : " + dic[key]);
            }

            while (true) { }
        }
    }
}
