using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Concrete;


namespace EquipmentManager.WebUI.Models
{
    public class ReservationViewModel
    {
        EFItemRepository itemRepo = new EFItemRepository();
        EFMemberRepository memRepo = new EFMemberRepository();

        public Reservation Reservation { get; set; }
        public Item Item { get; set; }
        public Member Member { get; set; }

        public Item GetItemById(int id)
        {
            return (from i in itemRepo.Items
                    where i.ItemID == id
                    select i).FirstOrDefault();
        }

        public Member GetMemberById(int id)
        {
            return (from m in memRepo.Members
                    where m.MemberID == id
                    select m).FirstOrDefault();
        }
    }
}