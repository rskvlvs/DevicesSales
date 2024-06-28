using DevicesSalesStorage;
using DevicesSalesStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSalesLogic.Interfaces
{
    public interface IClientRepository
    {
        Client Create(DataContext context, Client client);

        Task<Client> GetByMail(DataContext context, string mail);

        Task<Client> GetById(DataContext context, Guid clientId);
    }
}
