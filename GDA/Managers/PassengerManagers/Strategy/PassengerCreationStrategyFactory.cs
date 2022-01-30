using GDA.Concern.Enums;
using GDA.Managers.PassengerManagers.Strategy.Concrete;
using GDA.Managers.PassengerManagers.Strategy.Interface;

namespace GDA.Managers.PassengerManagers.Strategy
{
    public static class PassengerCreationStrategyFactory
    {
        public static IPassengerCreationStrategy CreateStrategy(PassengerMode passengerMode)
        {
            return passengerMode switch
            {
                PassengerMode.Online => new OnlinePassengerCreationStrategy(),
                PassengerMode.Offline => new OfflinePassengerCreationStrategy(),
                _ => throw new NotImplementedException("Not Implemented Passenger Mode.")
            };
        }
    }
}
