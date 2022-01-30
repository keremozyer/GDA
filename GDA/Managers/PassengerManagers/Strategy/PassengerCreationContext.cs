using GDA.Managers.PassengerManagers.Strategy.Interface;
using GDA.Model.Entity;

namespace GDA.Managers.PassengerManagers.Strategy
{
    public class PassengerCreationContext
    {
        private readonly IPassengerCreationStrategy Strategy;
        public PassengerCreationContext(IPassengerCreationStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public void CreatePassenger(Passenger passenger)
        {
            this.Strategy.CreatePassenger(passenger);
        }

        public IEnumerable<Passenger> Get()
        {
            return this.Strategy.Get();
        }

        public Passenger Get(Guid id)
        {
            return this.Strategy.Get(id);
        }

        public void Delete(Guid id)
        {
            this.Strategy.Delete(id);
        }

        public void Update(Passenger passenger)
        {
            this.Strategy.Update(passenger);
        }
    }
}
