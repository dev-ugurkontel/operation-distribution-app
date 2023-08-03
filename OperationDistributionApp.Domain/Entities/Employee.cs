namespace OperationDistributionApp.Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
            Histories = new HashSet<History>();
        }

        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
