using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CellPhoneShop
{
    public class OSService : BaseService
    {
        public List<HeDieuHanh> GetOS()
        {
            RestRequest request = new RestRequest("os", Method.GET);
            string data = Get(request);
            List<HeDieuHanh> result = (List<HeDieuHanh>)DeserializeObject(data, typeof(List<HeDieuHanh>));

            return result;
        }
    }
}