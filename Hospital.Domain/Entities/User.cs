using Hospital.Domain.Commons;

namespace Hospital.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
    public UserContact Contact { get; set; }
}