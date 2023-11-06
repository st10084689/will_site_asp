namespace testing_site_wil.Repository.IRepository
{
    public interface IUnitOfWork
    {

        IEventRepository Event { get; }

        IShoppingRepository Shopping { get; }

        void Save();
    }
}


