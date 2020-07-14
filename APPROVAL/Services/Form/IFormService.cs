using APPROVAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPROVAL.Services
{
    public interface IFormService
    {
        Form Add(Form form);
        void Update(Form form);
        Task<Form> GetAsync(Form form);
        Task<List<Form>> GetListAsync(Form form);
        Task<Form> FindAsync(Form form);
        Task<Form> FindByColumnAsync(Form form);
    }
}