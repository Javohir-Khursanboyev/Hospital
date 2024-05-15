namespace Hospital.Service.DTOs.Appointments;

public class AppointmentUpdateModel
{
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public DateTime DateTime { get; set; }
}
