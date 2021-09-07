using Microsoft.EntityFrameworkCore;
using PD.DataEFC.Context;
using PD.DataEFC.Repository;
using PD.DataCore.Interfaces;

namespace PD.WebApiCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "PD.WebApiCore", Version = "v1" });
        });

        var config = Configuration.GetConnectionString("defaultLocal");
        services.AddDbContext<PhoneDictionaryContext>(options =>
        {
            options.UseSqlServer(config);
        });
        services.AddScoped<IPhoneDictionary, PhoneDictionaryRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PD.WebApiCore v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
