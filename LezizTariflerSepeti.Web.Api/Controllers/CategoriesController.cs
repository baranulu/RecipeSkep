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
    public class CategoriesController: ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public object GetCategories()
        {
            return _categoryRepository.GetAll().Select(x => new
            {
                x.Id,
                x.CategoryName,
                x.Description,
                x.ImgUrl

            });
        }
        [HttpGet("{id}")]
        public object GetCategory(int? id)
        {
            try
            {
                var category = _categoryRepository.GetById(id);

                if (category == null)
                {
                    return NotFound();
                }
                return category;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
      

    }
}
