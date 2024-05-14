using Hospital.Domain.Entities;

namespace Hospital.Service.DTOs.Prescription
{
    public class PrescriptionUpdateModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
    }
}
