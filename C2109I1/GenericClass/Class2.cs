using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass;
internal class Class2<C, C1>
{
    public C Name { get; set; }
    public C1 Description { get; set; }

    public void Show() => Console.WriteLine($"{nameof(Name)} = {Name} , {nameof(Description)} = {Description}");
}
