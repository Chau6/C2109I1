using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod;
internal class CheckNumber
{
    public static void Check(int i,int value)
    {
        if (i > value)
        {
            Console.WriteLine($"{i} > {value}");
        }
    }
}
