using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testing_site_wil.Models;

namespace testing_site_wil.Repository.IRepository
{
    public interface IEventRepository: IRepository<Event>
    {
        void Update(Event obj);
        
    }
}
