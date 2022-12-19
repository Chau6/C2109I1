Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

HumanBeing h = new();
h.FullName = "Tấn Châu";
h.Address = "Bình Dương";
h.Age = 19;
h.ShowProperty();

//hướng đối tượng có 4 tính chất
//1.Inheritance: Kế thừa => con kế thừa cha, nhưng cha k được kế thừa con
//2.Encapsulation: tính đóng gói => private e đi, chỉ cho phép truy cập thông qua getter/setter
//3.Abstraction: Trừu tượng => k viết được thì để e vào
//4.Polymorphism: Đa hình => ghi đè các thứ