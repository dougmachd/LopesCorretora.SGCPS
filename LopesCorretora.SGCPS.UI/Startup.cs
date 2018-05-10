using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;

namespace LopesCorretora.SGCPS.UI
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
			services.AddIdentity<IdentityUser, IdentityRole>();
			services.AddAuthentication(
					v =>
					{
						v.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
						v.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
					}).AddGoogle(googleOptions =>
					{
						googleOptions.ClientId = "123875578423-q5lhsae46u51fu4a9hoajt431amugnvs.apps.googleusercontent.com";
						googleOptions.ClientSecret = "xs_WnJhn4CQ5sthu1lgbLM0q";
					});

			services.AddMvc();
			services.AddDistributedMemoryCache();
			services.AddSession();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseSession();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Home}/{id?}");
			});
		}
	}
}
