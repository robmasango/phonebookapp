using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneBookApp.Logic.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {

        private PhoneBookAppContext _context;

        #region Properties
        public EntityBaseRepository(PhoneBookAppContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<List<T>> FindMany(Expression<Func<T, bool>> predicate)
        {
            List<T> entities = await _context.Set<T>().Where(predicate).ToListAsync();

            return entities;
        }

        public async Task<List<T>> LoadAll()
        {
            var entities = await _context.Set<T>().ToListAsync();

            return entities;
        }

        public async virtual Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }
        public  virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsEnumerable();
        }

        public async Task<T> FindSingle()
        {
            return await _context.Set<T>().FirstOrDefaultAsync();
        }
        public async Task<T> FindSingle(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<T> FindSingle(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async virtual  Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public  virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
             _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
