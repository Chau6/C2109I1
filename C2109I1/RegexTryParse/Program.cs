//bắt lỗi

using System.Text;
using System.Text.RegularExpressions;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

#region 
string? str = null;
Console.WriteLine("Vui lòng nhập số: ");
str = Console.ReadLine();

var formula = new Regex("^[0-9]+$");

//làm web
if (formula.IsMatch(str))
{
    //int result = int.Parse(str);
    int result = Convert.ToInt32(str);
    Console.WriteLine($"Result = {result}");
}

//làm console
if (int.TryParse(str, out int i))
{
    Console.WriteLine($"{nameof(i)} = {i}");
}

Console.WriteLine("Vui lòng nhập số lượng: ");
string? amount = Console.ReadLine(); ;
//dùng try catch
//bảo vệ mệnh đề "guard clause"
if (string.IsNullOrEmpty(amount))
{
    return; //ngắt luôn nếu sai
}

//do something

if(amount is not null)
{
    //do something
}
#endregion

try
{
    int total = int.Parse(amount);
    if (total <= 0) throw new Exception("Phải lớn hơn 0");
    Console.WriteLine($"{nameof(total)} = {total}");
}
catch(Exception) when (amount.Contains("$")) //có thể sài regex 
{
    Console.WriteLine("Chuỗi k được có dấu $");
}
catch(Exception e)
{
    Console.WriteLine($"{e.GetType()}, {e.Message}");
}