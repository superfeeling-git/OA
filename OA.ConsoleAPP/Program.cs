using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OA.Dtos;

namespace OA.ConsoleAPP
{
    //public delegate void ThreadStart();

    internal class Program
    {
        /*bool _done;
        private readonly object obj = new object();*/

        static void Main(string[] args)
        {
            /*var task = Task.Run(() => {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write(i);
                }
            });

            Task.Delay(10000);

            Console.WriteLine("....................");

            Console.ReadLine();*/
        }


        /*public void Go()
        {
            lock (obj)
            {
                if (!_done)
                {
                    Console.WriteLine("Done");
                    _done = true;       //第1次，子线程赋值   主线程输出Done
                }
            }            
        }*/




        /*public static void Test()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine("当前线程:" + thread.Name);
            Console.WriteLine("当前线程状态:" + thread.ThreadState);
            int i = 6;
            while ( i < 100)
            {
                i++;
                Console.WriteLine(i);
                if (issleep == 1)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }*/
    }

    /// <summary>
    /// 类
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 姓名(属性、字段) 访问修饰符
        /// </summary>
        private string name;

        /// <summary>
        /// 构造函数  Pg yq 
        /// </summary>
        public Person(string _name)
        {
            this.name = _name;
        }

        /// <summary>
        /// 会说话
        /// </summary>
        /// <param name="str"></param>
        public void Speck()
        {
            Console.WriteLine($"我的名字叫:{name}");
        }
    }
}
