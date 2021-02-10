using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication2.Managers
{
    public interface IDataReader
    {
        Task<Dictionary<string, List<string>>> GetDataAsync(int keyLength);
    }
}
