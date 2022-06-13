using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace GetAuthorizationTokens
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string jsonString)
        {
            T returnObj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(returnObj.GetType());
                returnObj = (T)serializer.ReadObject(ms);
            }
            return returnObj;
        }
        /// <summary>
        /// JSON Serialization
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        /// <summary>
        /// JSON Deserialization
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
        /// <summary>
        /// JSON Deserialization using NewtonSoft
        /// ignoreRoot - False : Returns First Root Element
        /// ignoreRoot - True : DeSerializes entire json to specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="ignoreRoot"></param>
        /// <returns></returns>
        public static T NewtonSoftDeserialize<T>(string json, bool ignoreRoot) where T : class
        {
            return !ignoreRoot
                ? JObject.Parse(json)?.Properties()?.First()?.Value?.ToObject<T>()
                : JObject.Parse(json)?.ToObject<T>();
        }
        /// <summary>
        /// Return Deseriazlized object of specified JSON token
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <param name="selectToken"></param>
        /// <returns></returns>
        public static T NewtonSoftSelectTokenDeserialize<T>(string json, string selectToken) where T : class
        {
            return JObject.Parse(json)?.SelectToken("$.." + selectToken)?.ToObject<T>();
        }

    }
}

