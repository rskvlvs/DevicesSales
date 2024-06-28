using DevicesSalesLogic.Interfaces;
using DevicesSalesStorage;
using DevicesSalesStorage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSalesLogic.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public Sale Create(DataContext context, Sale sale)
        {
            context.Sales.Add(sale);
            return sale;
        }
        public void Delete(DataContext context, Guid saleID)
        {
            var salesDb = context.Sales.FirstOrDefault(x => x.SaleId == saleID)
               ?? throw new Exception($"Продажа с идентификатором {saleID} не найдена");

            context.Sales.Remove(salesDb);
        }
    }
}
