using LezizTariflerSepeti.Business.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

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
        public object Get()
        {
            return _recipeRepository.GetAll().Select(x => new
            {
                x.Id,
                x.CategoryId,
                x.Category,
                x.RecipeName,
                x.Materials,
                x.RecipeText,
                x.ImgUrl
            });
        }

        [HttpGet("{categoryId}")]
        public object GetRecipe(int? categoryId)
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
    }
}
