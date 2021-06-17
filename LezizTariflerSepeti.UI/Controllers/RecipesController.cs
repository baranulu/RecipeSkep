using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LezizTariflerSepeti.Data;
using LezizTariflerSepeti.Entity.Models;
using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Business.UnıtOfWork;

namespace LezizTariflerSepeti.UI.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnıtOfWork _unıtofWork;
        private readonly ICategoryRepository _categoryRepository;

        public RecipesController(IRecipeRepository recipeRepository,IUnıtOfWork unıtOfWork,ICategoryRepository categoryRepository)
        {
            this._recipeRepository = recipeRepository;
            this._unıtofWork = unıtOfWork;
            this._categoryRepository = categoryRepository;
        }

        // GET: Recipes
        public IActionResult Index()
        {
            var recipes = _recipeRepository.TList("Category"); 
            return View(recipes);
        }

        // GET: Recipes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = _recipeRepository.GetById(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_categoryRepository.GetAll(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,RecipeName,Materials,RecipeText,CategoryId,ImgUrl")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _recipeRepository.Add(recipe);
                _unıtofWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_categoryRepository.GetAll(), "Id", "CategoryName", recipe.CategoryId);
            return View(recipe);
        }

        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = _recipeRepository.GetById(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_categoryRepository.GetAll(), "Id", "CategoryName", recipe.CategoryId) ;
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,RecipeName,Materials,RecipeText,CategoryId,ImgUrl")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _recipeRepository.Update(recipe);
                    _unıtofWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_recipeRepository.GetAll(), "Id", "CategoryName", recipe.CategoryId);
            return View(recipe);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = _recipeRepository.GetById(id.Value);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var recipe = _recipeRepository.GetById(id);
           _recipeRepository.Delete(id);
            _unıtofWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _recipeRepository.Any(e => e.Id == id);
        }
    }
}
