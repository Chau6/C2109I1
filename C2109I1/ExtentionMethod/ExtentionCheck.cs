using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod;
//biến cái class này thành extention method
// => class phải là static
//1 phương thức là static thì chưa chắc class toàn là static
//1 class là static thì toàn bộ bên trong là static
internal static class ExtentionCheck
{
    public static void IsGreaterThan(this int i, int value)
    {
        if (i > value)
        {
            Console.WriteLine($"{i} > {value}");
        }
    }

    public static void Hi(this Program obj) => Console.WriteLine("aaaa");
}
