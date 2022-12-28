//mvc = model view controler

//đi từ view -> controler -> view ... k qua model
//đi từ view -> controler -> model -> controler ...
//                                 -> view ...

//khi nào nên tách class = project ? 
//- khi project này được dùng cho nhiều project khác (trùng field) - tái sử dụng

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

Product pro = new();
//Console.WriteLine("Vui lòng nhập ID hàng hóa");
//pro.ProId = Validate<string>.CheckReadLine();

//Console.WriteLine("Vui lòng nhập Số lượng hàng hóa");
//pro.ProQuantity = Validate<int>.CheckReadLine();

//Console.WriteLine("Vui lòng nhập ngày vào hàng hóa");
//pro.ProDate = Validate<DateTime>.CheckReadLine();
DalProduct dal = new();
pro.ChangeColor(ConsoleColor.Red, ConsoleColor.Yellow);
dal.AddProduct();
//Console.WriteLine(pro);