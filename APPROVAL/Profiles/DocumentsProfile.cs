using APPROVAL.Dtos.Documents;
using APPROVAL.Models;
using AutoMapper;

namespace APPROVAL.Profiles
{
    public class DocumentsProfile : Profile
    {
        public DocumentsProfile()
        {
            CreateMap<Document, DocumentReadDto>();
            CreateMap<DocumentCreateDto, Document>();
        }
    }
}