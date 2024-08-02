using Application.AvailableSchedule.Dtos;
using Application.Common.Interfaces;
using Application.Doctor.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AvailableSchedule.Queries;
public class ListAvailableSchedulesQuery : IRequest<List<AvailableScheduleDto>>
{
}

public class ListAvailableSchedulesQueryHandler : IRequestHandler<ListAvailableSchedulesQuery, List<AvailableScheduleDto>>
{
    private readonly IApplicationDbContext _context;

    public ListAvailableSchedulesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<AvailableScheduleDto>> Handle(ListAvailableSchedulesQuery request, CancellationToken cancellationToken)
    {
        var schedules = await _context.AvailableSchedules
            .Select(s => new AvailableScheduleDto(
                                   s.Id,
                                   s.AvailableDateTime,
                                   s.IsAvailable,
                                   new DoctorDto(s.Doctor.Name, s.Doctor.CPF.Value, s.Doctor.CRM, s.Doctor.Email)                                                          ))
                     .AsNoTracking()
                     .ToListAsync(cancellationToken);

        return schedules;
    }
}

