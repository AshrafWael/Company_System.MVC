﻿namespace Company_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
