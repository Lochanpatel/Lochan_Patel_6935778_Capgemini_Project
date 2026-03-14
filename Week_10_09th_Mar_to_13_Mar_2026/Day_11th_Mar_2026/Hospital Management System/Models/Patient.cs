using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Models
{
	public partial class Patient
	{
		public int PatientId { get; set; }

		public string? FullName { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string? ContactNumber { get; set; }

		public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}