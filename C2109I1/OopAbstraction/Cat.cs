
namespace OopAbstraction;
internal abstract class Cat:Animal
{
    bool gender; //mặc định là private

    public void ShowInfoCat()
    {
        Console.WriteLine($"{nameof(gender)} = {gender}");
    }
}
