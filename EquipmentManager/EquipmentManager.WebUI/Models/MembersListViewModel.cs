using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.WebUI.Models
{
    public class MembersListViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}