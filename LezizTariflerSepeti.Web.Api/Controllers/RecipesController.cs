using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Entity.PaginationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using LezizTariflerSepeti.Entity.Helpers;
using Newtonsoft.Json;

namespace LezizTariflerSepeti.Web.Api.Controllers
{

    [ApiController]

    [Route("api/[controller]")]

    [EnableCors(origins: "MyAllowSpecificOrigins", headers: "*", methods: "*")]
    public class RecipesController:ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        
        public RecipesController(IRecipeRepository recipeRepository)
        {
            this._recipeRepository = recipeRepository;
        }

        [HttpGet]
        public object Get([FromQuery] RecipeParameters recipeParameters)
        {
            var recipes = _recipeRepository.GetAllRecipe(recipeParameters);



            var metadata = new
            {
                recipes.TotalCount,
                recipes.PageSize,
                recipes.CurrentPage,
                recipes.TotalPages,
                recipes.HasNext,
                recipes.HasPrevious

            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            
            return Ok(recipes);
        }

        [HttpGet("{categoryId}")]
        public object GetRecipeByCategory(int? categoryId)
        {
            try
            {
                var recipe = _recipeRepository.GetDefault(x => x.CategoryId == categoryId);

                if(recipe==null)
                {
                    return NotFound();
                }
                return recipe;
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }

        }

            [HttpGet("name/{text}")]
           public object GetSearchData(string text)
        {

            var recipe = _recipeRepository.GetDefault(x => x.RecipeName.Contains(text));
            return recipe;

            
        }


        [HttpGet("Length")]
        public object GetArrayRecipes()
        {
            Array recipes = _recipeRepository.GetAllRecipes();

            return recipes.Length;
        }




        [HttpGet("recipedetail/{id}")]
        public object GetRecipeById(int? id)
        {
            try
            {
                var recipe = _recipeRepository.GetById(id);

                if (id == null) { return NotFound(); }

                return recipe;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }


            



        }
    }
}
