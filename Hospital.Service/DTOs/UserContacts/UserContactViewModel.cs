using Hospital.Domain.Entities;

namespace Hospital.Service.DTOs.UserContacts
{
    public class UserContactViewModel
    {
        public long Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public User User { get; set; }
    }
}
