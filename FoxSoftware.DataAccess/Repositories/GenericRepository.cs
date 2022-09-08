using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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

        public GenericRepository(DbContext context)
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

        public TEntity Get(Expression<Func<TEntity, bool>> expression, string[] list = null)
        {
            IQueryable<TEntity> entity = _context.Set<TEntity>().Where(x => x.Silinmis == false);

            if (list != null)
                foreach (var inc in list)
                {
                    entity = entity.Include(inc);
                }

            return entity.FirstOrDefault(expression);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, string[] list = null)
        {

            if (expression != null)
            {
                IQueryable<TEntity> entity = _context.Set<TEntity>().Where(x => x.Silinmis == false);

                if (list != null)
                    foreach (var inc in list)
                    {
                        entity = entity.Include(inc);
                    }
                return entity.Where(expression).ToList();
            }
            else
            {
                IQueryable<TEntity> entity = _context.Set<TEntity>().Where(x => x.Silinmis == false);

                if (list != null)
                    foreach (var inc in list)
                    {
                        entity = entity.Include(inc);
                    }
                return entity.ToList();
            }

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression != null ?
                 _context.Set<TEntity>().Where(x => x.Silinmis == false).Where(expression) :
                 _context.Set<TEntity>().Where(x => x.Silinmis == false);
        }

        public int EntityCount()
        {
            return _context.Set<TEntity>().Where(x => x.Silinmis == false).Count();
        }


        public DataTable GetSQLResult(string sql)
        {
            DataTable dt = new DataTable();

            DbContext _cntx = DataAccessHelper.NewContext;
            using (SqlConnection con = (SqlConnection)_cntx.Database.Connection)
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        dt.Load(read);
                        read.Close();
                        con.Close();
                    }
                }
            }
            return dt;
        }
    }

}
