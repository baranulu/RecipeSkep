using LezizTariflerSepeti.Entity.Helpers;
using LezizTariflerSepeti.Entity.Models;
using LezizTariflerSepeti.Entity.PaginationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LezizTariflerSepeti.Business.RepositoryInterfaces
{
   public interface IRecipeRepository:IRepository<Recipe>
    {

        PagedList<Recipe> GetAllRecipe(RecipeParameters recipeParameters);

        public Array GetAllRecipes();
    }
}
