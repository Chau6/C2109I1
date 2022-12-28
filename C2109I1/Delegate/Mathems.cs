using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate; //tạo đâu cũng được nhưng tốt nhất là tạo bên ngoài class thì nó sẽ k bị phụ thục vào class
delegate void Abc(int a, int b); //<- sài thèn này để gọi function

internal class Mathems
{
    public void Add(int a, int b) => Console.WriteLine($"Add {a + b}"); 
    public void Sub(int a, int b) => Console.WriteLine($"Sub {a - b}");
    public static void Multi(int a, int b) => Console.WriteLine($"Multi {a * b}"); //static sẽ khởi tạo chung vs hệ thống
    public void Dev(int a, int b) => Console.WriteLine($"Div {a / b}");
}

