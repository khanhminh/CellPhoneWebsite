using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CellPhoneShop
{
    public class ContactService : BaseService
    {
        public bool PostContact(LienHe lh)
        {
            RestRequest request = new RestRequest("contact", Method.POST);
            string data = Post(request, lh);
            bool result = (bool)DeserializeObject(data, typeof(bool));

            return result;
        }
    }
}