using ExeciseOop.ExtensionMethod;

namespace ExeciseOop.DAL;
internal class DalProduct : InterfaceProduct //data access layout
{
    //public List<Product> list { get; set; }
    public List<Product> list { get; set; } = new List<Product>(); //<- sài thèn này vừa là đối tượng vừa có thuộc tính getter setter

    public void AddProduct()
    {
        Console.WriteLine("Enter number of product");
        var n = Validate<int>.CheckReadLine();
        for(int i = 0; i < n; i++)
        {
            var pro = new Product();
            Console.WriteLine($"Vui lòng nhập ID của product thứ {i+1}: ");
            pro.ProId = Validate<String>.CheckReadLine();
            Console.WriteLine($"Vui lòng nhập Tên của product thứ {i + 1}: ");
            pro.ProName = Validate<String>.CheckReadLine();
            Console.WriteLine($"Vui lòng nhập Giá của product thứ {i + 1}: ");
            pro.ProPrice = Validate<double>.CheckReadLine();
            Console.WriteLine($"Vui lòng nhập Ngày vào của product thứ {i + 1}: ");
            pro.ProDate = Validate<DateTime>.CheckReadLine();

            list.Add( pro );
            //test nhanh
            IEnumerator<Product> enu = list.GetEnumerator(); // <= dùng thèn này nhanh hơn foreach
            while (enu.MoveNext())
            {
                Console.WriteLine(enu.Current);
            }
        }
    }
}
