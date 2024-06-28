using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSalesStorage.Models
{
    
    public class Sale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid SaleId { get; set; }

        [Required, MaxLength(255)]
        public string ProductName { get; set; }

        [Required, MaxLength(255)]
        public uint Price { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
