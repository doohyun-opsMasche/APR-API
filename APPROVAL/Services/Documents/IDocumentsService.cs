using System.Collections.Generic;
using System.Threading.Tasks;
using APPROVAL.Dtos.Documents;
using APPROVAL.Models;

namespace APPROVAL.Services.Documents
{
    public interface IDocumentsService
    {
        Task<ServiceResponse<List<DocumentReadDto>>> GetDocumentsAll();
        Task<ServiceResponse<DocumentReadDto>> GetDocumentById(int id);
        Task<ServiceResponse<List<DocumentCreateDto>>> AddDocument(DocumentCreateDto newDocument);
        Task<ServiceResponse<DocumentReadDto>> UpdateDocument(DocumentUpdateDto updatedDocument);
        Task<ServiceResponse<List<DocumentReadDto>>> DeleteDocument(int id);
    }
}