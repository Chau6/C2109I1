//Format code ctrl + k + d
#region ? : => ternary operator
double a = 0.1;
double b = 0.2;
Console.WriteLine(a + b == 0.3 ? "True" : "False");

decimal c = 0.1M;
decimal d = 0.2M;
Console.WriteLine(c + d == 0.3M ? "True" : "False");
// ? : => ternary operator
#endregion

#region ? nullable value type
//? nullable value type
string? fullname = null;
//int i = 0; => error
//c# cũ
//Nullable<int> i = null;
//c# mới
//bool? check = null;
#endregion

//int lenght = fullname !=  null ? fullname.Length : 0;
//int? lenght = fullname is not null ? fullname.Length : 0;

//null-conditional operater ?
//tương tự !=, fullname mà != null thì return vế sau
int? length = fullname?.Length; //int? cho phép int null, fullname? kiểm tra xem fullname có null k ? có thì trả về null. k thì trả về vế sau

//null-coalescing operator ??
//tương tự như ==, fullname = null thì trả về vế sau
int cd = fullname?.Length ?? 0; //fullname? kiểm tra xem fullname có null k ? có thì trả về 0. k thì trả về fullname.Lenght