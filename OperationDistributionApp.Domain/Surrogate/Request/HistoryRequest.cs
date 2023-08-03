namespace OperationDistributionApp.Domain.Surrogate.Request
{
    public class HistoryRequest
    {
        public required int EmployeeID { get; set; }
        public required int OperationID { get; set; }
        public required bool IsActive { get; set; }
    }
}
