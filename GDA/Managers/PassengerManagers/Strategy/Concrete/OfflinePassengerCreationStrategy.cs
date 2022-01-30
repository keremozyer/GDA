using GDA.Data.DataStore;
using GDA.Data.DataStore.Interface;
using GDA.Managers.PassengerManagers.Strategy.Interface;
using GDA.Model.Entity;

namespace GDA.Managers.PassengerManagers.Strategy.Concrete
{
    public class OfflinePassengerCreationStrategy : IPassengerCreationStrategy
    {
        private readonly IPassengerCache Cache;

        public OfflinePassengerCreationStrategy()
        {
            this.Cache = OfflinePassengerCache.Instance;
        }

        public void CreatePassenger(Passenger passenger)
        {
            // Business operations regarding offline passenger creation.

            this.Cache.Add(passenger);
        }

        public IEnumerable<Passenger> Get()
        {
            // Business operations regarding reading offline passengers.

            return this.Cache.Get();
        }

        public Passenger Get(Guid id)
        {
            // Business operations regarding reading an offline passenger.

            return this.Cache.Get(id);
        }

        public void Delete(Guid id)
        {
            // Business operations regarding deleting an offline passenger.

            this.Cache.Delete(id);
        }

        public void Update(Passenger passenger)
        {
            // Business operations regarding updating an offline passenger.

            this.Cache.Update(passenger);
        }
    }
}
