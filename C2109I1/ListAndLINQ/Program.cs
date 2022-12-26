using System.Collections;
using System.Diagnostics;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

List<Student> list = new List<Student>()
{
    new Student(){RollNumber = 1, Fullname = "Tấn Châu 1", Section = "Dãy số 1", HosteNumber = 1},
    new Student(){RollNumber = 2, Fullname = "Tấn Châu 2", Section = "Dãy số 2", HosteNumber = 2},
    new Student(){RollNumber = 3, Fullname = "Tấn Châu 3", Section = "Dãy số 3", HosteNumber = 3},
    new Student(){RollNumber = 4, Fullname = "Tấn Châu 4", Section = "Dãy số 4", HosteNumber = 4},
    new Student(){RollNumber = 5, Fullname = "Tấn Châu 5", Section = "Dãy số 5", HosteNumber = 5},
};

Stopwatch sw = new Stopwatch();
sw.Restart();
foreach (var stu in list)
{
    Console.WriteLine(stu);
}
Console.WriteLine($"Foreach time: {sw.ElapsedMilliseconds}");
sw.Restart();

Console.WriteLine();
//tất cả các dạng của collection đều có 1 cái mẫu để duyệt qua data mà k dùng for | foreach => ienumarator

IEnumerator<Student> enu = list.GetEnumerator(); // <= dùng thèn này nhanh hơn foreach
while (enu.MoveNext())
{
    Console.WriteLine(enu.Current);
}
Console.WriteLine($"Foreach time: {sw.ElapsedMilliseconds}");
sw.Restart();

Console.WriteLine();

//linq = language Intergrated query

//linq to object
//linq to sql <=> linq chuyển thành sql rồi chạy nên nó sẽ chậm hơn sql truyền thống
//linq to xml, json
//parallel linq => plinq

//sql = select from where group by having order
//linq = from where group by having order => select

//linq to object có 2 dạng
//style 1: trường phái sql   => query syntax (cú pháp của query) dễ học dễ hiểu
//style 2L trướng phái lamda => method syntax (nhanh hơn style 1) khó học, rất khó hiểu

//liệt kê tất cả sinh viên với mã sinh viên > 2
foreach (var i in list)
{
    if(i.RollNumber > 2)
    {
        Console.WriteLine(i);
    }
}
Console.WriteLine();

//linq to object style 1
//linq = from where group by having order => select
var liststu = from stu in list
              where stu.RollNumber > 2
              select stu;
foreach (var st in liststu)
{
    Console.WriteLine(st);
}
//linq to object style 1 rút gọn
//foreach (var st in from stu in list
//                   where stu.RollNumber > 2
//                   select stu)
//{
//    Console.WriteLine(st);
//}
Console.WriteLine();

//dùng thèn này
IEnumerable<Student> e = from stu in list
                         where stu.RollNumber > 2
                         select stu;
//tìm tổng số sinh viên trong list
Console.WriteLine($"Count: {e.Count()}");

foreach (var st in e)
{
    Console.WriteLine(st);
}

Console.WriteLine();

//linq to object style 2 chạy nhanh hơn style 1 rất nhiều < sql
var liststuS2 = list.Where(stu => stu.RollNumber > 2); //stu nằm trong list, trong list có RollNumber, tìm rollnumber > 2
foreach (var st in liststuS2)
{
    Console.WriteLine(st);
}

Console.WriteLine("aaa");
//rút gọn
//stu nằm trong list, trong list có RollNumber, tìm rollnumber > 2

foreach (var st in (IEnumerable<Student>?)list.Where(stu => stu.RollNumber > 2))
{
    Console.WriteLine(st);
}

Console.WriteLine("aaa");

//các phương thức có sẵn trong list
list.ForEach(Console.WriteLine); //duyệt all nhanh hơn bth < inumerable
Console.WriteLine();
list.ForEach(stu => Console.WriteLine(stu)); //k sài thèn này
Console.WriteLine();
list.ForEach(
    stu =>
    {
        if(stu.RollNumber > 2)
        {
            Console.WriteLine(stu);
        }
    }
);
//kết hợp lambda vs phương thức có sẵn của list

Console.WriteLine("abc");
list.Where(stu => stu.RollNumber > 2) //sài thèn này
    .ToList()
    .ForEach(Console.WriteLine);

Console.WriteLine("new");

// nếu có phương thức - method của "nó" thì ưu tiên sài của nó => chạy rất nhanh | nếu k thì mới sài linq style 2

var t = from stu in list
        where stu.RollNumber > 2
        select new //anonymous type - chỉ lấy column cố định <= lỗi rất nặng nếu sài select stu - ý nghĩa stu là lấy hết
        {
            stu.RollNumber,
            stu.Fullname
        };

t.ToList().ForEach(Console.WriteLine);

Console.WriteLine();

var r = from stu in list
        where stu.RollNumber > 2
        select new //anonymous type - chỉ lấy column cố định <= lỗi rất nặng nếu sài select stu - ý nghĩa stu là lấy hết
        {
            StudentDetail = $"{stu.RollNumber} : {stu.Fullname}", //mã hóa code = dấu code = che dấu code
            StudentRoom = $"{stu.Section} : {stu.HosteNumber}",
        };

r.ToList().ForEach(Console.WriteLine);

Console.WriteLine("Method systax"); //chạy nhanh hơn query rất nhiều

list.Select(stu => new
{
    StudentDetail = $"{stu.RollNumber} : {stu.Fullname}", //mã hóa code = dấu code = che dấu code
    StudentRoom = $"{stu.Section} : {stu.HosteNumber}",
}).ToList().ForEach(Console.WriteLine);

Console.WriteLine();

foreach(var stu in list)
{
    Console.WriteLine(stu);
}
IEnumerator enua = list.GetEnumerator(); //cha duyệt list
while (enua.MoveNext())
{

}

Console.WriteLine("new");
//từ khi có linq
var a = from stu in list
        select stu;
//lần đầu tiên nó sẽ thực thi trên sever và trả về bộ nhớ
//select * from list where rollnumber > 2
IEnumerable<Student> abc = from stu in list //con duyệt linq
                           where stu.RollNumber > 2
                           select stu;
//là vào bộ nhớ loại bỏ chỉ lấy 2 dòng đầu tiên
abc = abc.Take(2);

//lần đầu tiên nó sẽ thực thi trên sever và trả về bộ nhớ
//select * from list where rollnumber > 2
IQueryable<Student> u = from stu in list.AsQueryable() //con duyệt linq
                        where stu.RollNumber > 2
                        select stu;
//select top(2) * from list where rollnumber > 2
//sẽ chạy lên sever lần nữa
u = u.Take(2); //dùng để phân trang
u.ToList().ForEach(Console.WriteLine); //đổ data

Console.WriteLine();
var k = from stu in list //ienumerable = var
        where stu.RollNumber > 2
        select stu;
k.ToList().ForEach(Console.WriteLine); //đổ data

Console.WriteLine("Sort");
//sort = sắp xếp
list.Order(); //auto sắp xếp theo tiêu chí của nó
list.OrderDescending(); //auto sắp xếp ngược lại theo tiêu chí của MS
//linq = from where group by having order => select
var obj = from stu in list
          orderby stu.Section descending, stu.HosteNumber ascending
          select stu;
foreach (var item in obj)
{
    Console.WriteLine(item);
}

Console.WriteLine();
//linq = from where group by having order => select
var obj2 = list.OrderByDescending(stu => stu.Section) //câu này sai do trên vừa sắp desc thì dưới lại asc lại => sai cú pháp
               .OrderBy(stu=>stu.HosteNumber);
foreach (var item in obj2)
{
    Console.WriteLine(item);
}
Console.WriteLine();
//linq = from where group by having order => select
var obj3 = list.Where(stu => stu.RollNumber > 2)
               .OrderByDescending(stu => stu.Section)
               .ThenBy(stu => stu.HosteNumber);
foreach (var item in obj3)
{
    Console.WriteLine(item);
}