using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Common.Dependency
{
    public static class Dependencies
    {
        public static void SetDependencies(this IServiceCollection services)
        {
            //services.AddScoped<UserManager<AppUser>>();
            //services.AddScoped<SignInManager<AppUser>>();
        }
    }
}
