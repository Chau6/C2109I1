using RefOut;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

int a = 10;
int b = 5;

Console.WriteLine($"Program : {nameof(a)} = {a}, {nameof(b)} = {b}");
//UseRefOut.ChangeNumber(ref a, ref b); //truyền a b vào phương thức, khi dùng ref thì đối tượng có thể thay đổi a b từ trong phương thức, look like biến toàn cục

UseRefOut.ChangeNumber(out a, out b); //truyền a b vào phương thức, khi dùng out thì đối tượng k cần biết giá trị trước, mà khi vào phương thức thì mới khai báo