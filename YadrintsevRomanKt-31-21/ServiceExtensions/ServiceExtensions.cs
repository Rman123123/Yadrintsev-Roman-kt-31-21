using YadrintsevRomanKt_31_21.Interfaces.DepartmentInterfaces;
using YadrintsevRomanKt_31_21.Interfaces.TeacherInterfaces;


namespace YadrintsevRomanKt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITeacherService, TeacherService>();

            return services;
        }
    }
}
