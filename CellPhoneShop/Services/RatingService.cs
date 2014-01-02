using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CellPhoneShop
{
    public class RatingService : BaseService
    {
        public bool Rating(DanhGia model)
        {
            RestRequest request = new RestRequest("rating", Method.PUT);
            string data = Post(request, model);
            bool result = (bool)DeserializeObject(data, typeof(bool));

            return result;
        }

        public RatingModel GetRating(int id)
        {
            RestRequest request = new RestRequest("rating/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            string data = Get(request);
            RatingModel result = (RatingModel)DeserializeObject(data, typeof(RatingModel));

            return result;
        }
    }
}