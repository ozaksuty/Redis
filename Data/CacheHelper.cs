using Newtonsoft.Json;
using System.Text;

namespace Data
{
    public class CacheHelper
    {
        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        protected virtual T Deserialize<T>(string[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            string jsonString = "[";
            foreach (var item in serializedObject)
                jsonString += item + ",";
            jsonString += "]";
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}