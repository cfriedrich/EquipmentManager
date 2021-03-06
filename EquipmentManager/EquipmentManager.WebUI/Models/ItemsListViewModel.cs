﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.WebUI.Models
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}