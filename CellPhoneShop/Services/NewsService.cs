using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CellPhoneShop
{
    public class NewsService : BaseService
    {
        public List<TinTuc> GetNews(int offset, int count)
        {
            RestRequest request = new RestRequest("news", Method.GET);
            request.AddParameter("offset", offset);
            request.AddParameter("count", count);
            string data = Get(request);
            List<TinTuc> result = (List<TinTuc>)DeserializeObject(data, typeof(List<TinTuc>));

            return result;
        }
    }
}