using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Data;
using LezizTariflerSepeti.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LezizTariflerSepeti.Business.RepositoryServices
{
   public class CategoryRepository : Repository<Category> ,ICategoryRepository
    {
        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
