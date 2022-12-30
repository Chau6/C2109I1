using UsingTuple; //tuble cho phép get/set
//sài tuble thì chỉ set được có 1 hàng trong table
//sài class Person thì được sài nhiều hàng

//object initializer
Person per = new()
{
    Id = 1,
    FirstName = "Tan",
    LastName = "Chau",
};

Console.WriteLine($"Id = {per.Id}, Name = {per.LastName} {per.FirstName}");

//dùng tuble k dùng đến class
ValueTuple<int, string, string> per1 = (1, "tan", "chau"); //tương tự 1 dòng trong table = value tuble (struct)
Console.WriteLine($"ValueTuble = {per1.Item1}");
Console.WriteLine($"ValueTuble = {per1.Item3}");
//mới hơn
(int, string, string) p2 = (1, "tan", "Chua");
Console.WriteLine(p2.Item2 + " " + p2.Item3);
//dùng var
var p3 = (1, "Tan", "Chua"); //value tuble cho phép get/set
Console.WriteLine(p3.Item2 + " " + p3.Item3);

var p4 = (1); //variable int p4 = 1; cẩn thận, thèn này là biến >< vs value tuble

//net core dùng name thay thế cho các Item1,Item2... 
(int id, string firstName, string lastName) p5 = (1, "tan", "chau");
Console.WriteLine(p5.id + " " + p5.firstName + " " + p5.lastName);
//hoặc dùng name phía trước
var p6 = (id: 1, first:"tan",last:"chau"); //<- khi muốn dùng tuble thì sài thèn này
Console.WriteLine(p6.id + " " + p6.last + p6.first);
p6.last = "aaa"; //cho phép get/set
Console.WriteLine(p6.last);
//k phải tuble => anonymous type -> thèn này k đổi giá trị được = get not set
var p7 = new { id = 1, first = "tan", last = "chau" };
Console.WriteLine($"Cẩn thận = {p7.last}");
Console.WriteLine($"Cẩn thận = {p7.first}");
//p7.last = "aaa"; //error
//Console.WriteLine(p7.last);