using System;

namespace Exam_21_12_22;
internal class Functions:Student
{
    //List<Student> list = new List<Student>();
    public static List<Student> list = new List<Student>();

    public static void AddStd(int a, string b, bool c, DateOnly d)
    {
        list.Add(new Student
        {
            Id = a,
            Fullname = b,
            Dob = d,
            Gender = c
        });

        ////test nhanh
        //IEnumerator<Student> enu = list.GetEnumerator(); // <= dùng thèn này nhanh hơn foreach
        //while (enu.MoveNext())
        //{
        //    Console.WriteLine(enu.Current);
        //}
    }

    public static void Show()
    {
        //IEnumerator<Student> enu = list.GetEnumerator(); // <= dùng thèn này nhanh hơn foreach
        //while (enu.MoveNext())
        //{
        //    Console.WriteLine(enu.Current);
        //}

        list.ForEach(Console.WriteLine);
    }

    public static void Update(int id, string a, bool b, DateOnly c )
    {
        var result = from stu in list where stu.Id == id select stu;
        try
        {
            result.First().Fullname = a;
            result.First().Gender = b;
            result.First().Dob = c;
        }
        catch(Exception)
        {
            Console.WriteLine("Id k tồn tại");
        }

        ////test nhanh
        //IEnumerator<Student> enu = list.GetEnumerator(); // <= dùng thèn này nhanh hơn foreach
        //while (enu.MoveNext())
        //{
        //    Console.WriteLine(enu.Current);
        //}
    }

    public static void Delete(int id)
    {
        list.RemoveAll(stu => stu.Id == id);

        ////test nhanh
        //IEnumerator<Student> enu = list.GetEnumerator(); // <= dùng thèn này nhanh hơn foreach
        //while (enu.MoveNext())
        //{
        //    Console.WriteLine(enu.Current);
        //}
    }

    public static void Find(int id)
    {
        foreach (var st in (IEnumerable<Student>?)list.Where(stu => stu.Id == id))
        {
            Console.WriteLine(st);
        }
    }

    public static void Sort()
    {
        foreach (var st in (IEnumerable<Student>?)list.OrderBy(stu => stu.Id))
        {
            Console.WriteLine(st);
        }
    }
}
