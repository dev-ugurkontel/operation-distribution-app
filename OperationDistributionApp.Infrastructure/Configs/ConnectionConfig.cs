namespace OperationDistributionApp.Infrastructure.Configs
{
    public static class ConnectionConfig
    {
        //TODO: Projeyi test ortamından çıkartırken connection string'i buradan kaldırın.
        public static string ConnectionString { get; set; } = "Data Source=KONTEL;Initial Catalog=OperationDistributionDB;User Id=sa;Password=sa;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=False";
    }
}
