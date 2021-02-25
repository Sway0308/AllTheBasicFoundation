using Gatchan.Base.Standard.Base;
using Gatchan.Base.Standard.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gatchan.Base.Standard.Abstracts
{
    public abstract class JsonAbstractHandler : IJsonHandler
    {
        public IJsonConverter JsonConverter { get; set; }

        public abstract void LoadItem(string filePath);
        public abstract void SaveToJson();

        protected T LoadItemFromJson<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                return new T();

            var json = File.ReadAllText(filePath);
            return JsonConverter.DeserializeObject<T>(json);
        }

        protected IList<T> LoadListFromJson<T>(string filePath) where T : new()
        {
            var infos = new List<T>();
            if (!File.Exists(filePath))
                return infos;

            var json = File.ReadAllText(filePath);
            var items = JsonConverter.DeserializeObject<IList<T>>(json);
            items.ForEach(x => { infos.Add(x); });
            return infos;
        }

        protected void ExportItemToJson<T>(T item, string path)
        {
            var str = JsonConverter.SerializeObject(item);
            File.WriteAllText(path, str, Encoding.UTF8);
        }

        protected void ExportListToJson<T>(IEnumerable<T> items, string path, bool isIncludeSource) where T : new()
        {
            var sources = !isIncludeSource ? new List<T>() : LoadListFromJson<T>(path);

            foreach (var item in items)
            {
                if (!sources.Any(x => x.Equals(item)))
                    sources.Add(item);
            }

            var str = JsonConverter.SerializeObject(sources);
            File.WriteAllText(path, str, Encoding.UTF8);
        }
    }
}
