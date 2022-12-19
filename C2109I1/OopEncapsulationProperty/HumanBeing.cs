
namespace OopEncapsulationProperty;
internal class HumanBeing
{
    //field must be private
    private string fullname;

    //thuộc tính | property address siêu mới <----------------sài thèn này || you cann't use it code in mobile 
    public string Address {private get; set; } //thèn này buộc phải có getter & setter muốn tắt k cho getter thì thêm private vào
    public int Age { get; set; }

    //getter/setter mới && property
    public string FullName //có thể xóa get || set
    {
        get => fullname;
        set => fullname = value;
    }
    
    public void ShowProperty()
    {
        Console.WriteLine($"{nameof(fullname)} = {fullname}");
        Console.WriteLine($"{nameof(Address)} = {Address}");
        Console.WriteLine($"{nameof(Age)} = {Age}");
    }
}
