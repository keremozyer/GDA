using GDA.Data.DataStore;
using GDA.Data.DataStore.Interface;
using GDA.Managers.PassengerManagers.Strategy.Interface;
using GDA.Model.Entity;

namespace GDA.Managers.PassengerManagers.Strategy.Concrete
{
    public class OnlinePassengerCreationStrategy : IPassengerCreationStrategy
    {
        private readonly IPassengerCache Cache;

        public OnlinePassengerCreationStrategy()
        {
            this.Cache = OnlinePassengerCache.Instance;
        }

        public void CreatePassenger(Passenger passenger)
        {
            // Business operations regarding online passenger creation.

            this.Cache.Add(passenger);
        }

        public IEnumerable<Passenger> Get()
        {
            // Business operations regarding reading online passengers.

            return this.Cache.Get();
        }

        public Passenger Get(Guid id)
        {
            // Business operations regarding reading an online passenger.

            return this.Cache.Get(id);
        }

        public void Delete(Guid id)
        {
            // Business operations regarding deleting an online passenger.

            this.Cache.Delete(id);
        }

        public void Update(Passenger passenger)
        {
            // Business operations regarding updating an online passenger.

            this.Cache.Update(passenger);
        }
    }
}
