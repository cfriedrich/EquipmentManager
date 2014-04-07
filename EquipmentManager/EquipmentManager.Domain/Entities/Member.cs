using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EquipmentManager.Domain.Entities
{
    public class Member
    {
        [HiddenInput(DisplayValue = false)]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Members must have a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Members must have a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Members must have an email address")]
        public string Email { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool CanCheckout { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
