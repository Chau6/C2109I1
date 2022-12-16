
using ArgumentAndParam;

#region khai báo oop
//pure oop
//ArgumentClass argu = new ArgumentClass();
//dùng var
//var argu = new ArgumentClass();
//target-type
ArgumentClass argu = new();
#endregion

//named argument
argu.Display(4, 5, 6);
argu.Display(a: 4, b: 5, c: 6); //có thể tự do thay đổi vị trí a b c :
//optional argument
argu.Show();
argu.Show(10);
argu.Show(10, 5);
argu.Show(10, 5, 4);
argu.Show(c:10, a:5); //mix

int[] arr = { 1, 2, 3, 4, 5, 6 };
argu.SumParam(arr);

argu.SumParam(1,2,3,4,5,6,7,8,9); //sài thèn này tối ưu hơn

