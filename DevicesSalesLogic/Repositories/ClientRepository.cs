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
    public class ClientRepository : IClientRepository
    {
        public Client Create(DataContext context, Client client)
        {
            context.Clients.Add(client);
            return client;
        }

        public async Task<Client> GetByMail(DataContext context, string mail)
        {
            var userDb = await context.Clients.AsNoTracking().Include(m => m.Sales).FirstOrDefaultAsync(x => x.Email == mail);
            return userDb;
        }

        public async Task<Client> GetById(DataContext context, Guid clientId)
        {
            var userDb = await context.Clients.AsNoTracking().Include(m => m.Sales).FirstOrDefaultAsync(x => x.ClientId == clientId);
            return userDb;
        }

    }
}
