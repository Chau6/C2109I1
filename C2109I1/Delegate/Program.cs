using Delegate;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

//cổng xóa = delegate
Mathems m = new Mathems(); //tắt hết mới xóa đối tượng >< c3
//c1
//m.Add(5, 4);//thông qua đối tượng rồi mới gọi = pure oop
//c2 gọi static
//Mathems.Multi(5, 4); //tránh sử dụng -> public toàn bộ -> kém bảo mật -> không gom rác được -> chạy auto
//c3 anonymous
//new Mathems().Sub(5, 4); //gọi nặc danh = sài 1 lần rồi hủy luôn <-------------- nên sài
//hiện tượng sụp đổ => nếu Mathems có lỗi thì nó cũng kéo theo program lỗi

//delegate lấy thèn Mathems ra chạy cho program => delegate chạy được hay k đều chết và k ảnh hưởng program
Abc d = new Mathems().Sub; //k chạy được static <------------------------------- nên sài thèn này
d += new Mathems().Dev;
d(10, 2); //thèn có lỗi gì đi nữa thì class cũng cũng k bị ảnh hưởng | safe thread = luồng an toàn


