using GDA.Concern.Enums;
using GDA.Model.WebModel.Common;

namespace GDA.Model.WebModel
{
    public record CreatePassengerRequestModel
    {
        public PassengerMode? Mode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender? Gender { get; set; }
        public DocumentModel DocumentData { get; set; }
    }
}
