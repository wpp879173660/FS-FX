using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void M1()
        {
            Console.WriteLine("M1方法");
        }
        static void M2(string a) {
             Console.WriteLine("M2静态方法"+a); 
        }

        static int M3(int i, int b) {
            return i + b;
        }

        static void Main(string[] args)
        {
            //委托追加多个方法 +=
            //如果已经追加方法 取消 -=

            //无参无法的委托
            Action a = new Action(M1);
            a();


            //泛型委托
            Action<string> b = M2;
            b("有参无返回委托");


            //Func委托只有一个泛型版本的;保存有返回值类型的委托
            Func<int,int,int> func= M3;
            Console.WriteLine(func(1,2));


            //找到List集合中大于6的数子  
            List<int> l = new List<int>() {1,2,4,5,9,31,22,4,1,966,1,22,0,4 };
            IEnumerable<int> s = l.Where(x=> { return x > 6; });
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }
        }

        

        
    }
    

    
}
