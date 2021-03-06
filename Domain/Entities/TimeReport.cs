using System;
using System.Collections.Generic;

namespace Tymish.Domain.Entities
{
    public class TimeReport
    {
        public Guid Id { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime Paid { get; set; }
        public IList<TimeEntry>? TimeEntries { get; set; }
        public virtual Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }

    public class TimeEntry
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Comments { get; set; }

        public TimeEntry()
        {
            Comments = string.Empty;
        }
    }
}