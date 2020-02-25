using System;
using System.Threading;
using System.Threading.Tasks;
using Tymish.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using Tymish.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Tymish.Application.Exceptions;

namespace Tymish.Application.TimeReports.Commands
{
    public class CreateTimeReportCommand : IRequest<TimeReport>
    {
        public int EmployeeNumber { get; set; }
        public IList<TimeEntry> TimeEntries { get; set; }
    }

    public class CreateTimeReportHandler : IRequestHandler<CreateTimeReportCommand, TimeReport>
    {
        private readonly ITymishDbContext _context;

        public CreateTimeReportHandler(ITymishDbContext context) {
            _context = context;
        }
        public async Task<TimeReport> Handle(CreateTimeReportCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context
                .Set<Employee>().SingleOrDefaultAsync(
                    e => e.EmployeeNumber == request.EmployeeNumber,
                    cancellationToken
                );
            
            if (employee == default(Employee))
            {
                throw new NotFoundException(nameof(Employee), request.EmployeeNumber);
            }

            var entity = new TimeReport
            {
                Id = new Guid(),
                Issued = default(DateTime),
                Submitted = default(DateTime),
                Paid = default(DateTime),
                TimeEntries = request.TimeEntries,
                Employee = employee
            };

            _context.Set<TimeReport>().Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            
            return entity;
        }
    }
}