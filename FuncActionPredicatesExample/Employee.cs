
namespace FuncActionPredicateExample
{
    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool Mannagement { get; set; }
            
        public Employee( int Id, string Name, string LastName, decimal AnnualSalary, char Gender, bool Mannagement)
        {
            this.Id= Id;
            this.Name= Name;
            this.LastName= LastName;
            this.AnnualSalary= AnnualSalary;
            this.Gender= Gender;
            this.Mannagement= Mannagement;
        }
    }
}