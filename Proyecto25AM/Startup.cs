
using Microsoft.EntityFrameworkCore;
using David_Stephen.Context;
using David_Stephen.Services.Iservices;
using David_Stephen.Services.IServices;
using David_Stephen.Services.Services;

namespace David_Stephen
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //add connection bd
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Inyeccion de dependencias
            services.AddTransient<IUsuarioServices, UsuarioServices>();
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IPuestoServices, PuestoServices>();
            services.AddTransient<IFacturaServices, FacturaServices>();
            services.AddTransient<IEmpleadoServices, EmpleadoServices>();
            services.AddTransient<IDepartamentoServices, DepartamentoServices>();
            services.AddTransient<IClienteServices, ClienteServices>();

        }
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) 
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
