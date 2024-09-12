using GoodReads.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }


        Task<int> CompleteAsync();
        Task BeginTransaction();
        Task CommitAsync();
    }
}
