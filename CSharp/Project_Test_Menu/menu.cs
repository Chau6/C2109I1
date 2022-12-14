using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Test_Menu;
internal class Menu
{
    public static void ShowMenu()
    {
        Console.WriteLine("Nhập 1 để làm phép cộng");
        Console.WriteLine("Nhập 2 để làm phép trừ");
        Console.WriteLine("Nhập 3 để làm phép nhân");
        Console.WriteLine("Nhập 4 để làm phép chia");
        //Console.WriteLine("Nhập 5 để nhập số");
        Console.WriteLine("Nhập phím bất kỳ để thoát chương trình");
    }
}
