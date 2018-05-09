using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tour_of_hereos.Models;

namespace tour_of_hereos.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Hero> HeroesRepository { get;}

        void Save();
    }
}
