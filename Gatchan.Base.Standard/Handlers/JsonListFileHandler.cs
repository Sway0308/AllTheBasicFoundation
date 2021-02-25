using Gatchan.Base.Standard.Abstracts;
using Gatchan.Base.Standard.Base;
using System.Collections.Generic;

namespace Gatchan.Base.Standard.Handlers
{
    public class JsonListFileHandler<T> : JsonAbstractHandler where T : new()
    {
        private string _FilePath;

        public JsonListFileHandler()
        {
        }

        public IList<T> Items { get; private set; }
        public bool IsIncludeSource { get; set; }

        public override void LoadItem(string filePath)
        {
            _FilePath = filePath;
            Items = LoadListFromJson<T>(_FilePath);
        }

        public override void SaveToJson()
        {
            ExportListToJson(Items, _FilePath, IsIncludeSource);
        }
    }
}
