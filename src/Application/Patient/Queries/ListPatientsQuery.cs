using Application.Common.Interfaces;
using Application.Patient.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Patient.Queries;



public class ListPatientsQuery : IRequest<List<PatientDto>>
{
}

public class ListPatientsQueryHandler : IRequestHandler<ListPatientsQuery, List<PatientDto>>
{
    private readonly IApplicationDbContext _context;

    public ListPatientsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<PatientDto>> Handle(ListPatientsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Patients.Select(p => new PatientDto(p.Name, p.CPF)).ToListAsync();
    }
}