using System.Collections;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

string[] arrs = { "chau", "nguyen", "tin", "thai" };

foreach (var t in arrs)
{
    Console.WriteLine($"{t} have length {t.Length}");
}

Console.WriteLine();

//int i = 0;
//while (i < arrs.Length) //arrs.Length là mỗi lần nó tự length lại 1 lần nữa => lỗi rất nặng => khắc phục bằng cách gán arrs.Lenght vào 1 biến rồi lấy biến đó so sánh
//{
//    Console.WriteLine($"{arrs[i]} have length {arrs[i].Length}");
//    i++;
//}

//chạy nhanh hơn while thường
IEnumerator e = arrs.GetEnumerator();
while (e.MoveNext())
{
    string s = (string)e.Current;
    Console.WriteLine($"{s} có chiều dài {s.Length}");
}