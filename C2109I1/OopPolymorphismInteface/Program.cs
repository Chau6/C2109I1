//hướng đối tượng có 4 tính chất
//1.Inheritance: Kế thừa => con kế thừa cha, nhưng cha k được kế thừa con
//2.Encapsulation: tính đóng gói => private e đi, chỉ cho phép truy cập thông qua getter/setter
//3.Abstraction: Trừu tượng => k viết được thì để e vào
//4.Polymorphism: Đa hình => ghi đè các thứ

using OopPolymorphismInteface;
using System.Collections;
using System.ComponentModel;

FileOne f = new(); 
f.WriteTextFile(); //Write Text File
f.WriteBinaryFile(); //Write Binary File
(f as IBinaryFile).ReadFile(); //Read Binary File
(f as ITextFile).ReadFile(); //Read Text File

//ép ShowInfo vào IBinaryFile
//cách 1
((IBinaryFile)f).ShowInfo(); // <-----------------sài thèn này
//cách 2
(f as IBinaryFile).ShowInfo(); //This is Binary File

//nếu có nhiều hơn 1 đối tượng - class sài chung interface
ITextFile itext = new FileOne();
itext.WriteTextFile(); //Write Text File
//itext = new FileTwo(); //nếu có 

//List bên C# giống bên java
//List<string> list = new List<string>();
//list.Add(list[0]);