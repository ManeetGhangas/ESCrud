namespace ESCrud.API.Service
{
    public interface IElasticSearchService<T>
    {
        Task<string> CreateDocumentAsync(T Document);
        Task<T> GetDocument(int id);
        Task<IEnumerable<T>> GetAllDocument();
        Task<string> UpdateDocumentAsync(T Document);
        Task<string> DeleteDocumentAsync(int Id);
        
    }
}
