using GDA.Concern.Enums;
using GDA.Model.WebModel.Common;

namespace GDA.Model.WebModel
{
    public class GetPassengerResponseModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DocumentModel DocumentData { get; set; }
    }
}
