using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.WebUI.Models;
using System.Web.Security;

namespace EquipmentManager.WebUI.Controllers
{
    public class MemberController : Controller
    {
    
        private  EFMemberRepository memRepo = new EFMemberRepository();

        // Declared constants for member info

        private const String MEMBERNAME = "membername";
        private const String MEMBER = "member";

        private int PageSize = 7;

        public MemberController(EFMemberRepository memberRepository)
        {
            this.memRepo = memberRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        //public ViewResult ListMembers()
        //{
        //    return View(memRepo.Members
        public ViewResult ListMembers(int page = 1)
        {
            MembersListViewModel model = new MembersListViewModel
            {
                Members = memRepo.Members
                .OrderBy(m => m.MemberID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = memRepo.Members.Count()
                }
            };
            return View(model);
        }


        public ViewResult EditMember(int memberId)
        {
            Member member = memRepo.Members.FirstOrDefault(m => m.MemberID == memberId);
            return View(member);
        }

        [HttpPost]
        public ActionResult EditMember(Member member)
        {
            if (ModelState.IsValid)
            {
                memRepo.SaveMember(member);
                TempData["message"] = string.Format("{0} has been saved", member.FirstName + " " + member.LastName);
                return RedirectToAction("SaveMember", "Member", member);
            }
            else
            {
                return View(member);
            }
        }

        // Save view

        public ViewResult SaveMember(Member member)
        {
            return View("SaveMember", member);
        }

        public ViewResult CreateMember()
        {
            return View("EditMember", new Member());
        }

        //public ViewResult RegisterMember()
        //{
        //    return View("RegisterMember", new Member());
        //}

        public ViewResult Register()
        {
            return View();
        }

        public ViewResult Logout()
        {
            Session["member"] = null;
            Session["membername"] = null;
            return View("Logout");
        }

        public ViewResult RegistrationError(Member member)
        {
            return View("RegistrationError", member);
        }

        public ViewResult DeleteMember(int memberId)
        {
            Member member = memRepo.Members.FirstOrDefault(m => m.MemberID == memberId);
            return View(member);
        }

        public ActionResult Delete(int memberId)
        {
            Member deletedMember = memRepo.DeleteMember(memberId);
            if (deletedMember != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedMember.FirstName + " " + deletedMember.LastName);
            }
            return RedirectToAction("ConfirmDelete", "Member", deletedMember);
        }

        public ActionResult ConfirmDelete(Member member)
        {
            return View();
        }

        public ViewResult ShowMember(Member member)
        {
            return View(member);
        }

        [HttpGet]
        public ViewResult AddMember()
        {
            return View();
        }

        [HttpPost]

        public ViewResult AddMember(Member member)
        {
            memRepo.AddMember(member);
            return View("ShowMember", member);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Member member)
        {
            
            Member temp = new Member();
                temp = memRepo.Members.FirstOrDefault(m => m.Email == member.Email);
                if (temp != null)
                {
                    if (member.Password == temp.Password)
                    {
                        Session[MEMBERNAME] = temp.FirstName + " " + temp.LastName;
                        Session[MEMBER] = temp;
                        ViewBag.LoginName = Session[MEMBERNAME];
                        if (temp.Email == "admin")
                        {
                            return View("~/Views/Admin/Index.cshtml");
                        }
                        else
                        {
                            return RedirectToAction("MemberIndex", "Home");
                        }
                    }
                }

                return RedirectToAction("InvalidLogin", "Member", member);
        }

        public ViewResult InvalidLogin(Member member)
        {
            return View("InvalidLogin", member);
        }

    }
}
