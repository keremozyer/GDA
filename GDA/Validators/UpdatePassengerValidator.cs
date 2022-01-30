using FluentValidation;
using GDA.Data.ReferenceCatalog.DocumentType;
using GDA.Model.WebModel;

namespace GDA.Validators
{
    public class UpdatePassengerValidator : AbstractValidator<UpdatePassengerRequestModel>
    {
        public UpdatePassengerValidator(IDocumentTypeCache documentTypeCache)
        {
            RuleFor(x => x.DocumentData).SetValidator(new DocumentModelValidator(documentTypeCache));
        }
    }
}
