
namespace OopEncapsulation;
internal class SunFlower:Plant
{
    //svm
    static void Main(string[] args)
    {
        Plant p = new();
        p.Public();
        p.Internal();
        p.ProtectedInternal();

        SunFlower s = new();
        s.Public();
        s.Internal();
        s.Protected();
        s.ProtectedInternal();
        s.PrivateProtected();
    }
}
