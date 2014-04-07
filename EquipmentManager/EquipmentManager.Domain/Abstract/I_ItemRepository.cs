using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Abstract
{
    public interface I_ItemRepository
    {
        IQueryable<Item> Items { get; }
        void SaveItem(Item item);
        Item DeleteItem(int ItemID);
        Item GetItem(int id);
    }
}
