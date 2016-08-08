using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Searchr.Core
{
	public class JsonSerializer : ISerializer
	{
        public byte[] Serialize<T>(T item)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item, Formatting.Indented));
        }

        public T Deserialize<T>(byte[] data)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data));
        }
	}
}
