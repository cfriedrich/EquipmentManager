using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Concrete
{
    public class FakeItemRepository : I_ItemRepository
    {
        IQueryable<Item> items;
        List<Item> fakeitems = new List<Item>();

        public IQueryable<Item> Items
        {
            get { return items; }
        }

        public List<Item> FakeItems
        {
            get { return fakeitems; }
        }

        public void AddItem(Item item)
        {
            fakeitems.Add(item);
            
        }
        public void SaveItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Item DeleteItem(int itemId)
        {
            throw new NotImplementedException();
            
        }

        public Item GetItem(int id)
        {
            return (from i in FakeItems where id == i.ItemID select i).FirstOrDefault<Item>();
        }
    }
}
