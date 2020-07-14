using APPROVAL.Data;
using APPROVAL.Dtos.Forms;
using APPROVAL.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPROVAL.Services
{
    public class FormFileGroupService : IFormFileGroupService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public FormFileGroupService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<FormFileGroupCreate>>> Add(FormFileGroup group)
        {
            ServiceResponse<List<FormFileGroupCreate>> serviceResponse = new ServiceResponse<List<FormFileGroupCreate>>();
            FormFileGroup fileGroup = _mapper.Map<FormFileGroup>(group);
            await _context.FormFileGroups.AddAsync(fileGroup);
            await _context.SaveChangesAsync();

            serviceResponse.data = (_context.Documents.Select(c => _mapper.Map<FormFileGroupCreate>(c))).ToList();

            return serviceResponse;
        }

        public async Task<List<FormFileGroup>> GetListAsync()
        {
            return await _context.FormFileGroups.ToListAsync();
        }

        public void Update(FormFileGroupCreate group)
        {
            _context.Entry(group).State = EntityState.Modified;
        }
    }
}
