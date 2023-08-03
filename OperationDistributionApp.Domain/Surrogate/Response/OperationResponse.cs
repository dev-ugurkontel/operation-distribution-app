namespace OperationDistributionApp.Domain.Surrogate.Response
{
    public class OperationResponse
    {
        public int OperationID { get; set; }
        public string? Name { get; set; }
        public byte Difficulty { get; set; }

        public IEnumerable<HistoryResponse>? Histories { get; set; }
    }
}
