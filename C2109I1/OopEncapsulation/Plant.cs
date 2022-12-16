
namespace OopEncapsulation;
public class Plant
{
    //encapsulation thể hiện ở 2 nơi:
    //1 là access modify: bổ từ truy cập
    //2 là property: thuộc tính cho nhận

    //1
    private void Private() => Console.WriteLine("Đến đây với e đi ì í ì iiii"); //only this class in this class
    protected void Protected() => Console.WriteLine("I'm comingggggg..."); //just family such as son, child
    internal void Internal() => Console.WriteLine("Á á từ từ thôi, ư ư ư..."); //must in project can be use
    private protected void PrivateProtected() => Console.WriteLine("Nhanh lên em ơi, ư ư ư");
    protected internal void ProtectedInternal() => Console.WriteLine("Em re re, đỡ qué đỡ qué");
    public void Public() => Console.WriteLine("");
}
