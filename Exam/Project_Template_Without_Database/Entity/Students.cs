namespace Project_Template_Without_Database.Entity;
internal class Students
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public bool Gender { get; set; }
    public DateTime Dob { get; set; }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Fullname)}={Fullname}, {nameof(Gender)}={(Gender == true ? "nam" : "nữ")}, {nameof(Dob)}={Dob.ToString("dd/MMM/yyyy h:m:s")}}}";
    }
}
