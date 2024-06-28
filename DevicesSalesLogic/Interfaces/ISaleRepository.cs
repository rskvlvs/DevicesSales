using DevicesSalesStorage;
using DevicesSalesStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSalesLogic.Interfaces
{
    public interface ISaleRepository
    {
        void Delete(DataContext context, Guid saleID);

        Sale Create(DataContext context, Sale sale);
    }
}
