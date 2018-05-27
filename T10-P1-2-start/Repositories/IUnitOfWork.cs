using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T10_P1_2_start.Models;

namespace T10_P1_2_start.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UsersRepository { get; }
        IGenericRepository<Address> AddressesRepository { get; set; }

        void Save();
    }
}
