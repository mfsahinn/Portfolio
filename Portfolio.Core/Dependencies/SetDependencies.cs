using Microsoft.Extensions.DependencyInjection;
using Portfolio.Business;
using Portfolio.Interface.Abstrack;

namespace Portfolio.Core.Dependencies;

public static class Dependencies
{
      public static void SetDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAboutMe,AboutMeService>();
        //services.AddScoped<UserManager<AppUser>>();
        //services.AddScoped<SignInManager<AppUser>>();
    }
}
