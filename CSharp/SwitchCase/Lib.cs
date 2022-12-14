
Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int number1 = Random.Shared.Next(0, 9);
int number2 = Random.Shared.Next(0, 9);
Console.WriteLine($"Number 1 = {number1} and Number 2 = {number2}");
Console.WriteLine($"{nameof(number1)} = {number1} and {nameof(number2)} = {number2}");

Console.WriteLine("Vui lòng nhập dấu: ");
var pheptoan = Console.ReadLine();
//switch (pheptoan)
//{
//    case "+" when number1 > 0 && number2 > 0: Console.WriteLine(number1 + number2); break;
//    case "-" when number1 >= number2: Console.WriteLine(number1 - number2); break;
//    case "*": Console.WriteLine(number1 * number2); break;
//    case "/" when number2 is not 0: Console.WriteLine(number1 / number2); break;
//    default: Console.WriteLine("bố mày dỗi đếch làm"); break;
//}

//switch expression => biểu thức switch => chạy nhanh hơn 
Console.WriteLine(pheptoan switch
{
    "+" when number1 > 0 && number2 > 0 => number1 + number2,
    "-" when number1 >= number2 => number1 - number2,
    "*" => number1 * number2,
    "/" when number2 is not 0 => number1 / number2,
    _ => "Hi, i can't..."
});
