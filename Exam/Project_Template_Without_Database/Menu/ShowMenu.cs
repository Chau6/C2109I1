namespace Project_Template_Without_Database.Menu;
internal class ShowMenu
{
    public static void Menu()
    {
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("================Format code ctrl + k + d===================");
            Console.WriteLine("=          Gõ 1 để nhập thông tin sinh viên mới           =");
            Console.WriteLine("=          Gõ 2 để xem list toàn bộ sinh viên             =");
            Console.WriteLine("=          Gõ 3 để cập nhật thông tin sinh viên           =");
            Console.WriteLine("=          Gõ 4 để xóa sinh viên ra khỏi list             =");
            Console.WriteLine("=          Gõ 5 để tìm kiếm thông tin sinh viên           =");
            Console.WriteLine("=          Gõ 6 để sắp xếp thông tin sinh viên            =");
            Console.WriteLine("= Gõ số bất kỳ để thoát chương trình, đừng gõ chữ nhe :>  =");
            Console.WriteLine("===========================================================");
            Console.WriteLine();

            Console.Write("Vui lòng nhập lựa chọn của bạn: ");
            var i = int.TryParse(Console.ReadLine(), out var result) ? result : 0;

            if (result is 0)
            {
                Console.Write("Giá trị nhập vào phải là số");
            }
            else
            {
                switch (result)
                {
                    case 1: DAL_Student.AddStudent(); break;
                    case 2: DAL_Student.ShowList(); break;
                    case 3: DAL_Student.UpdateStudent(); break;
                    case 4: DAL_Student.DeleteStudent(); break;
                    case 5: DAL_Student.FindStudent(); break;
                    case 6: DAL_Student.SortStudent(); break;
                    default:
                        flag= false;
                        Console.WriteLine("Cám ơn bạn đã sử dụng chương trình");
                        break;
                }
            }
        }
    }
}
