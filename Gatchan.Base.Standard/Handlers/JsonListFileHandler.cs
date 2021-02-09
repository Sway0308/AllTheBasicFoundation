using Gatchan.Base.Standard.Base;
using System.Collections.Generic;

namespace Gatchan.Base.Standard.Handlers
{
    public class JsonListFileHandler<T> where T : new()
    {
        private readonly string _FilePath;

        public JsonListFileHandler(string filePath)
        {
            _FilePath = filePath;
            Items = FileFunc.LoadListFromJson<T>(_FilePath);
        }

        public IList<T> Items { get; }

        public void SaveItemsToJson(bool isIncludeSource = false)
        {
            FileFunc.ExportListToJson(Items, _FilePath, isIncludeSource);
        }
    }
}
