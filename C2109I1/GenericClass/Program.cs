using GenericClass;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

//điều kiện để sài generic class là các class phải có chung field và chung kiểu dữ liệu
Class1<int> one = new Class1<int>();
one.Field = 10;
one.Show();

Console.WriteLine("Truyền 2 field");

Class2<string, int> two = new();
two.Name = "chau";
two.Description = 100;
two.Show();