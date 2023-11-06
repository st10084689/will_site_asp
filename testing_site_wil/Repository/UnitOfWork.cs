using testing_site_wil.Data;
using testing_site_wil.Repository.IRepository;

namespace testing_site_wil.Repository
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Shopping = new ShoppingRepository(_db);
            Event = new EventRepository(_db);
            
        }

        public IEventRepository Event { get; private set; }

        public IShoppingRepository Shopping { get; private set; }

        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
