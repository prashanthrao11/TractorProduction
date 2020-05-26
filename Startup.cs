using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using TractorProduction.Web.Data;
using TractorProduction.Web.Repositories;
using TractorProduction.Web.Services;

namespace TractorProduction.Web
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
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddDbContext<APIContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("APIContext")));


            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    //options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                });
            services.AddScoped<IDepartmentApproverRepository, DepartmentApproversService>();
            services.AddScoped<IDepartmentRepository, DepartmentService>();
            services.AddScoped<IEmailTemplateRepository, EmailTemplateService>();
            services.AddScoped<ILogDetailsRepository, LogDetailsService>();
            services.AddScoped<IMilestoneDepartmentrepository, MilestonestoneDepartmentService>();
            services.AddScoped<IProductionApprovalRepository, ProductionApprovalsService>();
            services.AddScoped<IProductionFinalApprovalRepository, ProductionFinalApprovalsService>();
            services.AddScoped<IProductionMilestoneDepartmentApprovalRepository, ProductionMilestoneDepartmentApprovalsService>();
            services.AddScoped<IProductionMilestoneRepository, ProductionMilestoneService>();
            services.AddScoped<IProductionRepository, ProductionService>();
            services.AddScoped<IProductionUserApprovalRepository, ProductionUserApprovalsService>();

            services.AddScoped<IProductPhaseRepository, ProductPhasesService>();
            services.AddScoped<IRoleRepository, RoleService>();
            services.AddScoped<IStatusRepository, StatusService>();
            services.AddScoped<IStatusTypeRepository, StatusTypeService>();
            services.AddScoped<IUserRoleRepository, UserRoleService>();

            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<IWorkflowPhaseMilestoneRepository, WorkflowPhaseMilestoneService>();
            services.AddScoped<IWorkflowRepository, WorkflowService>();
            services.AddScoped<IAttachmentRepository, AttachmentService>();

            services.AddCors(options =>
            {
                options.AddPolicy("Testing",
                builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "TractorProduction.Web", Version = "v1" });
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors("Testing");

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //Enable middleware to serve swagger - ui(HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "TractorProduction.Web v1");
            });

            app.UseSpa(spa =>
            {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });


        }
    }
}
