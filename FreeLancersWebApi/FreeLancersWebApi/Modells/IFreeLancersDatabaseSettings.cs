namespace FreeLancersWebApi.Modells
{
    public interface IFreeLancersDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string FreeLancersCollectionName { get; set; }
    }
}
