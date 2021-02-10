using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication2.Managers
{
    public interface IDataSearchManager
    {
        Task<IEnumerable<string>> SearchWordsByStemAsync(string stem);
    }
}
