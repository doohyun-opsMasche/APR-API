using APPROVAL.Data;
using APPROVAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace APPROVAL.Services
{
    public class FormService : IFormService
    {
        private readonly DataContext _context;

        public FormService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Form Add(Form form)
        {
            return _context.Forms.Add(form).Entity;
        }

        public async Task<Form> FindAsync(Form form)
        {
            return await _context.Forms.Where(s => s.name == form.name).SingleOrDefaultAsync();
        }

        public async Task<Form> FindByColumnAsync(Form form)
        {
            return await _context.Forms.Where(s => s.name == form.name).SingleOrDefaultAsync();
        }

        public async Task<Form> GetAsync(Form form)
        {
            var vform = await _context.Forms
                               .FirstOrDefaultAsync(o => o.id == form.id);
            if (vform == null)
            {
                vform = _context.Forms
                            .Local
                            .FirstOrDefault(o => o.id == form.id);
            }
            if (vform != null)
            {

            }

            return vform;
        }

        public async Task<List<Form>> GetListAsync(Form form)
        {
            return await _context.Forms
                .Where(b => b.id == form.id)
                .ToListAsync<Form>();
        }

        public void Update(Form form)
        {
            _context.Entry(form).State = EntityState.Modified;
        }
    }
}
