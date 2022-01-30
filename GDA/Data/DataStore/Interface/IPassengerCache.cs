using GDA.Model.Entity;

namespace GDA.Data.DataStore.Interface
{
    public interface IPassengerCache
    {
        void Add(Passenger passenger);
        IEnumerable<Passenger> Get();
        Passenger Get(Guid id);
        void Delete(Guid id);
        void Update(Passenger passenger);
    }
}
