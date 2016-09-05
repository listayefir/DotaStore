﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaStore.Domain.Entities;
namespace DotaStore.Domain.Abstract
{
    interface IRepository
    {
        IEnumerable<Item> Items { get; }
        IEnumerable<Badge> Badges { get; }
    }
}