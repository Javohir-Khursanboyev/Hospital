namespace Hospital.Service.DTOs.PrescriptionItems
{
    public class PrescriptionItemUpdateModel
    {
        public long PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineUsage { get; set; }
        public int Days { get; set; }
    }
}
}
