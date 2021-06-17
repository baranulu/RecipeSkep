using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Data;
using LezizTariflerSepeti.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LezizTariflerSepeti.Business.RepositoryServices
{
   public class RecipeRepository:Repository<Recipe>,IRecipeRepository
    {
        public RecipeRepository(DataContext dataContext): base(dataContext)
        {
            
        }
    }
}
