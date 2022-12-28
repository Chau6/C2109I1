


using ExeciseOop.ExtensionMethod;

namespace ExeciseOop.Helpers;
internal class Validate<T>
{
    public static T CheckReadLine()
    {
        var typeCode = Type.GetTypeCode(typeof(T)); //typeof là kiểu gì -> GetTypeCode sẽ chuyển kiểu 
        var obj = new Object();
        bool flag;
        do
        {
            flag = true;
            try
            {
                var str = Console.ReadLine();
                //if (str == null)
                //if (str is {}) //bắt hết cho all language
                if (string.IsNullOrEmpty(str)) //<- sài thèn này
                {
                    throw new Exception("Error, null or empty"); //gặp thèn này là nó ngưng, xuống catch chạy
                }
                switch (typeCode)
                {
                    case TypeCode.String:
                        obj = str;
                        break;
                    case TypeCode.Int32:
                        obj= Convert.ToInt32(str);
                        if((int)obj < 0) throw new Exception("Value must be greatter than 0"); //nhỏ hơn 0 thì... 
                        break;
                    case TypeCode.Double:
                        obj = Convert.ToDouble(str);
                        if ((double)obj < 0) throw new Exception("Value must be greatter than 0"); //nhỏ hơn 0 thì... 
                        break;
                    case TypeCode.DateTime: //TryParse trả về true hoặc false | Parse thì parse được thì parse, k thì lỗi
                        var date = DateTime.TryParseExact(str, new[] {"d-M-yyyy", "d/M/yyyy"}, new CultureInfo("vi-VN"), DateTimeStyles.None, out var t)?t:throw new Exception("DateTime wrong | d/M/yyyy or d-M-yyyy");
                        obj = date.Add(DateTime.Now.TimeOfDay); //nhập vào cả giờ phút giây
                        break;
                    case TypeCode.Char:
                        obj = Convert.ToChar(str.ToLower()); //về chữ thường
                        if (!obj.In('y', 'n')) throw new Exception("Error, must be y or n"); //buộc phải nhập vào y hay n
                        break;
                    default:
                        obj = null; //catch chụp lại bắt nhập lại 
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}:{e.Message}, please enter again <3");
                flag = false;
            }
        } while (!flag);

        return (T)obj;
    }
}
