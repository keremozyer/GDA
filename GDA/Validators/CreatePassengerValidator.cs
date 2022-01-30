using FluentValidation;
using GDA.Data.ReferenceCatalog.DocumentType;
using GDA.Model.WebModel;

namespace GDA.Validators
{
    public class CreatePassengerValidator : AbstractValidator<CreatePassengerRequestModel>
    {
        public CreatePassengerValidator(IDocumentTypeCache documentTypeCache)
        {
            RuleFor(x => x.Mode).NotNull().WithMessage($"{nameof(CreatePassengerRequestModel.Mode)} Cannot Be Empty.");
            RuleFor(x => x.Gender).NotNull().WithMessage($"{nameof(CreatePassengerRequestModel.Gender)} Cannot Be Empty.");
            RuleFor(x => x.Name).NotEmpty().WithMessage($"{nameof(CreatePassengerRequestModel.Name)} Cannot Be Empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage($"{nameof(CreatePassengerRequestModel.Surname)} Cannot Be Empty.");
            RuleFor(x => x.DocumentData).SetValidator(new DocumentModelValidator(documentTypeCache));
        }
    }
}
