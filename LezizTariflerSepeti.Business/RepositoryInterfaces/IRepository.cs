
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LezizTariflerSepeti.Business.RepositoryInterfaces
{
   public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        T GetById(int? id);

        void Delete(int? id);

        IEnumerable<T> GetAll();

        void RollBack();

        void AddRange(IEnumerable<T> entities);

        void RemoveRange(IEnumerable<T> entities);

        IEnumerable<T> GetDefault(Expression<Func<T, bool>> exp);


        bool Any(Expression<Func<T, bool>> exp);

        public List<T> TList(string p);
        
    }
}
