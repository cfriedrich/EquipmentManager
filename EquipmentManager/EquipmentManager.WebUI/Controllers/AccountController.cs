using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquipmentManager.WebUI.Infrastructure.Abstract;
using EquipmentManager.WebUI.Models;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Abstract;
using EquipmentManager.WebUI.Controllers;


namespace EquipmentManager.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private  EFMemberRepository memRepo = new EFMemberRepository();

        private const String MEMBERNAME = "username";
        private const String MEMBER = "user";

        public AccountController(EFMemberRepository memberRepository)
        {
            this.memRepo = memberRepository;
        }

        public ViewResult RegisterMember()
        {
            return View("RegisterMember", new Member());
        }

        [HttpPost]
        public ViewResult RegisterMember(Member member)
        {
            Member temp = memRepo.Members.FirstOrDefault(m => m.Email == member.Email);
            if (temp != null)
            {
                memRepo.AddMember(member);
                return View("Index", "Home");
            }
            else
            {
                return View("RegistrationError", member);
            }
        }

    }
}
