using DevicesSalesLogic.Interfaces;
using DevicesSalesLogic.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSalesLogic.Extension
{
    public static class CollectionExtension
    {
        public static void AddLogicServices(this IServiceCollection services)
        {

            services.AddSingleton<ISaleRepository, SaleRepository>();
            services.AddSingleton<IClientRepository, ClientRepository>();
        }
    }
}
