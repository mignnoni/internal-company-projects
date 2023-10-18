using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace OurProjects.Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        #region Constructor
        protected AppDbContext _context;
        protected DbSet<T> DbSet => _context.Set<T>();
        protected IQueryable<T> Queryable => _context.Set<T>().AsNoTracking();

        public IQueryable<T> Query => Queryable;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            _context.ChangeTracker.Tracked += ChangeTracker_Tracked;
            _context.ChangeTracker.StateChanged += ChangeTracker_StateChanged;
        }

        private void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Entry.ToString());
        }

        private void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Entry.ToString());
        }
        #endregion Constructor

        public virtual T Add(T entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public virtual T Update(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;

            return entry.Entity;
        }


        public virtual void Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var del = Queryable.Where(predicate).AsEnumerable();

            DbSet.RemoveRange(del);
        }
    }
}
