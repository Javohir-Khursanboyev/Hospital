using Hospital.Domain.Commons;

namespace Hospital.Domain.Entities;

public class UserContact : Auditable
{
    public string Phone { get; set; }
    public string Address { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
