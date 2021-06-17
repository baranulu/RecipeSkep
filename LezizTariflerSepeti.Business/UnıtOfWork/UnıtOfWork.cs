using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Business.RepositoryServices;

using LezizTariflerSepeti.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LezizTariflerSepeti.Business.UnıtOfWork
{
    public class UnıtOfWork : IUnıtOfWork
    {
        private readonly DataContext _dataContext;
        public UnıtOfWork(DataContext dataContext)
        {
            this._dataContext = dataContext;
            categoryRepository = new CategoryRepository(_dataContext);
            recipeRepository = new RecipeRepository(_dataContext);
        }


        public ICategoryRepository categoryRepository { get; private set; }

        public IRecipeRepository recipeRepository { get; private set; }

        public int Complete()
        {
           return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
