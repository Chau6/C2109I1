namespace Project_Template_Without_Database.Helper;
internal class Validate<T>
{
    public static T CheckReadLine()
    {
        var typeCode = Type.GetTypeCode(typeof(T));
        var obj = new Object();
        bool flag;
        do
        {
            flag = true;
            try
            {
                var str = Console.ReadLine();
                if(string.IsNullOrEmpty(str))
                {
                    throw new Exception("Error !!! Không được bỏ trống !!!");
                }
                switch(typeCode)
                {
                    case TypeCode.String:
                        obj = str; break;
                    case TypeCode.Int32:
                        obj = Convert.ToInt32(str);
                        if ((int)obj < 0) throw new Exception("Id không được nhỏ hơn 0");
                        break;
                    case TypeCode.Boolean:
                        obj = str.Equals("Nam") || str.Equals("nam") ? true : false;
                        break;
                    case TypeCode.DateTime:
                        var date = DateTime.TryParseExact(str, new[] { "d-M-yyyy", "d/M/yyyy" }, new CultureInfo("vi-VN"), DateTimeStyles.None, out var t)?t:throw new Exception("Nhập sai ngày sinh | dd/mm/yyyy hoặc dd-mm-yyyy");
                        obj = date.Add(DateTime.Now.TimeOfDay); //nhập vào cả giờ phút giây
                        break;
                    default:
                        obj = null; //catch chụp lại bắt nhập lại 
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}:{e.Message}, Nhập lại !!!");
                flag = false;
            }
        }while( !flag ); //lặp khi flag = true

        return (T)obj;
    }
}
