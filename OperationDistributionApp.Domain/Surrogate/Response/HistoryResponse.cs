namespace OperationDistributionApp.Domain.Surrogate.Response
{
    public class HistoryResponse
    {
        public int HistoryID { get; set; }
        public int EmployeeID { get; set; }
        public int OperationID { get; set; }
        public bool IsActive { get; set; }
        public byte Difficulty { get; set; }
        public DateTime CreatedAt { get; set; }

        public EmployeeResponse? Employee { get; set; }
        public OperationResponse? Operation { get; set; }
    }
}
