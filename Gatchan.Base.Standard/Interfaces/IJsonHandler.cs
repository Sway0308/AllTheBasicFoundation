using System;
using System.Collections.Generic;
using System.Text;

namespace Gatchan.Base.Standard.Interfaces
{
    public interface IJsonHandler
    {
        void LoadItem(string filePath);
        void SaveToJson();
    }
}
