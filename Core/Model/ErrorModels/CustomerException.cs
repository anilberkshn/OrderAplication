using System;
using System.Net;
using Newtonsoft.Json;

namespace Core.Model.ErrorModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CustomerException: SystemException
    {
        // Customer ve Order Aynı isimde bir exception tanımlanabilir mi? HttpStatus code gibi
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