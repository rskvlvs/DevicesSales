using Microsoft.AspNetCore.Identity;
using DevicesSalesLogic.Extension;
using DevicesSales.Features.Interfaces;
using DevicesSales.Features.Managers;
namespace DevicesSales.Extensions
{
    public static class CollectionExtension
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddLogicServices();

            services.AddTransient<ISaleManager, SaleManager>();

            services.AddTransient<IClientManager, ClientManager>();

        }
    }
}
