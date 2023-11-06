using testing_site_wil.Data;
using testing_site_wil.Models;
using testing_site_wil.Repository.IRepository;

namespace testing_site_wil.Repository
{
    public class ShoppingRepository : Repository<Shopping>, IShoppingRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Shopping obj)
        {
            _db.Update(obj);
        }
    }
}
