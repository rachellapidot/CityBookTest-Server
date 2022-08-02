using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Weather.App.Domain.Model;
using Weather.App.Model;

namespace Weather.App.Domain.Cotext
{
    public class Repository: IRepository
    {
        private WeatherDbContext DbContext { get; }
        private readonly DbSet<FavoriteCities> _dbSet;

        public Repository(WeatherDbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<FavoriteCities>();
        }

        public Task<int> Insert(FavoriteCities entity)
        {
            try
            {
                _dbSet.Add(entity);

                return DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
             
        }

        public List<FavoriteCities> GetAll()
        {
            IQueryable<FavoriteCities> query = _dbSet;
            return query.ToList();
        }
    }
}
