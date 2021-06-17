
using LezizTariflerSepeti.Entity.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LezizTariflerSepeti.Entity.Models
{
    public class Recipe: CoreEntity
    {
        [Key]
        public int Id { get; set; }

        public string RecipeName { get; set; }

        public string Materials { get; set; }

        public string RecipeText { get; set; }
        public string ImgUrl { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
