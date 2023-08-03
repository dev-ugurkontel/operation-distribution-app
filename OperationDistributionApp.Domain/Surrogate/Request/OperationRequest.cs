namespace OperationDistributionApp.Domain.Surrogate.Request
{
    public class OperationRequest
    {
        public string? Name { get; set; }
        public required byte Difficulty { get; set; }
    }
}
