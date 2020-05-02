using System;

namespace JobGrabber.Backend.Models
{
    public class Job
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string CompanyLogo { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string Url { get; set; }
    }
}
