using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    internal class Class1
    {
        public void t()
        {
            
        }
    }

    internal class Class2
    {
        public Class2()
        {
            Class1 c1 = new Class1();
            c1.t();
        }
    }
}
