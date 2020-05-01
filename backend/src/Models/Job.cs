using System;

namespace JobGrabber.Backend.Models
{
    public class Job
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }
    }
}
