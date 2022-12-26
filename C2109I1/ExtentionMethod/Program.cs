using ExtentionMethod;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

Console.WriteLine("Vui lòng nhập 1 số: ");
int i = int.TryParse(Console.ReadLine(), out var result)?result:0;

//check i > 100 ? yes : no
CheckNumber.Check(i, 100);

//Console.WriteLine(result); //result = i

//extention method
//k thông qua đối tượng của class đang chứa mà thông qua cái muốn use
i.IsGreaterThan(200); //truyền vào value

int abc = 500;
abc.IsGreaterThan(200); //truyền vào value

Program pro = new Program(); //đối tượng Hi() k được tạo ở Program mà ở ExtentionCheck
pro.Hi();
