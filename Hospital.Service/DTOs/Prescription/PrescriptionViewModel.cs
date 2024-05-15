using Hospital.Service.DTOs.Doctors;
using Hospital.Service.DTOs.Users;

namespace Hospital.Service.DTOs.Prescription
{
    public class PrescriptionViewModel
    {
        public long Id { get; set; }
        public UserViewModel User { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public DateTime DateTime { get; set; }
    }
}
