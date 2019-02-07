using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GameArchiveSync.Business.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// 将Json字符串转换为Json实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T Parse<T>(this string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }
    }
}
