using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Repositories
{
    public interface IDBContextFactory
    {
        DbAppRepositoryContext Get();
    }
}
