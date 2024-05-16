using Hospital.Service.DTOs.Prescription;

namespace Hospital.Service.DTOs.PrescriptionItems
{
    public class PrescriptionItemViewModel
    {
        public long Id { get; set; }
        public PrescriptionViewModel Prescription { get; set; }
        public string MedicineName { get; set; }
        public string MedicineUsage { get; }
        public int Days { get; set; }
    }
}
}
