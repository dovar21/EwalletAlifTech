using System;
using Newtonsoft.Json;

namespace EwalletAlifTech.Modules.Core.Responses
{
    public class JsonResponseObject
    {
        public JsonResponseObject(Int16 code = 0, object data = null, string message = null,
            object errors = null)
        {
            Code = code;
            Data = data;
            Message = message;
            Errors = errors;
        }

        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public Int16? Code { get; }

        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        [JsonProperty(PropertyName = "errors", NullValueHandling = NullValueHandling.Ignore)]
        public object Errors { get; }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; }
    }
}
