using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing_site_wil.Models;
namespace testing_site_wil.Repository.IRepository
{
    public interface IShoppingRepository: IRepository<Shopping>
    {
        void Update(Shopping obj);
    }
}
