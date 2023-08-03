namespace OperationDistributionApp.Domain.Surrogate.Response
{
    public class EmployeeResponse
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public IEnumerable<HistoryResponse>? Histories { get; set; }
    }
}
