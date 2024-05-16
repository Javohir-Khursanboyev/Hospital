using Hospital.Domain.Commons;

namespace Hospital.Domain.Entities;

public class PrescriptionItem : Auditable
{
    public long PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }
    public string MedicineName { get; set; }
    public string MedicineUsage { get; set; }
    public int Days { get; set; }
}