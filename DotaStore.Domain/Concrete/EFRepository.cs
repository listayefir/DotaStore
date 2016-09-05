using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStore.Domain.Abstract;
using DotaStore.Domain.Entities;
using DotaStore.Domain.Entities;

namespace DotaStore.Domain.Concrete
{
    class EFRepository:IRepository
    {
        private DotaShop context = new DotaShop();

        public IEnumerable<Item> Items => context.Items;

        public IEnumerable<Badge> Badges => context.Badges;
    }
}
