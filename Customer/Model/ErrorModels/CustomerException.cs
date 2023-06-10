using System;
using System.Net;
using Newtonsoft.Json;

namespace Customer.Model.ErrorModels
{
    [JsonObject (MemberSerialization.OptIn)]
    public class CustomerException: SystemException
    {
        
        [JsonProperty]
        public HttpStatusCode StatusCode;
        [JsonProperty]
        public string ErrorMessage;

        public CustomerException(HttpStatusCode statusCode, string errorMessage)
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