using Hospital.Domain.Entities;
using Hospital.Service.DTOs.Appointments;
using Hospital.Service.DTOs.Doctors;
using Hospital.Service.DTOs.Prescription;
using Hospital.Service.DTOs.PrescriptionItems;
using Hospital.Service.DTOs.Users;

namespace Hospital.Service.Mappers;

public static class Mapper
{
    #region User Mapper
    public static User Map(UserCreateModel model)
    {
        return new User
        {
            Email = model.Email,
            Password = model.Password,
            LastName = model.LastName,
            FirstName = model.FirstName,
        };
    }

    public static UserViewModel Map(User model)
    {
        return new UserViewModel
        {
            Id = model.Id,
            Email = model.Email,
            LastName = model.LastName,
            FirstName = model.FirstName,
        };
    }

    public static User Map(UserUpdateModel model)
    {
        return new User
        {
            Email = model.Email,
            LastName = model.LastName,
            FirstName = model.FirstName,
        };
    }

    public static IEnumerable<UserViewModel> Map(IEnumerable<User> models)
    {
        return models.Select(user => new UserViewModel
        {
            Id = user.Id,
            Email = user.Email,
            LastName = user.LastName,
            FirstName = user.FirstName,
        });
    }
    #endregion

    #region Doctor Mapper
    public static Doctor Map(DoctorCreateModel model)
    {
        return new Doctor
        {
            Email = model.Email,
            Password = model.Password,
            Position = model.Position,
            LastName = model.LastName,
            FirstName = model.FirstName,
        };
    }

    public static DoctorViewModel Map(Doctor model)
    {
        return new DoctorViewModel
        {
            Email = model.Email,
            Position = model.Position,
            LastName = model.LastName,
            FirstName = model.FirstName,
        };
    }

    public static Doctor Map(DoctorUpdateModel model)
    {
        return new Doctor
        {
            Email = model.Email,
            Position = model.Position,
            LastName = model.LastName,
            FirstName = model.FirstName,
        };
    }

    public static IEnumerable<DoctorViewModel> Map(IEnumerable<Doctor> models)
    {
        return models.Select(model => new DoctorViewModel
        {
            Id = model.Id,
            Email = model.Email,
            Position = model.Position,
            LastName = model.LastName,
            FirstName = model.FirstName,
        });
    }
    #endregion

    #region Appointment Mapper
    public static Appointment Map(AppointmentCreateModel model)
    {
        return new Appointment
        {
            UserId = model.UserId,
            DoctorId = model.DoctorId,
            DateTime = model.DateTime,
        };
    }

    public static AppointmentViewModel Map(Appointment model)
    {
        return new AppointmentViewModel
        {
            Id = model.Id,
            User = Map(model.User),
            DateTime = model.DateTime,
            Doctor = Map(model.Doctor),
        };
    }

    public static Appointment Map(AppointmentUpdateModel model)
    {
        return new Appointment
        {
            UserId = model.UserId,
            DoctorId = model.DoctorId,
            DateTime = model.DateTime,
        };
    }

    public static IEnumerable<AppointmentViewModel> Map(IEnumerable<Appointment> models)
    {
        return models.Select(model => new AppointmentViewModel
        {
            Id = model.Id,
            User = Map(model.User),
            DateTime = model.DateTime,
            Doctor = Map(model.Doctor),
        });
    }
    #endregion

    #region Prescription Mapper
    public static Prescription Map(PrescriptionCreateModel model)
    {
        return new Prescription
        {
            UserId = model.UserId,
            DoctorId = model.DoctorId,
            DateTime = model.DateTime,
        };
    }

    public static PrescriptionViewModel Map(Prescription model)
    {
        return new PrescriptionViewModel
        {
            Id = model.Id,
            User = Map(model.User),
            DateTime = model.DateTime,
            Doctor = Map(model.Doctor)
        };
    }

    public static Prescription Map(PrescriptionUpdateModel model)
    {
        return new Prescription
        {
            UserId = model.UserId,
            DoctorId = model.DoctorId,
            DateTime = model.DateTime,
        };
    }

    public static IEnumerable<PrescriptionViewModel> Map(IEnumerable<Prescription> models)
    {
        return models.Select(model => new PrescriptionViewModel
        {
            Id = model.Id,
            User = Map(model.User),
            DateTime = model.DateTime,
            Doctor = Map(model.Doctor),
        });
    }
    #endregion

    #region Prescription Item Mapper
    public static PrescriptionItem Map(PrescriptionItemCreateModel model)
    {
        return new PrescriptionItem
        {
            Days = model.Days,
            MedicineName = model.MedicineName,
            MedicineUsage = model.MedicineUsage,
            PrescriptionId = model.PrescriptionId,
        };
    }

    public static PrescriptionItemViewModel Map(PrescriptionItem model)
    {
        return new PrescriptionItemViewModel
        {
            Id = model.Id,
            Days = model.Days,
            MedicineName = model.MedicineName,
            MedicineUsage = model.MedicineUsage,
            Prescription = Map(model.Prescription),
        };
    }

    public static PrescriptionItem Map(PrescriptionItemUpdateModel model)
    {
        return new PrescriptionItem
        {
            Days = model.Days,
            MedicineName = model.MedicineName,
            MedicineUsage = model.MedicineUsage,
            PrescriptionId = model.PrescriptionId,
        };
    }

    public static IEnumerable<PrescriptionItemViewModel> Map(IEnumerable<PrescriptionItem> models)
    {
        return models.Select(model => new PrescriptionItemViewModel
        {
            Id = model.Id,
            Days = model.Days,
            MedicineName = model.MedicineName,
            MedicineUsage = model.MedicineUsage,
            Prescription = Map(model.Prescription)
        });
    }
    #endregion
}