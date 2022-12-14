

using Newtonsoft.Json;

namespace TodoTasksServer.Util
{
    public static class Extension
    {
        private static readonly JsonSerializerSettings _settings = new ()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            FloatFormatHandling = FloatFormatHandling.DefaultValue,
        };

        public static T ConvertToModel<T>(object data)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data), _settings);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
