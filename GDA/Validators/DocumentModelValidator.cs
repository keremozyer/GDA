using FluentValidation;
using GDA.Data.ReferenceCatalog.DocumentType;
using GDA.Model.WebModel.Common;

namespace GDA.Validators
{
    public class DocumentModelValidator : AbstractValidator<DocumentModel>
    {
        private readonly IDocumentTypeCache DocumentTypeCache;

        public DocumentModelValidator(IDocumentTypeCache documentTypeCache)
        {
            this.DocumentTypeCache = documentTypeCache;
            
            RuleFor(x => x.DocumentNo).NotEmpty().WithMessage($"{nameof(DocumentModel.DocumentNo)} Cannot Be Empty.");

            RuleFor(x => x.DocumentType)
                .NotEmpty().WithMessage($"{nameof(DocumentModel.DocumentType)} Cannot Be Empty.")
                .Must(IsValidDocumentType).WithMessage($"{nameof(DocumentModel.DocumentType)} Value Must Be One Of These: {String.Join(",", this.DocumentTypeCache.List())}");

            RuleFor(x => x.IssueDate).NotEqual(DateTime.MinValue).WithMessage($"{nameof(DocumentModel.IssueDate)} Cannot Be Empty.");
        }

        private bool IsValidDocumentType(string documentType)
        {
            return this.DocumentTypeCache.List().Contains(documentType);
        }
    }
}
