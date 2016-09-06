using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStore.Domain.Abstract;
using DotaStore.Domain.Entities;

namespace DotaStore.Domain.Concrete
{
    class EFRepository:IRepository
    {
        private DotaShopContext context = new DotaShopContext();

        public IEnumerable<Item> Items => context.Items;

    }
}
