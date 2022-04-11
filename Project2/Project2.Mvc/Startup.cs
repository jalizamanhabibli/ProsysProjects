using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Project2.Core.Entities;
using Project2.Core.Repositories;
using Project2.Core.Services;
using Project2.Core.UniteOfWork;
using Project2.Mvc.Filters;
using Project2.Repository;
using Project2.Repository.Repositories;
using Project2.Repository.UniteOfWork;
using Project2.Service.Mapping;
using Project2.Service.Services;
using Project2.Service.Validators;

namespace Project2.Mvc
{
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
            services.AddControllersWithViews().AddFluentValidation(x =>x.RegisterValidatorsFromAssemblyContaining<LessonDtoValidator>());
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
            services.AddScoped(typeof(NotFountFilter<>));
            services.AddScoped(typeof(ModelStateFilter));
            services.AddScoped<IUniteOfWork,UniteOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IExamService, ExamService>();

            services.AddScoped(typeof(IService<Lesson>),typeof(LessonService));
            services.AddScoped(typeof(IService<Student>), typeof(StudentService));
            services.AddScoped(typeof(IService<Exam>), typeof(ExamService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
