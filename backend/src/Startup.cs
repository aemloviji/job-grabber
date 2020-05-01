using JobGrabber.Backend.Abstraction;
using JobGrabber.Backend.Options;
using JobGrabber.Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobGrabber.Backend
{
    internal class Startup
    {
        private const string ConfigurationSectionRedis = "Redis";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IRedisClient, RedisClient>();
            services.AddSingleton<IJobService, JobService>();

            services.Configure<RedisOptions>(Configuration.GetSection(ConfigurationSectionRedis));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRedisClient redisClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            redisClient.Connect();
        }
    }
}
