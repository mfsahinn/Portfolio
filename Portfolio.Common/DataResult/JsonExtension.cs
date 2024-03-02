using Microsoft.Extensions.DependencyInjection;

namespace Portfolio.Common.DataResult;

public static class JsonExtension
{
    public static IMvcBuilder SetPortfolioJsonOptions(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = null;
            });
            return mvcBuilder;
        }
}
