//click phải chuột vào project cont -> add -> project reference -> trỏ đến project cần sài
using OopEncapsulation;

namespace OopEncapsulationCont;
internal class Weed:Plant
{
    static void Main(string[] args)
    {
        Weed w = new Weed();
        w.Protected();
        w.ProtectedInternal();
    }

}
