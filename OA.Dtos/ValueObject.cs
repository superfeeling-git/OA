using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Dtos
{
    public class Address
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
    }


    /// <summary>
    /// public private internal protected
    /// public internal用于修饰class和类的成员,
    /// public允许跨程序集访问,
    /// internal只能当前程序集访问,
    /// class默认不加访问修饰符，为internal
    /// </summary>
    public class Temp
    {        
        public Temp()
        {
            Address address1 = new Address { Province = "北京", City = "海淀", Area = "唐家岭" };
            Address address2 = new Address { Province = "北京", City = "海淀", Area = "唐家岭" };
        }

        internal void t()
        {

        }

        public void t1()
        {

        }
    }

    public class test
    {
        public test()
        {
            Temp temp = new Temp();
        }
    }
}
