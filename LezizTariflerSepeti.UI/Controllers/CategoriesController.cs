using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LezizTariflerSepeti.Entity.Models;
using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Business.UnıtOfWork;

namespace LezizTariflerSepeti.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnıtOfWork _unıtOfWork;

        public CategoriesController(ICategoryRepository categoryRepository,IUnıtOfWork unıtOfWork)
        {
            _categoryRepository = categoryRepository;
            _unıtOfWork = unıtOfWork;
        }

        // GET: Categories
        public IActionResult Index()
        {
            var categories = _categoryRepository.TList("Recipes");
            return View(categories);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoryName,Description,ImgUrl")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                _unıtOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category =_categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CategoryName,Description,Recipes,ImgUrl")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _categoryRepository.Update(category);
                    _unıtOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(id);
            _unıtOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _categoryRepository.Any(e => e.Id == id);
        }
    }
}
