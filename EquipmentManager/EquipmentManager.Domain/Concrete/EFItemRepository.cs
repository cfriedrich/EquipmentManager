using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Concrete
{
    public class EFItemRepository : I_ItemRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Item> Items
        {
            get { return context.Items; }
        }

        //public void AddItem(Entities.Item item)
        //{
        //    context.Items.Add(item);
        //    context.SaveChanges();
        //}

        public void SaveItem(Item item)
        {
            if (item.ItemID == 0)
            {
                context.Items.Add(item);
            }
            else
            {
                Item dbEntry = context.Items.Find(item.ItemID);
                if (dbEntry != null)
                {
                    dbEntry.Name = item.Name;
                    dbEntry.Description = item.Description;
                    dbEntry.Category = item.Category;
                    dbEntry.Operational = item.Operational;
                    dbEntry.CheckedOut = item.CheckedOut;
                    dbEntry.ImageData = item.ImageData;
                    dbEntry.ImageMimeType = item.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Item DeleteItem(int itemID)
        {
            Item dbEntry = context.Items.Find(itemID);
            if (dbEntry != null)
            {
                context.Items.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void CheckOut(Entities.Item item)
        {
            if (item.CheckedOut == false)
            {
                item.CheckedOut = true;
                context.SaveChanges();
            }
            else
                context.SaveChanges();
        }

        public void CheckIn(Entities.Item item)
        {
            if (item.CheckedOut == true)
            {
                item.CheckedOut = false;
                context.SaveChanges();
            }
            else
                context.SaveChanges();
        }

        public Item GetItem(int id)
        {
            return (from i in Items where id == i.ItemID select i).FirstOrDefault<Item>();
        }
    }
}
