using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Domain
{
    public interface IRepository<T> where T : IStoreable
    {
        Task<IEnumerable<T>> AllAsync();
        Task DeleteAsync(IComparable id);
        Task SaveAsync(T item);
        Task<T> FindByIdAsync(IComparable id);
    }
}
