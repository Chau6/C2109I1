using Delegate;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

//cổng xóa = delegate
Mathems m= new Mathems();
//c1
m.Add(5, 4);
//c2 gọi static
Mathems.Multi(5, 4);
//c3 anonymous
new Mathems().Sub(5, 4);
//hiện tượng sụp đổ => nếu Mathems có lỗi thì nó cũng kéo theo program lỗi

//delegate lấy thèn Mathems ra chạy cho program => delegate chạy được hay k đều chết và k ảnh hưởng program
Abc d = new Mathems().Sub; //k chạy được static
d(10, 5); //thèn có lỗi gì đi nữa thì class cũng cũng k bị ảnh hưởng | safe thread = luồng an toàn