using LezizTariflerSepeti.Business.RepositoryInterfaces;
using LezizTariflerSepeti.Business.RepositoryServices;
using LezizTariflerSepeti.Business.UnıtOfWork;
using LezizTariflerSepeti.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LezizTariflerSepeti.Root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IRecipeRepository), typeof(RecipeRepository));
            services.AddScoped(typeof(IUnıtOfWork), typeof(UnıtOfWork));

            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer("server=. ;uid=sa ;database=LezizTariflerSepeti ; pwd=1234asdf ;MultipleActiveResultSets=True", x => x.MigrationsAssembly("LezizTariflerSepeti.UI")));
        }
    }
}
