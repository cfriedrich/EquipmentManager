using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using EquipmentManager.Domain.Entities;
using EquipmentManager.Domain.Abstract;
using Moq;
using EquipmentManager.Domain.Concrete;
using EquipmentManager.WebUI.Infrastructure.Abstract;
using EquipmentManager.WebUI.Infrastructure.Concrete;

namespace EquipmentManager.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {

            ninjectKernel.Bind<I_ItemRepository>().To<EFItemRepository>();
            ninjectKernel.Bind<I_MemberRepository>().To<EFMemberRepository>();
            ninjectKernel.Bind<I_ReservationRepository>().To<EFReservationRepository>();
            ninjectKernel.Bind<I_AuthProvider>().To<FormsAuthProvider>();
            //Mock<I_ItemRepository> mockI = new Mock<I_ItemRepository>();
            //Mock<I_ReservationRepository> mockR = new Mock<I_ReservationRepository>();
            //Mock<I_MemberRepository> mockM = new Mock<I_MemberRepository>();


            //mockI.Setup(i => i.Items).Returns(new List<Item>
            //{
            //    new Item { ItemID = 1, Name = "Ipad", Category = "Tablet", Description = "2nd Generation", Operational = true, CheckedOut = false},
            //    new Item { ItemID = 2, Name = "Ipod", Category = "Mp3 Player", Description = "4th Generation", Operational = true, CheckedOut = false},
            //    new Item { ItemID = 3, Name = "Ipad Mini", Category = "Tablet", Description = "1st Generation", Operational = true, CheckedOut = false}
            //}.AsQueryable());

            //mockM.Setup(m => m.Members).Returns(new List<Member>
            //{
            //    new Member { MemberID = 1, FirstName = "Chris", LastName = "Friedrich", Email = "chrisfriedrich@outlook.com", Classification = "Student", CanCheckout = true },
            //    new Member { MemberID = 2, FirstName = "George", LastName = "Washington", Email = "georgewashington@outlook.com", Classification = "President", CanCheckout = true },
            //    new Member {  MemberID = 3, FirstName = "Thomas", LastName = "Edison", Email = "thomasedison@outlook.com", Classification = "Inventor", CanCheckout = true }
            //}.AsQueryable());

            //mockR.Setup(r => r.Reservations).Returns(new List<Reservation>
            //{
            //    new Reservation { ReservationID = 1, MemberID = 1, ItemID = 1, StartDate = new DateTime(01/01/01), DueDate = new DateTime(2/2/02) },
            //    new Reservation { ReservationID = 2, MemberID = 2, ItemID = 2, StartDate = new DateTime(3/3/03), DueDate = new DateTime(4/4/04) },
            //    new Reservation { ReservationID = 3, MemberID = 3, ItemID = 3, StartDate = new DateTime(5/5/05), DueDate = new DateTime(6/6/06) }
            //}.AsQueryable());

            //ninjectKernel.Bind<I_ItemRepository>().ToConstant(mockI.Object);
            //ninjectKernel.Bind<I_MemberRepository>().ToConstant(mockM.Object);
            //ninjectKernel.Bind<I_ReservationRepository>().ToConstant(mockR.Object);

            
        }

    }
}