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
    public class ReservationController : Controller
    {

        private EFReservationRepository resRepo = new EFReservationRepository();
        private EFItemRepository itemRepo = new EFItemRepository();
        private EFMemberRepository memRepo = new EFMemberRepository();

        private int PageSize = 5;

        public ReservationController(EFReservationRepository reservationRepository)
        {
            this.resRepo = reservationRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ListReservations(int page = 1)
        {
            ReservationsListViewModel model = new ReservationsListViewModel
            {
                Reservations = resRepo.Reservations.OrderBy(i => i.ItemID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = resRepo.Reservations.Count()
                }
            };
            return View(model);
        }

        public Item GetItemById(int itemId)
        {
            Item item = itemRepo.Items.FirstOrDefault(i => i.ItemID == itemId);

            return item;
        }

        public Reservation GetResById(int resId)
        {
            Reservation reservation = resRepo.Reservations.FirstOrDefault(r => r.ReservationID == resId);

            return reservation;
        }

        public ViewResult CreateReservation()
        {
            return View("EditReservation", new Reservation());
        }

        [HttpPost]
        public ViewResult CreateReservation(Item item)
        {
            Member member = new Member();
            member = (Member)Session["member"];
            Item thisItem = itemRepo.GetItem(item.ItemID);
            itemRepo.CheckOut(thisItem);
            Reservation reservation = new Reservation { ItemID = item.ItemID, MemberID = member.MemberID, StartDate = DateTime.Now, DueDate = DateTime.Today.AddDays(14) };
            return View("CreateReservation", reservation);
        }

        public ViewResult EditReservation(int reservationId)
        {
            Reservation reservation = resRepo.Reservations.FirstOrDefault(r => r.ReservationID == reservationId);
            return View(reservation);
        }

        [HttpPost]
        public ActionResult EditReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                resRepo.SaveReservation(reservation);
                TempData["message"] = string.Format("{0} has been saved", reservation.ReservationID);
                return RedirectToAction("SaveReservation", "Reservation", reservation);
            }
            else
            {
                return View(reservation);
            }
        }

        public ViewResult ShowReservation(ReservationViewModel res)
        {
            return View(res);
        }

        public ViewResult ViewReservationById(int resId)
        {
            Reservation reservation = resRepo.Reservations.FirstOrDefault(r => r.ReservationID == resId);
            return View(reservation);
        }

        public ViewResult SaveReservation(Reservation reservation)
        {
            return View("SaveReservation", reservation);
        }


        public ViewResult ConfirmReservation(Reservation reservation)
        {
            resRepo.SaveReservation(reservation);
            return View("ConfirmReservation", reservation);
        }

        public ViewResult DeleteReservation(int reservationId, Reservation reservation)
        {
            reservation = resRepo.Reservations.FirstOrDefault(r => r.ReservationID == reservationId);
            return View(reservation);
        }

        public ActionResult Delete(int reservationId)
        {
            Reservation deletedReservation = resRepo.DeleteReservation(reservationId);
            if (deletedReservation != null)
            {
                itemRepo.CheckIn(itemRepo.Items.FirstOrDefault(i => i.ItemID == deletedReservation.ItemID));
                TempData["message"] = string.Format("{0} was deleted", deletedReservation.ReservationID);
            }
            return RedirectToAction("ConfirmDelete", "Reservation", deletedReservation);
        }

        public ActionResult ConfirmDelete(Reservation reservation)
        {
            return View();
        }

    }
}
