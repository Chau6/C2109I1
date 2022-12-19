//hướng đối tượng có 4 tính chất
//1.Inheritance: Kế thừa => con kế thừa cha, nhưng cha k được kế thừa con
//2.Encapsulation: tính đóng gói => private e đi, chỉ cho phép truy cập thông qua getter/setter
//3.Abstraction: Trừu tượng => k viết được thì để e vào
//4.Polymorphism: Đa hình => ghi đè các thứ

using OopPolymorphismOverride;

Child c = new();
c.Display(); //Child Display
c.Show(); //Child Show
Parent p = new();
p.Display(); //Parent Display
Parent p1 = new Child();//cha tham chiếu đến thèn con, những gì con ghi đè cha thì cha được quyền sài
p1.Display(); //Child Display
p1.Show(); //Parent Show
