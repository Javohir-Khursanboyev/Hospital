using Hospital.Domain.Commons;

namespace Hospital.Domain.Entities;

public class Doctor : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Position { get; set; }
}
