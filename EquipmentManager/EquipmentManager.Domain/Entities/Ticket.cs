using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManager.Domain.Entities
{
    public class Ticket
    {
        private List<TicketLine> lineCollection = new List<TicketLine>();

        public void AddItem(Item item)
        {
            TicketLine line = lineCollection.Where(i => i.Item.ItemID == item.ItemID).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new TicketLine { Item = item });
            }
        }

        public void RemoveLine(Item item)
        {
            lineCollection.RemoveAll(l => l.Item.ItemID == item.ItemID);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<TicketLine> Lines
        {
            get { return lineCollection; }
        }
    }



    public class TicketLine
    {
        public Item Item { get; set; }
    }
}
