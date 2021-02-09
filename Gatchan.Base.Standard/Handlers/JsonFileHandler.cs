using Gatchan.Base.Standard.Base;

namespace Gatchan.Base.Standard.Handlers
{
    public class JsonFileHandler<T> where T : class, new()
    {
        private readonly string _FilePath;

        public JsonFileHandler(string filePath)
        {
            _FilePath = filePath;
            Item = FileFunc.LoadItemFromJson<T>(_FilePath);
        }

        public T Item { get; private set; }

        public void SaveItemToJson()
        {
            FileFunc.ExportItemToJson(Item, _FilePath);
        }
    }
}
