using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DevicesSalesStorage.Models
{
    [Index(nameof(Email))]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ClientId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Surname { get; set; }

        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }

        [InverseProperty(nameof(Sale.Client))]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
