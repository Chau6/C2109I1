namespace Exam_21_12_22;
internal class Student
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public bool Gender { get; set; }
    //public DateTime Dob { get; set; }
    public DateOnly Dob { get; set; } //sài DateOnly sẽ nhẹ hơn DateTime

    public override string ToString()
    {
        //return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Fullname)}={Fullname}, {nameof(Gender)}={(Gender==true?"nam":"nữ")}, {nameof(Dob)}={Dob.ToString("MM/dd/yyyy")}}}";
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Fullname)}={Fullname}, {nameof(Gender)}={(Gender == true ? "nam" : "nữ")}, {nameof(Dob)}={Dob.ToString("dd/MMM/yyyy")}}}";
    }
}
