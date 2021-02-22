using System;
using System.Collections.Generic;
using System.Text;

namespace Gatchan.Base.Standard.Interfaces
{
    public interface IJsonConverter
    {
        string SerializeObject<T>(T item);

        T DeserializeObject<T>(string value);
    }
}
