using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.WebUI.Models;


namespace EquipmentManager.WebUI.Controllers
{
    public class TicketController : Controller
    {

        private I_ItemRepository itemRepo;

        public TicketController(I_ItemRepository repo)
        {
            itemRepo = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new TicketIndexViewModel
            {
                Ticket = GetTicket(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToTicket(int itemId, string returnUrl)
        {
            Item item = itemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);

            if (item != null)
            {
                GetTicket().AddItem(item);
                item.CheckedOut = true;
                
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromTicket(int itemId, string returnUrl)
        {
            Item item = itemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);

            if (item != null)
            {
                GetTicket().RemoveLine(item);
                item.CheckedOut = false;
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Ticket GetTicket()
        {
            Ticket ticket = (Ticket)Session["Ticket"];
            if (ticket == null)
            {
                ticket = new Ticket();
                Session["Ticket"] = ticket;
            }
            return ticket;
        }


    }
}
