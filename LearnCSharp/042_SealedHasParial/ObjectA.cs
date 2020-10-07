using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _042_SealedHasParial
{
    partial class ObjectA
    {
        int num;

        public ObjectA()
        {
            num = 0;
        }

        public void SetNum(int num)
        {
            this.num = num;
        }

    }
}
