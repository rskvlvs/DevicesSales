using DevicesSalesStorage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSalesStorage
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Client> Clients{ get; set; }
    }
}
