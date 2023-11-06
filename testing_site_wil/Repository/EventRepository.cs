using testing_site_wil.Data;
using testing_site_wil.Models;
using testing_site_wil.Repository.IRepository;


namespace testing_site_wil.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Event obj)
        {
            _db.Update(obj);
        }
    }
}