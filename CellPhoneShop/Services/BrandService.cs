using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace CellPhoneShop
{
    public class BrandService : BaseService
    {
        public List<NhaSanXuat> GetListBrand()
        {
            RestRequest request = new RestRequest("brand", Method.GET);
            string data = Get(request);
            List<NhaSanXuat> listBrand = (List<NhaSanXuat>) DeserializeObject(data, typeof(List<NhaSanXuat>));

            return listBrand;
        }
    }
}