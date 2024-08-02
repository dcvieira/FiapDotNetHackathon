using Application.Common.Interfaces;
using Application.Doctor.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Doctor.Queries;


public class ListDoctorsQuery : IRequest<List<DoctorDto>>
{
}

public class ListDoctorsQueryHandler : IRequestHandler<ListDoctorsQuery, List<DoctorDto>>
{
    private readonly IApplicationDbContext _context;

    public ListDoctorsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DoctorDto>> Handle(ListDoctorsQuery request, CancellationToken cancellationToken)
    {
  
        return await _context.Doctors.Select(d => new DoctorDto(d.Name, d.CRM)).ToListAsync();
    }
}