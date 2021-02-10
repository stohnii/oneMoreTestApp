using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication2.Managers
{
    public class DataReader : IDataReader
    {
        private const string uri = "https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt";

        public async Task<Dictionary<string, List<string>>> GetDataAsync(int keyLength)
        {
            var result = new Dictionary<string, List<string>>();
            var sReader = new StreamReader(await new HttpClient().GetStreamAsync(uri));
            string line;
            while ((line = await sReader.ReadLineAsync()) != null)
            {
                if (string.IsNullOrEmpty(line) || line.Length < keyLength)
                    continue;

                string key = new String(line.Take(keyLength).ToArray());

                if(!result.ContainsKey(key))
                    result[key] = new List<string>();

                result[key].Add(line);
            }

            return result;
        }
    }
}
