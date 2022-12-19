using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphism;
internal class BasicMath
{
    //auto properties
    public int Number_1 { get; set; }
    public int Number_2 { get; set; }

    //Overloading chỉ khác tham số hay kiểu của tham số || overloading nghĩa là gia tăng tính năng | tham số
    //1 là constructor, 2 là method
    //ctor
    //public BasicMath(){}
    public BasicMath(int number_1=0, int number_2=0) //đối số || Optional argument
    {
        Number_1 = number_1;
        Number_2 = number_2;
    }

    

}
