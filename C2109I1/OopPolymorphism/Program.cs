//hướng đối tượng có 4 tính chất
//1.Inheritance: Kế thừa => con kế thừa cha, nhưng cha k được kế thừa con
//2.Encapsulation: tính đóng gói => private e đi, chỉ cho phép truy cập thông qua getter/setter
//3.Abstraction: Trừu tượng => k viết được thì để e vào
//4.Polymorphism: Đa hình => ghi đè các thứ

//OopPolomorphismOverloading

using OopPolymorphism;
//BasicMath b = new BasicMath(4,5); //có thể kết hợp named argument

//object initialize
BasicMath b = new BasicMath()
{
    Number_2 = 4,
    Number_1 = 5
};