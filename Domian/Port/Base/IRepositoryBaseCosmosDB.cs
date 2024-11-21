using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Port
{
    public interface IRepositoryBaseCosmosDB<T>
        where T : class, new()
    {
        Task<T> CreateModel(T entity);
        Task<List<T>> ToListModel();
    }
}
