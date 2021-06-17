using LezizTariflerSepeti.Business.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LezizTariflerSepeti.Business.UnıtOfWork
{
   public interface IUnıtOfWork :IDisposable
    {
            ICategoryRepository categoryRepository { get; }
            IRecipeRepository recipeRepository { get;  }

            int Complete();
    }
}
