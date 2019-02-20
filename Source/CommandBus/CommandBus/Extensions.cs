using Newtonsoft.Json;

namespace CommandBus
{
    public static class Extensions
    {
        public static string ToJson<T>(this T entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
