namespace OperationDistributionApp.Domain.Entities
{
    public class History
    {
        public int HistoryID { get; set; }
        public int EmployeeID { get; set; }
        public int OperationID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Operation? Operation { get; set; }
    }
}
