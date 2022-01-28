using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Domain
{
    public interface IStoreable : ICloneable
    {
        IComparable Id { get; }
    }
}
