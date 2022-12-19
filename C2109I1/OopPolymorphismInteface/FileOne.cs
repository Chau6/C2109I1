using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopPolymorphismInteface;
internal class FileOne : IBinaryFile, ITextFile
{
    //k dùng bổ từ | nếu 2 thèn sài riêng thì phải chỉ ra
    void IBinaryFile.ReadFile() => Console.WriteLine("Read Binary File");
    void ITextFile.ReadFile() => Console.WriteLine("Read Text File");

    public void WriteBinaryFile() => Console.WriteLine("Write Binary File");

    public void WriteTextFile() => Console.WriteLine("Write Text File");
}
