using Hospital.Domain.Commons;

namespace Hospital.Domain.Entities;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
}