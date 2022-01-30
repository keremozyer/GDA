using AutoMapper;
using GDA.Model.Entity;
using GDA.Model.WebModel;
using GDA.Model.WebModel.Common;

namespace GDA.Mapper.AutoMapperProfiles
{
    public class PassengerMapperProfile : Profile
    {
        public PassengerMapperProfile()
        {
            CreateMap<DocumentModel, Document>().ReverseMap();

            CreateMap<CreatePassengerRequestModel, Passenger>()
                .ForCtorParam(nameof(Passenger.ID), x => { x.MapFrom(x => Guid.NewGuid()); })
                .ForMember(x => x.Gender, x => { x.MapFrom(x => x.Gender.Value); });

            CreateMap<Passenger, GetPassengerResponseModel>();
        }
    }
}
