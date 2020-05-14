using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace 反射
{
    class Program
    {
        static void Main(string[] args)
        {
            //反射：通过动态加载程序集 获取类型创建对象并调用成员 都是通过反射来实现的


            //myclass c = new myclass();
            ////已知类的实例 使用GetType方法得到该类
            //Type type = c.GetType();



            Type type = typeof(myclass);

            //获取所有属性
            PropertyInfo[] fields = type.GetProperties();
            foreach (var item in fields)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            Console.WriteLine("获得程序集加载时所有的类----------");
            Assembly a = Assembly.LoadFile(@"D:\泛型\反射\bin\Debug\反射.exe");
            Type[] c = a.GetTypes();
            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine(c[i].FullName);
            }
            Console.WriteLine();

            Console.WriteLine("获取所有的公共类 public--------");
            c = a.GetExportedTypes();
            foreach (var item in c)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine();

            Console.WriteLine("获取指定类myclass-----------");
            Type ss = a.GetType("反射.myclass");
            Console.WriteLine(ss.Name);

            //找到类名调用无参构造方法A();
            MethodInfo method = ss.GetMethod("A",new Type[] { });
            method.Invoke(Activator.CreateInstance(ss),null);

            //找到类名调用有参构造方法A();
            MethodInfo method2 = ss.GetMethod("A", new Type[] { typeof(string)});
            method2.Invoke(Activator.CreateInstance(ss), new object[] {"大家好" });

        }
    }

    class myclass {
        public string name { get; set; }
        public string sex { get; set; }
        private int MyProperty { get; set; }
        public void A() {
            Console.WriteLine("反射：这里是A方法");
        }

        public void A(string a) {
            Console.WriteLine(a+"反射：这里是A有参数方法");
        }
    }
}
