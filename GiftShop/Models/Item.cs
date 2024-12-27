using GiftShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class Item : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }
        public string Description { get; set; }

        //Relationships
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
