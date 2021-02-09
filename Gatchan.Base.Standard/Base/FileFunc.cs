using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gatchan.Base.Standard.Base
{
    public static class FileFunc
    {
        public static T LoadItemFromJson<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                return new T();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static IList<T> LoadListFromJson<T>(string filePath) where T : new()
        {
            var infos = new List<T>();
            if (!File.Exists(filePath))
                return infos;

            var json = File.ReadAllText(filePath);
            var items = JsonConvert.DeserializeObject<IList<T>>(json);
            items.ForEach(x => { infos.Add(x); });
            return infos;
        }

        public static void ExportItemToJson<T>(T item, string path)
        {
            var str = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(path, str, Encoding.UTF8);
        }

        public static void ExportListToJson<T>(IEnumerable<T> items, string path, bool isIncludeSource) where T : new()
        {
            var sources = !isIncludeSource ? new List<T>() : LoadListFromJson<T>(path);

            foreach (var item in items)
            {
                if (!sources.Any(x => x.Equals(item)))
                    sources.Add(item);
            }

            var str = JsonConvert.SerializeObject(sources, Formatting.Indented);
            File.WriteAllText(path, str, Encoding.UTF8);
        }
    }
}
