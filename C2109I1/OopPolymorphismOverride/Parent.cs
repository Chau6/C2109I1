using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismOverride;
internal class Parent
{
    public void Show() => Console.WriteLine("Parent Show");

    public virtual void Display() => Console.WriteLine("Parent Display"); //muốn đè đầu cha để sửa thì phải có virtual
}
