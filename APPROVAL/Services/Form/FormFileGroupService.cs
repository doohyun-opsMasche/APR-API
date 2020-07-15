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
        private readonly MariaContext _context;

        public FormFileGroupService(IMapper mapper, MariaContext context)
        {
            _mapper = mapper;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ServiceResponse<List<FormFileGroupRead>>> Add(FormFileGroupCreate group)
        {
            ServiceResponse<List<FormFileGroupRead>> serviceResponse = new ServiceResponse<List<FormFileGroupRead>>();
            FormFileGroup fileGroup = _mapper.Map<FormFileGroup>(group);
            await _context.FormFileGroups.AddAsync(fileGroup);
            await _context.SaveChangesAsync();

            serviceResponse.data = (_context.Documents.Select(c => _mapper.Map<FormFileGroupRead>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FormFileGroupRead>>> GetListAsync()
        {
            ServiceResponse<List<FormFileGroupRead>> serviceResponse = new ServiceResponse<List<FormFileGroupRead>>();
            List<FormFileGroup> fileGroups = await _context.FormFileGroups.ToListAsync();
            serviceResponse.data = (fileGroups.Select(c => _mapper.Map<FormFileGroupRead>(c))).ToList();

            return serviceResponse;
        }

        public void Update(FormFileGroupCreate group)
        {
            _context.Entry(group).State = EntityState.Modified;
        }
    }
}
