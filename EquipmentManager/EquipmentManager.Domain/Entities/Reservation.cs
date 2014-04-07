using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EquipmentManager.Domain.Entities
{
    public class Reservation
    {
        private DateTime startDate;

        [HiddenInput(DisplayValue = false)]
        public int ReservationID { get; set; }

        [Required(ErrorMessage = "You must specify a Member ID")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "You must specify an Item for checkout")]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "You must specify a start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Members must have a first name")]
        public DateTime DueDate { get; set; }
            
    }
}
