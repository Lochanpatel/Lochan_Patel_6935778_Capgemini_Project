using System.Collections.Generic;

namespace Hospital_Management_System.Models
{
	public partial class Doctor
	{
		public int DoctorId { get; set; }

		public string? Name { get; set; }

		public string? Specialization { get; set; }

		public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}