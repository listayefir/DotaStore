using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotaStore.Domain.Entities;

namespace DotaStore.UI.Models
{
    public class ItemsViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}