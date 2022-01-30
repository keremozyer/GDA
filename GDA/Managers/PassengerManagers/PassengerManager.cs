using AutoMapper;
using GDA.Concern.Enums;
using GDA.Managers.PassengerManagers.Strategy;
using GDA.Model.Entity;
using GDA.Model.WebModel;

namespace GDA.Managers.PassengerManagers
{
    public class PassengerManager : IPassengerManager
    {
        private readonly IMapper Mapper;
        public PassengerManager(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        private PassengerCreationContext CreatePassengerStrategyContext(PassengerMode mode)
        {
            return new PassengerCreationContext(PassengerCreationStrategyFactory.CreateStrategy(mode));
        }

        public void Create(CreatePassengerRequestModel model)
        {
            // Common business operations regarding passenger creation.

            Passenger passenger = this.Mapper.Map<Passenger>(model);

            CreatePassengerStrategyContext(model.Mode.Value).CreatePassenger(passenger);
        }

        public IEnumerable<GetPassengerResponseModel> Get(PassengerMode mode)
        {
            // Common business operations regarding reading passengers.

            return CreatePassengerStrategyContext(mode).Get()?.Select(p => this.Mapper.Map<GetPassengerResponseModel>(p));
        }

        public GetPassengerResponseModel Get(PassengerMode mode, Guid id)
        {
            // Common business operations regarding reading a passenger.

            Passenger passenger = CreatePassengerStrategyContext(mode).Get(id);

            GetPassengerResponseModel response = null;
            if (passenger != null)
            {
                response = this.Mapper.Map<GetPassengerResponseModel>(passenger);
            }

            return response;
        }

        public void Delete(PassengerMode mode, Guid id)
        {
            // Common business operations regarding deleting a passenger.

            CreatePassengerStrategyContext(mode).Delete(id);
        }

        public void Update(PassengerMode mode, Guid id, UpdatePassengerRequestModel request)
        {
            // Common business operations regarding updating a passenger.

            PassengerCreationContext context = CreatePassengerStrategyContext(mode);
            
            Passenger passenger = context.Get(id);
            if (passenger == null)
            {
                throw new KeyNotFoundException();
            }

            passenger.DocumentData = this.Mapper.Map<Document>(request.DocumentData);


            CreatePassengerStrategyContext(mode).Update(passenger);
        }
    }
}
