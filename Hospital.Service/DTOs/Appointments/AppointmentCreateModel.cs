using Hospital.Domain.Entities;

namespace Hospital.Service.DTOs.Appointments;

public class AppointmentCreateModel
{
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public DateTime DateTime { get; set; }
}
