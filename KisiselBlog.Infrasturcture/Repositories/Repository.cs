using KisiselBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace KisiselBlog.Infrasturcture.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SiteContext _context;
        private IDbSet<T> _dbset;


        public Repository(SiteContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        protected virtual IDbSet<T> DbSet
        {
            get { return _dbset ?? (_dbset = _context.Set<T>()); }
        }
        // insert işlemi
        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity boş");
                this.DbSet.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var fail = GenerateException(ex);
                throw fail;
            }
        }

        // id göre kayıt silme
        public void Delete(int id)
        {
            var entityDelete = DbSet.Find(id);
            Delete(entityDelete);

        }

        //T nesnesine göre kayıt silme
        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity boş");

                if (_context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);

                this.DbSet.Remove(entity);
                this._context.SaveChanges();

                    
            }
            catch (DbEntityValidationException ex)
            {
                var fail = GenerateException(ex);
               
                throw fail;
                
            }
        }

       

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).SingleOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }
        // kayıt  güncelleme
        public void Update(T entity)
        {

            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity boş");

                DbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                this._context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                var fail = GenerateException(ex);
                throw fail;
            }

        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private static Exception GenerateException(DbEntityValidationException dbEx)
        {
            var msg = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine +
                           string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

            var fail = new Exception(msg, dbEx);
            return fail;
        }
    }
}
