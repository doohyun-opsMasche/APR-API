using APPROVAL.Dtos.Forms;
using APPROVAL.Models;
using AutoMapper;

namespace APPROVAL.Profiles
{
    public class FormsProfile : Profile
    {
        public FormsProfile()
        {

            CreateMap<FormFileGroup, FormFileGroupRead>();
            CreateMap<FormFileGroupCreate, FormFileGroup>();
        }
    }
}