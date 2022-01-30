namespace GDA.Data.ReferenceCatalog.DocumentType
{
    public interface IDocumentTypeCache
    {
        IEnumerable<string> List();
        bool DoesExists(string element);
    }
}
