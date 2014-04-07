using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.WebUI.Models
{
    public class TicketIndexViewModel
    {
        public Ticket Ticket { get; set; }
        public string ReturnUrl { get; set; }
    }
}