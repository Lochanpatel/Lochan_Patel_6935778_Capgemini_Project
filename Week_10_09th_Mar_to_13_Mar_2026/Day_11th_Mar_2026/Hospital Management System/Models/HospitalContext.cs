using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Models
{
	public partial class HospitalContext : DbContext
	{
		public HospitalContext()
		{
		}

		public HospitalContext(DbContextOptions<HospitalContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Patient> Patients { get; set; }

		public virtual DbSet<Doctor> Doctors { get; set; }

		public virtual DbSet<Appointment> Appointments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Patient>(entity =>
			{
				entity.HasKey(e => e.PatientId);

				entity.Property(e => e.FullName)
					.HasMaxLength(100);

				entity.Property(e => e.ContactNumber)
					.HasMaxLength(20);
			});

			modelBuilder.Entity<Doctor>(entity =>
			{
				entity.HasKey(e => e.DoctorId);

				entity.Property(e => e.Name)
					.HasMaxLength(100);

				entity.Property(e => e.Specialization)
					.HasMaxLength(100);
			});

			modelBuilder.Entity<Appointment>(entity =>
			{
				entity.HasKey(e => e.AppointmentId);

				entity.HasOne(d => d.Patient)
					.WithMany(p => p.Appointments)
					.HasForeignKey(d => d.PatientId);

				entity.HasOne(d => d.Doctor)
					.WithMany(p => p.Appointments)
					.HasForeignKey(d => d.DoctorId);
			});
		}
	}
}