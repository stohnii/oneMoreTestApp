using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Managers
{
    public class DataSearchManager : IDataSearchManager
    {
        private const string dataKey = "dataKey_{0}";
        private readonly CacheManager _cacheManager;
        private readonly IDataReader _dataReader;

        public DataSearchManager(CacheManager cacheManager, IDataReader dataReader)
        {
            _cacheManager = cacheManager;
            _dataReader = dataReader;
        }
        public async Task<IEnumerable<string>> SearchWordsByStemAsync(string stem)
        {
            var data = _cacheManager.GetOrCreate<Dictionary<string, List<string>>>(string.Format(dataKey, stem?.Length ?? 0),
                entry => _dataReader.GetDataAsync(stem?.Length ?? 0).Result);

            if (string.IsNullOrEmpty(stem))
                return data.Values.SelectMany(v => v);
            if (!data.ContainsKey(stem))
                return null;

            return data[stem];
        }
    }
}
