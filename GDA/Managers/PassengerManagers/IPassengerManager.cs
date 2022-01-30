using GDA.Concern.Enums;
using GDA.Model.WebModel;

namespace GDA.Managers.PassengerManagers
{
    public interface IPassengerManager
    {
        void Create(CreatePassengerRequestModel model);
        IEnumerable<GetPassengerResponseModel> Get(PassengerMode mode);
        GetPassengerResponseModel Get(PassengerMode mode, Guid id);
        void Delete(PassengerMode mode, Guid id);
        void Update(PassengerMode mode, Guid id, UpdatePassengerRequestModel request);
    }
}
