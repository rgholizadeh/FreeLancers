using FreeLancersWebApi.Modells;

namespace FreeLancersWebApi.Services
{
    public interface IFreeLancerService
    {
        List<FreeLancer> Get();
        FreeLancer Get(Guid id);
        FreeLancer Create(FreeLancer freeLancer);
        void Update(Guid id, FreeLancer freeLancer);
        void Remove(Guid id);
    }
}
