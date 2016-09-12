using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> _order = new List<CartLine>();

        public void AddItem(Item item, int quantity)
        {
            var line = _order
                .FirstOrDefault(i => i.Item.ID == item.ID);

            if (line == null)
            {
                _order.Add(new CartLine {Item = item, Quantity = quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Item item)
        {
            _order.RemoveAll(l => l.Item.ID == item.ID);
        }

        public decimal TotalPrice()
        {
            return _order
                .Sum(i => i.Item.Price*i.Quantity);
        }

        public void Clear()
        {
            _order.Clear();
        }

        public IEnumerable<CartLine> GetOrder()
        {
            return _order;
        }
    }
}
