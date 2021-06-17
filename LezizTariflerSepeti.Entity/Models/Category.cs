
using LezizTariflerSepeti.Entity.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LezizTariflerSepeti.Entity.Models
{
     public class Category :CoreEntity

    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
