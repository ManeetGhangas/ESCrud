using ESCrud.API.Model;
using ESCrud.API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ESCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticSearchController : ControllerBase
    {
        private readonly Service.IElasticSearchService<MyDocument> _elasticSearchService;
        public ElasticSearchController(IElasticSearchService<MyDocument> elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDocument()
        {
            var response = await _elasticSearchService.GetAllDocument();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocumnet([FromBody] MyDocument document)
        {
            var response = await _elasticSearchService.CreateDocumentAsync(document);
            return Ok(response);
        }
        [HttpGet]
        [Route("read/{id}")]
        public async Task<IActionResult> GetDocument(int id)
        {
            var response = await _elasticSearchService.GetDocument(id);
            if (response == null)
            {
                NotFound();
            }
            return Ok(response);
        }

        [HttpPut]
       
        public async Task<IActionResult> UpdateDocumnet(MyDocument document)
        {
            var response = await _elasticSearchService.UpdateDocumentAsync(document);
            return Ok(response);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteDocument(int Id)
        {
            var response = await _elasticSearchService.DeleteDocumentAsync(Id);
            return Ok(response);
        }
    }
}
