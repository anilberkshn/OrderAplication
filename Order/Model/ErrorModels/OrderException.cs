using System;
using System.Net;
using Newtonsoft.Json;

namespace OrderCase.Model.ErrorModels
{
    [JsonObject (MemberSerialization.OptIn)]
    public class OrderException: SystemException
    {
        
        [JsonProperty]
        public HttpStatusCode StatusCode;
        [JsonProperty]
        public string ErrorMessage;

        public OrderException(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}