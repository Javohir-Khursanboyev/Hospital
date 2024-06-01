using Hospital.Data.Repositories;
using Hospital.Data.Repositories.Appointments;
using Hospital.Data.Repositories.Assets;
using Hospital.Data.Repositories.Doctors;
using Hospital.Data.Repositories.PrescriptionItems;
using Hospital.Data.Repositories.Prescriptions;
using Hospital.Service.Helpers;
using Hospital.Service.Services.Appointments;
using Hospital.Service.Services.Assets;
using Hospital.Service.Services.Doctors;
using Hospital.Service.Services.PrescriptionItems;
using Hospital.Service.Services.Prescriptions;
using Hospital.Service.Users;
using Hospital.WebApi.Middlewares;

namespace Hospital.WebApi.Extensions;

public static class ServicesExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IAppiontmentService, AppiontmentService>();
        services.AddScoped<IPrescriptionService, PrescriptionService>();
        services.AddScoped<IPrescriptionItemService, PrescriptionItemService>();
        services.AddScoped<IAssetService, AssetService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>(); 
        services.AddScoped<IAppointmentRepository, AppoinmentRepository>();
        services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
        services.AddScoped<IPrescriptionItemRepo, PrescriptionItemRepo>();
        services.AddScoped<IAssetRepository, AssetRepository>();

    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        FilePathHelper.WwwrootPath = Path.GetFullPath("wwwroot");

        services.AddExceptionHandler<NotFoundExceptionMiddleware>();
        services.AddExceptionHandler<AlreadyExistExceptionMiddleware>();
        services.AddExceptionHandler<CustomExceptionMiddleware>();
        services.AddExceptionHandler<InternalServerExceptionMiddleware>();
    }
}