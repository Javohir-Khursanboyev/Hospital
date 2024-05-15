using Hospital.Domain.Entities;

namespace Hospital.Service.DTOs.Prescription
{
    public class PrescriptionCreateModel
    {
        public long UserId { get; set; }
        public long DoctorId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
