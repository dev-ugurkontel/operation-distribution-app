namespace OperationDistributionApp.Domain.Entities
{
    public class Operation
    {
        public Operation()
        {
            Histories = new HashSet<History>();
        }

        public int OperationID { get; set; }
        public string? Name { get; set; }

        public byte Difficulty { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
