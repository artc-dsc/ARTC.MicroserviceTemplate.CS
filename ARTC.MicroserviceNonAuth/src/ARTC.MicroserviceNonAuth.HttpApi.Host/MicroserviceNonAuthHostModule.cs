using Microsoft.AspNetCore.Cors;
using Microsoft.OpenApi.Models;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using ARTC.MicroserviceNonAuth.EntityFrameworkCore;
using Volo.Abp.EventBus.RabbitMq;

namespace ARTC.MicroserviceNonAuth.HttpApi.Host
{

    [DependsOn(
    typeof(MicroserviceNonAuthHttpApiModule),
    typeof(MicroserviceNonAuthApplicationModule),
    typeof(MicroserviceNonAuthEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpEventBusRabbitMqModule)
    )]
    public class MicroserviceNonAuthHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAbpSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectService API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });

            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(MicroserviceNonAuthApplicationModule).Assembly);
            });

            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.Trim().RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorrelationId();
            app.UseCors();
            app.UseAbpRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectService Service API");
                var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
                options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            });
            app.UseAbpSerilogEnrichers();
            app.UseAuditing();
            app.UseUnitOfWork();
            app.UseConfiguredEndpoints();
        }
    }
}