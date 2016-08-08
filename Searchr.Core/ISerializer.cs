using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Searchr.Core
{
	public interface ISerializer
	{
        byte[] Serialize<T>(T item);
        T Deserialize<T>(byte[] data);
	}
}
