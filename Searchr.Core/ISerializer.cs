namespace Searchr.Core
{
    public interface ISerializer
    {
        byte[] Serialize<T>(T item);
        T Deserialize<T>(byte[] data);
    }
}
