using System;
using System.Collections.Generic;

namespace AutoAppo_JosueVa.Models
{
    public class AppointmentStatus
    {
        public AppointmentStatus()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int AppoStatusId { get; set; }
        public string AppoStatusDescription { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
