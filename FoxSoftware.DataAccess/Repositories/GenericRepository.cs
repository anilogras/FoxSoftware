using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{

    public class GenericRepository<TEntity>
    where TEntity : BaseClass, new()
    {

        private readonly DbContext _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var added = _context.Entry(entity);
            added.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            var deleted = _context.Entry(entity);
            deleted.State = EntityState.Deleted;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);

        }

        public void Update(TEntity entity)
        {
            var updated = _context.Entry(entity);
            updated.State = EntityState.Modified;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().FirstOrDefault(expression);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression != null
                ? _context.Set<TEntity>().Where(expression).ToList()
                : _context.Set<TEntity>().ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression != null ?
                 _context.Set<TEntity>().Where(expression) :
                 _context.Set<TEntity>();
        }

        public int EntityCount()
        {
            return _context.Set<TEntity>().Count();
        }
    }

}
