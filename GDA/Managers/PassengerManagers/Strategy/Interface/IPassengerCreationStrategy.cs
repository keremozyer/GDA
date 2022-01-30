using GDA.Model.Entity;

namespace GDA.Managers.PassengerManagers.Strategy.Interface
{
    public interface IPassengerCreationStrategy
    {
        void CreatePassenger(Passenger passenger);
        IEnumerable<Passenger> Get();
        Passenger Get(Guid id);
        void Delete(Guid id);
        void Update(Passenger passenger);
    }
}
