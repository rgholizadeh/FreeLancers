namespace FreeLancersWebApi.Modells
{
    public class FreeLancersDatabaseSettings:IFreeLancersDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string FreeLancersCollectionName { get; set; } = string.Empty;
    }
}
