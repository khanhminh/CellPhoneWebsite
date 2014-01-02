using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;
using System.Configuration;

namespace CellPhoneShop
{
    public class BaseService
    {
        protected RestClient client = new RestClient(ConfigurationManager.AppSettings["LinkApi"]);
        protected string access_token = ConfigurationManager.AppSettings["access_token"];

        protected string Get(RestRequest request)
        {
            request.AddParameter("access_token", access_token);
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        protected string Post(RestRequest request, object obj)
        {
            request.Resource += "?access_token=" + access_token;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            
            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        protected Object DeserializeObject(string data, Type type)
        {
            return JsonConvert.DeserializeObject(data, type);
        }
    }
}