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
    public class ItemController : Controller
    {
     
        private EFItemRepository EFitemRepo = new EFItemRepository();
        private I_ItemRepository itemRepo;

        public int PageSize = 3;

        public ItemController(EFItemRepository itemRepository)
        {
            this.EFitemRepo = itemRepository;
        }

        public ItemController(I_ItemRepository itemRepository)
        {
            this.itemRepo = itemRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        //public ViewResult GetItemsByCategory(string category, int page = 1)
        //{
        //    ItemsListViewModel viewModel = new ItemsListViewModel 
        //    { 
        //        Items = EFitemRepo.Items.Where(i => category == null || i.Category == category)
        //        .OrderBy(i => i.ItemID)
        //        .Skip(( page - 1) * PageSize)
        //        .Take(PageSize),
        //        PagingInfo = new PagingInfo 
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            TotalItems = EFitemRepo.Items.Count()
        //        },

                
        //        CurrentCategory = category
        //    };
        //    return View(viewModel);

        //}

        public ViewResult ShowItem(Item item)
        {
            return View(item);
        }

        //public RedirectToRouteResult CheckInItem(int itemId, string returnUrl)
        //{
        //    Item item = itemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);

        //    if (item != null)
        //    {
        //        EFitemRepo.CheckIn(item);
        //    }
        //    return RedirectToAction("ListItems", new { returnUrl });
        //}
            
        public ViewResult ListAvailableItems (int page = 1)
        {
            ItemsListViewModel model = new ItemsListViewModel
            {
                Items = EFitemRepo.Items.Where(i => i.CheckedOut == false)
                .OrderBy(i => i.ItemID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = EFitemRepo.Items.Count()
                }
            };
            return View(model);
        }

        public ViewResult AvailableItems(int page = 1)
        {
            ItemsListViewModel model = new ItemsListViewModel
            {
                Items = EFitemRepo.Items.Where(i => i.CheckedOut == false)
                .OrderBy(i => i.ItemID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = EFitemRepo.Items.Count()
                }
            };
            return View(model);
        }

        public ViewResult BrowseAvailableItems (int page = 1)
        {
            ItemsListViewModel model = new ItemsListViewModel
            {
                Items = EFitemRepo.Items.Where(i => i.CheckedOut == false)
                .OrderBy(i => i.ItemID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = EFitemRepo.Items.Count()
                }
            };
            return View(model);
            }

        //public ViewResult ListItems()
        //{
        //    return View(EFitemRepo.Items);
        //}

        public ViewResult DeleteItem(int itemId)
        {
            Item item = EFitemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);
            return View(item);
        }

        public ViewResult EditItem(int itemId)
        {
            Item item = EFitemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditItem(Item item, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    item.ImageMimeType = image.ContentType;
                    item.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(item.ImageData, 0, image.ContentLength);
                }
                itemRepo.SaveItem(item);
                TempData["message"] = string.Format("{0} has been saved", item.Name);
                return RedirectToAction("SaveItem", "Item", item);
            }
            else
            {
                TempData["mesage"] = string.Format("{0} has not been saved", item.Name);
                return RedirectToAction("ListItems", "Item", item);
            }
        }

        public ViewResult SaveItem(Item item)
        {
            return View("SaveItem", item);
        }

        public ViewResult CreateItem()
        {
            return View("EditItem", new Item());
        }

        public ActionResult Delete(int itemId)
        {
            Item deletedItem = EFitemRepo.DeleteItem(itemId);
            if (deletedItem != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedItem.Name);
            }
            return RedirectToAction("SaveItem", "Item", deletedItem);
        }

        public FileContentResult GetImage(int itemId)
        {
            Item item = itemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);
            if (item != null)
            {
                return File(item.ImageData, item.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ViewResult ListItems(int page = 1)
        {
            ItemsListViewModel model = new ItemsListViewModel
           {
                Items = EFitemRepo.Items
                .OrderBy(i => i.ItemID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = EFitemRepo.Items.Count()
                    }
            };
            return View(model);
        }


    }
}
