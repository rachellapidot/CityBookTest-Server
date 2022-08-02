using Weather.App.Domain.Model;
using Weather.App.Model;

namespace Weather.App.Domain.Cotext
{
    public interface IRepository
    {
        public Task<int> Insert(FavoriteCities entity);

        public List<FavoriteCities> GetAll();
    }
}
