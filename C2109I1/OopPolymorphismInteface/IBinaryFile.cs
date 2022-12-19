using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismInteface;
internal interface IBinaryFile
{
    //chỉ có tên phương thức và kiểu trả về
    void WriteBinaryFile(); //k có bổ từ
    void ReadFile();

    //phương thức mặc định của interface
    void ShowInfo() => Console.WriteLine("This is Binary File"); //bắt buộc phải sài theo thèn này
}
