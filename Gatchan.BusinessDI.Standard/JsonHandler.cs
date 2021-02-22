using Gatchan.Base.Standard.Interfaces;
using Newtonsoft.Json;
using System;

namespace Gatchan.BusinessDI.Standard
{
    public class JsonHandler : IJsonConverter
    {
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string SerializeObject<T>(T item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented);
        }
    }
}
