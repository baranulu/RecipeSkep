using LezizTariflerSepeti.Business.RepositoryInterfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LezizTariflerSepeti.Data;
using System.Linq.Expressions;

namespace LezizTariflerSepeti.Business.RepositoryServices
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        private readonly DbSet<T> _entities;


        public Repository(DataContext dataContext)
        {

            _dataContext = dataContext;
            _entities = dataContext.Set<T>();
        }



        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _entities.Add(entity);
            try
            {
                _dataContext.SaveChanges();
            }
            catch
            {
                RollBack();
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _entities.Any(exp);
        }

        

        public void Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException("entity");
            _entities.Remove(GetById(id));
        }

        

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(int? id)
        {
            if (id == null) throw new ArgumentNullException("entity");

           return _entities.Find(id);
        }

        public IEnumerable<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _entities.Where(exp);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }

        public void RollBack()
        {
            _dataContext.Dispose();
        }

        public List<T> TList(string p)
        {
            return _dataContext.Set<T>().Include(p).ToList();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
