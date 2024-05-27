using Hospital.Data.Repositories;
using Hospital.Data.Repositories.Appointments;
using Hospital.Data.Repositories.Doctors;
using Hospital.Service.Services.Appointments;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Users;

namespace Hospital.WebApi.Extensions;

public static class ServicesExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IAppiontmentService, AppiontmentService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>(); 
        services.AddScoped<IAppointmentRepository, AppoinmentRepository>();
    }
}