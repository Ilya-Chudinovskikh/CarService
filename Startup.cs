using CarService.Db;
using CarService.Repositories;
using CarService.Services;
using Microsoft.EntityFrameworkCore;

namespace CarService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CarServiceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICarServiceBusinessLogic, CarServiceBusinessLogic>();
            services.AddScoped<ICarServiceRepositories, CarServiceRepositories>();
        }
    }
}
