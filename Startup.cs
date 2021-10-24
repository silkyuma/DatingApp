using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        

        public void ConfigureServices(IServiceCollection services)
        {
             services.AddControllersWithViews();
             services.AddDbContext<DataContext>(options=>{
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });
             
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints=>{endpoints.MapControllers();});
        }
    }
}