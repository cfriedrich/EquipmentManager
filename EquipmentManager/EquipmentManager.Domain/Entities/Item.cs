using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EquipmentManager.Domain.Entities
{
    public class Item
    {
        [HiddenInput(DisplayValue = false)]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "You must enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must have some sort of description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Items must have a category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please mark whether item is operational or not")]
        public bool Operational { get; set; }

        [Required(ErrorMessage = "Please mark whether the item is checked out or not")]
        public bool CheckedOut { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]

        public string ImageMimeType { get; set; }
    }
}
