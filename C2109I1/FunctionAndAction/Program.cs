using System.Text;
delegate void Display();
internal class Program
{
    //phương thức = method
    public void Sub(int a, int b) => Console.WriteLine($"Sub = {a - b}");

    public static void Show() => Console.WriteLine("C2109i1");

    public static int ReturnNumber() => 5;

    public static int Multi(int a, int b) => a * b;

    private static void Main(string[] args)
    {
        

        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;

        //local function = hàm cục bộ
        void Add(int a, int b) => Console.WriteLine($"Add = {a + b}");

        //func and act => đều là delegate
        // act dùng cho các method (phương thức) k có kiểu trả về = void
        // func dùng cho các method >< void
        Action act = Show;
        act();
        Console.WriteLine("2 thèn này tương tự nhau");
        //Display a = Show;
        //a();

        Func<int> fun = ReturnNumber; //có int do nó là kiểu trả về
        Console.WriteLine(fun());
        Action<int, int> ac = Add;
        ac(5, 6);

        Func<int, int, int> func = Multi; //nhớ sài func thì cái tham số đầu luôn là kiểu trả về
        Console.WriteLine($"Dòng 38 = {func(10, 5)}");

        Console.WriteLine();
        //a round function
        Action<string> action = (str) => Console.WriteLine(str);
        action("Mother fucker");
    }
}