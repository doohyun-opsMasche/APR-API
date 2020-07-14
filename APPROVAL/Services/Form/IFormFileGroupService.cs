using APPROVAL.Dtos.Forms;
using APPROVAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPROVAL.Services
{
    public interface IFormFileGroupService
    {
        Task<ServiceResponse<List<FormFileGroupCreate>>> Add(FormFileGroup group);
        void Update(FormFileGroupCreate group);
        Task<List<FormFileGroup>> GetListAsync();
    }
}