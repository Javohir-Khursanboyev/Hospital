using Hospital.Domain.Entities;

namespace Hospital.Service.DTOs.PrescriptionItems
{
    public class PrescriptionItemViewModel
    {
        public long Id { get; set; }
        public long PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string MedicineName { get; set; }
        public string MedicineUsage { get; }
        public int Days { get; set; }
    }
}
