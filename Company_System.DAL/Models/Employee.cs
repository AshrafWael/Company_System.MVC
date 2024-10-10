namespace Company_System.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Age { get; set; }
        public string ImgUrl { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
