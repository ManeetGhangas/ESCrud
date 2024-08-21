
using Nest;

namespace ESCrud.API.Service
{
    public class ElasticSearchService<T> : IElasticSearchService<T> where T : class
    {
        private readonly ElasticClient _client;

        public  ElasticSearchService(ElasticClient client)
        {
             _client = client;
        }

        public async Task<string> CreateDocumentAsync(T Document)
        {
            var response = await  _client.IndexDocumentAsync(Document);
            return response.IsValid? "Document Created Succesfully": "failed Document Creation ";
        }

        public async Task<string> DeleteDocumentAsync(int Id)
        {
            var response = await _client.DeleteAsync(new DocumentPath<T>(Id));
            return response.IsValid ? "Document Deleted Succesfully" : "failed Document Deletion ";
        }

        public async Task<IEnumerable<T>> GetAllDocument()
        {
            var searchResponse = await _client.SearchAsync<T>(x => x.MatchAll()
                .Size(10000));
            return searchResponse.Documents;
        }

        public async Task<T> GetDocument(int id)
        {
            var response = await _client.GetAsync(new DocumentPath<T>(id));
            return response.Source;
        }

        public async Task<string> UpdateDocumentAsync(T Document)
        {
            var response = await _client.UpdateAsync(new DocumentPath<T>(Document),x => x.Doc(Document)
            .RetryOnConflict(3));
            return response.IsValid ? "Document Updated Succesfully" : "failed Document Updation";
        }
    }
}
