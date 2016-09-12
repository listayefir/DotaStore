using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStore.Domain.Entities
{
    public class CartLine
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
