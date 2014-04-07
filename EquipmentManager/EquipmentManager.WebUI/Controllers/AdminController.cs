using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.WebUI.Controllers;
using System.Web.Mvc;

namespace EquipmentManager.WebUI.Controllers
{

    public class AdminController : Controller
    {
        private I_ItemRepository itemRepo;

        private I_MemberRepository memRepo;

        private I_ReservationRepository resRepo;

        public AdminController(I_ItemRepository repo)
        {
            itemRepo = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Edit(int itemId)
        {
            Item item = itemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                itemRepo.SaveItem(item);
                TempData["message"] = string.Format("{0} has been saved", item.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // There is something wrong with the data values

                return View(item);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Item());
        }

        [HttpPost]
        public ActionResult Delete(int itemId)
        {
            Item deletedItem = itemRepo.DeleteItem(itemId);
            if (deletedItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedItem.Name);
            }
            return RedirectToAction("Index");
        }

        

    }
}