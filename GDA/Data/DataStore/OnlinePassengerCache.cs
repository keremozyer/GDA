using GDA.Data.DataStore.Interface;
using GDA.Model.Entity;

namespace GDA.Data.DataStore
{
    public sealed class OnlinePassengerCache : IPassengerCache
    {
        private static readonly Lazy<OnlinePassengerCache> Lazy = new(() => new OnlinePassengerCache());
        public static OnlinePassengerCache Instance { get { return Lazy.Value; } }

        private Dictionary<Guid, Passenger> Passengers { get; } = new();

        private OnlinePassengerCache() { }

        public void Add(Passenger passenger)
        {
            if (Instance.Passengers.ContainsKey(passenger.ID))
            {
                return;
            }

            Instance.Passengers.Add(passenger.ID, passenger);
        }

        public IEnumerable<Passenger> Get()
        {
            return Instance.Passengers.Select(p => p.Value);
        }

        public Passenger Get(Guid id)
        {
            if (!Instance.Passengers.ContainsKey(id))
            {
                return null;
            }

            return Instance.Passengers[id];
        }

        public void Delete(Guid id)
        {
            if (Instance.Passengers.ContainsKey(id))
            {
                Instance.Passengers.Remove(id);
            }
        }

        public void Update(Passenger passenger)
        {
            if (!Instance.Passengers.ContainsKey(passenger.ID))
            {
                throw new KeyNotFoundException();
            }

            Instance.Passengers[passenger.ID] = passenger;
        }
    }
}