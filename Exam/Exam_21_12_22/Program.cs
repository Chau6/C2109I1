//Format code ctrl + k + d
Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

var flag = true;

while (flag)
{
    Menu.ShowMenu();
    Console.WriteLine("Vui lòng nhập lựa chọn của bạn: ");
    int i = int.TryParse(Console.ReadLine(), out var result) ? result : 0;
    //Console.WriteLine(result);
    if (result is 0)
    {
        Console.WriteLine("Giá trị nhập vào phải là số @@@");
    }
    else
    {
        switch (result)
        {
            case 1:
                Console.WriteLine("Vui lòng nhập id: ");
                int id = int.TryParse(Console.ReadLine(), out var n1) ? n1 : 0;
                while (n1 == 0)
                {
                    Console.WriteLine("Nhập sai, vui lòng nhập lại id: ");
                    id = int.TryParse(Console.ReadLine(), out n1) ? n1 : 0;
                }
                Console.WriteLine("Vui lòng nhập họ tên");
                string fullname = Console.ReadLine();

                Console.WriteLine("Vui lòng nhập giới tính | nam = nam và nu = nữ: ");
                string gender = Console.ReadLine();
                bool checkgender;
                switch (gender)
                {
                    case "nam":
                        checkgender = false;
                        break;
                    case "nu":
                        checkgender = false;
                        break;
                    default:
                        checkgender = true;
                        break;
                }
                while (checkgender)
                {
                    Console.WriteLine("Vui lòng nhập lại giới tính");
                    gender = Console.ReadLine();
                    switch (gender)
                    {
                        case "nam":
                            checkgender = false;
                            break;
                        case "nu":
                            checkgender = false;
                            break;
                        default:
                            checkgender = true;
                            break;
                    }
                }

                Console.WriteLine("Vui lòng nhập ngày sinh | dd/mm/yyyy: ");
                string date = Console.ReadLine(); //nhập sai từ đây
                //DateTime dob = Convert.ToDateTime(date);
                //Regex regex = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace);
                Match x = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace).Match(date);
                while (x.Success == false)
                {
                    Console.WriteLine("Vui lòng nhập lại ngày sinh | dd/mm/yyyy");
                    date = Console.ReadLine();
                    //regex = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace);
                    x = x = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace).Match(date);
                }
                //DateTime dob = Convert.ToDateTime(date);

                Functions.AddStd(id, fullname, gender == "nam" ? true : false, DateOnly.Parse(date));
                Console.WriteLine("Success");
                break;
            case 2:
                Functions.Show();
                Console.WriteLine("Success");
                break;
            case 3:
                Console.WriteLine("Vui lòng nhập id: ");
                id = int.TryParse(Console.ReadLine(), out n1) ? n1 : 0;
                while (n1 == 0)
                {
                    Console.WriteLine("Nhập sai, vui lòng nhập lại id: ");
                    id = int.TryParse(Console.ReadLine(), out n1) ? n1 : 0;
                }
                Console.WriteLine("Vui lòng nhập họ tên");
                fullname = Console.ReadLine();

                Console.WriteLine("Vui lòng nhập giới tính | nam = nam và nu = nữ: ");
                gender = Console.ReadLine();
                bool checkgenderUpdate;
                switch (gender)
                {
                    case "nam":
                        checkgenderUpdate = false;
                        break;
                    case "nu":
                        checkgenderUpdate = false;
                        break;
                    default:
                        checkgenderUpdate = true;
                        break;
                }
                while (checkgenderUpdate)
                {
                    Console.WriteLine("Vui lòng nhập lại giới tính");
                    gender = Console.ReadLine();
                    switch (gender)
                    {
                        case "nam":
                            checkgenderUpdate = false;
                            break;
                        case "nu":
                            checkgenderUpdate = false;
                            break;
                        default:
                            checkgenderUpdate = true;
                            break;
                    }
                }

                Console.WriteLine("Vui lòng nhập ngày sinh | dd/mm/yyyy: ");
                date = Console.ReadLine(); //nhập sai từ đây
                //DateTime dob = Convert.ToDateTime(date);
                //regex = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace);
                x = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace).Match(date);
                while (x.Success == false)
                {
                    Console.WriteLine("Vui lòng nhập lại ngày sinh | dd/mm/yyyy");
                    date = Console.ReadLine();
                    //regex = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace);
                    x = new Regex(Helper.DATE, RegexOptions.IgnorePatternWhitespace).Match(date);
                }
                //dob = Convert.ToDateTime(date);

                Functions.Update(id, fullname, gender == "nam" ? true : false, DateOnly.Parse(date));
                Console.WriteLine("Success");
                break;
            case 4:
                Console.WriteLine("Vui lòng nhập id: ");
                id = int.TryParse(Console.ReadLine(), out n1) ? n1 : 0;
                while (n1 == 0)
                {
                    Console.WriteLine("Nhập sai, vui lòng nhập lại id: ");
                    id = int.TryParse(Console.ReadLine(), out n1) ? n1 : 0;
                }

                Functions.Delete(id);
                Console.WriteLine("Success");
                break;
            case 5:
                Console.WriteLine("Vui lòng nhập id: ");
                id = int.TryParse(Console.ReadLine(), out n1) ? n1 : 0;
                while (n1 == 0)
                {
                    Console.WriteLine("Nhập sai, vui lòng nhập lại id: ");
                    id = int.TryParse(Console.ReadLine(), out n1) ? n1 : 0;
                }

                Functions.Find(id);
                Console.WriteLine("Success");
                break;
            case 6:
                Functions.Sort();
                Console.WriteLine("Success");
                break;
            default:
                flag = false;
                Console.WriteLine("Cám ơn bạn đã sử dụng chương trình <3");
                break;
        }
    }
}

//DateOnly date = new DateOnly(2022, 12, 12);
//Console.WriteLine(date); //return 01/01/01

//DateTime day = DateTime.Today;
//Console.WriteLine(day); //return current date

//if (DateOnly.TryParse("2022/02/01", out DateOnly result))
//{
//    Console.WriteLine($"Parsed DateOnly: {result}");
//}