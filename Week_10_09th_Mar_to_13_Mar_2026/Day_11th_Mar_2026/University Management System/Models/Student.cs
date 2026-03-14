using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystem.Models
{
	public class Student
	{
		public int StudentId { get; set; }

		[Required]
		public string FullName { get; set; }

		[Required]
		public string Email { get; set; }

		public DateTime EnrollmentDate { get; set; }

		public ICollection<Enrollment>? Enrollments { get; set; }
	}
}