using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPROVAL.Dtos.Documents;
using APPROVAL.Models;
using APPROVAL.Services.Documents;
using Microsoft.AspNetCore.Mvc;

namespace APPROVAL.Controllers
{
    //api ApprovalStatus
    /// <summary>
    /// default version : 1.0
    /// 각 버전별로 mapping 을 해야함
    /// </summary>

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    public class ApprovalDocumentsController : ControllerBase
    {
        private readonly IDocumentsService _documentService;
        public ApprovalDocumentsController(IDocumentsService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            return Ok(await _documentService.GetDocumentsAll());
        }

        [HttpGet("{id}", Name = "GetDocumentById"), ApiVersion("1.0")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            return Ok(await _documentService.GetDocumentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddDocument(DocumentCreateDto document)
        {
            return Ok(await _documentService.AddDocument(document));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument(DocumentUpdateDto updatedDocument)
        {
            ServiceResponse<DocumentReadDto> response = await _documentService.UpdateDocument(updatedDocument);
            if (response.data == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteDocument"), ApiVersion("1.0")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            ServiceResponse<List<DocumentReadDto>> response = await _documentService.DeleteDocument(id);
            if (response.data == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}