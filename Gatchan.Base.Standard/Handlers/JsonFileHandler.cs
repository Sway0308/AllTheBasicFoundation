using Gatchan.Base.Standard.Abstracts;

namespace Gatchan.Base.Standard.Handlers
{
    public class JsonFileHandler<T> : JsonAbstractHandler where T : class, new()
    {
        private string _FilePath;

        public JsonFileHandler()
        {
        }

        public T Item { get; private set; }

        public override void LoadItem(string filePath)
        {
            _FilePath = filePath;
            Item = LoadItemFromJson<T>(_FilePath);
        }

        public override void SaveToJson()
        {
            ExportItemToJson(Item, _FilePath);
        }
    }
}
