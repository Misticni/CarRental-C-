using Car_Rental.Abstraction;
using Car_Rental.Repository.Implementation;
using CarRental.DataAcess;
using CarRental.DataAcess.Repository.Implementation;
using CarRental.Services.Abstraction;
using CarRental.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Helper
{
    public static class DependencyInjectionHelper
    {

        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IClientService, ClientService>();

        }
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();


        }
    }
}
