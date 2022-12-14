using Project_Test_Menu;
using System.Linq.Expressions;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

bool a = true;
int b = 0;
int number1 = 5;
int number2 = 4;
while (a)
{
    Menu.ShowMenu();
    b = Convert.ToInt32(Console.ReadLine()); // you cannot implicitly convert type 'string' to 'int' => must convert
    Console.WriteLine(b switch
    {
        1 => number1 + number2,
        2 => number1 - number2,
        3 => number1 * number2,
        4 => number1 / number2,
        _ => a = false //default
    });
}
Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình");