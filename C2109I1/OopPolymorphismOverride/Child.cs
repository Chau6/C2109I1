using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismOverride;
internal class Child:Parent
{
    public override void Display()
    {
        //base.Display();//gọi của cha ra
        Console.WriteLine("Child Display");
    }

    public new void Show()//của riêng con nhưng vô tình trùng tên vs cha thì phải thêm new vào => ưu tiên lấy của con sài
    {
        Console.WriteLine("Child Show");
    }
}
