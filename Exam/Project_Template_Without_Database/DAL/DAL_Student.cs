namespace Project_Template_Without_Database.DAL;
internal class DAL_Student
{
    public static List<Students> list { get; set; } = new List<Students>(); //<- sài thèn này vừa là đối tượng vừa có thuộc tính getter setter

    public static void AddStudent()
    {
        Console.WriteLine("Bạn muốn nhập bao nhiêu học sinh ?");
        var n = Validate<int>.CheckReadLine();
        for (int i = 0; i < n; i++)
        {
            var stu = new Students();

            Console.Write($"Nhập id của học sinh thứ {i+1}: ");
            stu.Id = Validate<int>.CheckReadLine();

            Console.Write($"Nhập họ và tên của học sinh thứ {i + 1}: ");
            stu.Fullname = Validate<string>.CheckReadLine();

            Console.Write($"Nhập giới tính của học sinh thứ {i + 1}: ");
            stu.Gender = Validate<bool>.CheckReadLine();

            Console.Write($"Nhập ngày sinh của học sinh thứ {i + 1}: ");
            stu.Dob = Validate<DateTime>.CheckReadLine();

            list.Add( stu );
            Console.WriteLine("Nhập thành công \n");
            ////test nhanh
            //IEnumerator<Students> enu = list.GetEnumerator(); // <= dùng thèn này nhanh hơn foreach
            //while (enu.MoveNext())
            //{
            //    Console.WriteLine(enu.Current);
            //}
        }
    }

    public static void ShowList() => list.ForEach(Console.WriteLine);

    public static void UpdateStudent()
    {
        Console.Write("Nhập id sinh viên bạn cần sửa: ");
        var id = Validate<int>.CheckReadLine();
        var rs = from stu in list where stu.Id == id select stu;
        try
        {
            rs.First().Id = id; //bẩy lỗi
            Console.Write("Nhập họ và tên của học sinh: ");
            rs.First().Fullname = Validate<string>.CheckReadLine();

            Console.Write("Nhập giới tính của học sinh: ");
            rs.First().Gender = Validate<bool>.CheckReadLine();

            Console.Write("Nhập ngày sinh của học sinh: ");
            rs.First().Dob = Validate<DateTime>.CheckReadLine();

            Console.WriteLine("Cập nhật thành công \n");
        }
        catch (Exception)
        {
            Console.WriteLine("Id k tồn tại");
        }
    }

    public static void DeleteStudent()
    {
        Console.Write("Nhập id sinh viên bạn cần xóa: ");
        var id = Validate<int>.CheckReadLine();

        list.RemoveAll(stu => stu.Id == id);
        Console.WriteLine("Xóa thành công \n");
    }

    public static void FindStudent()
    {
        Console.Write("Nhập id sinh viên bạn cần tìm: ");
        var id = Validate<int>.CheckReadLine();

        foreach (var i in (IEnumerable<Students>?)list.Where(stu => stu.Id == id))
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Tìm thành công:");
    }

    public static void SortStudent()
    {
        foreach (var i in (IEnumerable<Students>?)list.OrderBy(stu => stu.Id))
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Sắp xếp thành công:");
    }
}
