using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Data;
using LezizTariflerSepeti.Entity.Helpers;
using LezizTariflerSepeti.Entity.Models;
using LezizTariflerSepeti.Entity.PaginationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LezizTariflerSepeti.Business.RepositoryServices
{
   public class RecipeRepository:Repository<Recipe>,IRecipeRepository
    {

        private readonly DbSet<Recipe> _recipes;
        public RecipeRepository(DataContext dataContext): base(dataContext)
        {

            _recipes = dataContext.Set<Recipe>();
        }

        public PagedList<Recipe> GetAllRecipe(RecipeParameters recipeParameters)
        {

            return PagedList<Recipe>.ToPagedList(_recipes.OrderBy(x => x.Id),
                recipeParameters.PageNumber, recipeParameters.PageSize);
            //return _recipes.Skip((recipeParameters.PageNumber - 1) * recipeParameters.PageSize)
            //    .Take(recipeParameters.PageSize).ToList();
        }

        public Array GetAllRecipes()
        {
            return _recipes.ToArray();
        }
    }
}
