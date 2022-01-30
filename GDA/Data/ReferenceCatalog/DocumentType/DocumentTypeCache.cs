namespace GDA.Data.ReferenceCatalog.DocumentType
{
    public class DocumentTypeCache : IDocumentTypeCache
    {
        private readonly IReadOnlyCollection<string> Data = new string[] { "Pasaport", "Visa", "TravelDocument " };

        public bool DoesExists(string element)
        {
            return this.Data.Contains(element);
        }

        public IEnumerable<string> List()
        {
            return this.Data;
        }
    }
}
