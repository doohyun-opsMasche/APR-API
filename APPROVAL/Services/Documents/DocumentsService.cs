using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPROVAL.Data;
using APPROVAL.Dtos.Documents;
using APPROVAL.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APPROVAL.Services.Documents
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public DocumentsService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<DocumentCreateDto>>> AddDocument(DocumentCreateDto newDocument)
        {
            ServiceResponse<List<DocumentCreateDto>> serviceResponse = new ServiceResponse<List<DocumentCreateDto>>();
            Document document = _mapper.Map<Document>(newDocument);
            await _context.Documents.AddAsync(document);
            await _context.SaveChangesAsync();
            serviceResponse.data = (_context.Documents.Select(c => _mapper.Map<DocumentCreateDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DocumentReadDto>>> GetDocumentsAll()
        {
            ServiceResponse<List<DocumentReadDto>> serviceResponse = new ServiceResponse<List<DocumentReadDto>>();
            List<Document> documents = await _context.Documents.ToListAsync();
            serviceResponse.data = (documents.Select(c => _mapper.Map<DocumentReadDto>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<DocumentReadDto>> GetDocumentById(int id)
        {
            ServiceResponse<DocumentReadDto> serviceResponse = new ServiceResponse<DocumentReadDto>();
            Document dbDocuments = await _context.Documents.FirstOrDefaultAsync(c => c.processId == id);
            serviceResponse.data = _mapper.Map<DocumentReadDto>(dbDocuments);

            return serviceResponse;
        }

        public async Task<ServiceResponse<DocumentReadDto>> UpdateDocument(DocumentUpdateDto updatedDocument)
        {
            ServiceResponse<DocumentReadDto> serviceResponse = new ServiceResponse<DocumentReadDto>();
            try
            {
                Document document = await _context.Documents.FirstOrDefaultAsync(c => c.processId == updatedDocument.processId);
                _context.Update(document);
                await _context.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<DocumentReadDto>(document);
            }
            catch (Exception ex)
            {
                serviceResponse.completed = false;
                serviceResponse.message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DocumentReadDto>>> DeleteDocument(int id)
        {
            ServiceResponse<List<DocumentReadDto>> serviceResponse = new ServiceResponse<List<DocumentReadDto>>();
            try
            {
                Document document = await _context.Documents.FirstAsync(c => c.processId == id);
                _context.Documents.Remove(document);
                await _context.SaveChangesAsync();

                serviceResponse.data = (_context.Documents.Select(c => _mapper.Map<DocumentReadDto>(c))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.completed = false;
                serviceResponse.message = ex.Message;
            }

            return serviceResponse;
        }
    }
}