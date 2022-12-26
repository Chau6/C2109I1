using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass; //tạo 1 class và sài chung hết cho tất cả | điều kiện là các class phải có chung field
internal class Class1<T>
{
    public T Field { get; set; }
    public void Show() => Console.WriteLine(Field);
}
