using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Entities;
using Ninject;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.WebUI.Models;

namespace EquipmentManager.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private EFItemRepository itemRepo = new EFItemRepository();
        private EFMemberRepository memRepo = new EFMemberRepository();
        private EFReservationRepository resRepo = new EFReservationRepository();

        public int PageSize = 3;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MemberIndex()
        {
            return View();
        }

        //public ViewResult ListItems()
        //{
        //    return View(itemRepo.Items);
        //}

        public ViewResult ShowItem(int id)
        {
            Item item = itemRepo.GetItem(id);
            return View(id);
        }

        [HttpGet]
        public ViewResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddItem(Item itemData)
        {
            return View("ShowItem", itemData);
        }

        public ViewResult ListMembers()
        {
            return View(memRepo.Members);
        }

        public ViewResult ListReservations()
        {
            return View(resRepo.Reservations);
        }

        public ViewResult ListItems(string category, int page = 1)
        {
            ItemsListViewModel model = new ItemsListViewModel
             {
                 Items = itemRepo.Items
                 .Where(i => category == null || i.Category == category)
                 .OrderBy(i => i.ItemID)
                 .Skip((page - 1) * PageSize)
                 .Take(PageSize),
                 PagingInfo = new PagingInfo
                     {
                         CurrentPage = page,
                         ItemsPerPage = PageSize,
                         TotalItems = itemRepo.Items.Count()
                     },
                     CurrentCategory = category
             };
            return View(model);
        }


    }
}
