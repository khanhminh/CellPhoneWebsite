using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CellPhoneShop
{
    public class CommentService : BaseService
    {
        public bool PostComment(BinhLuan bl)
        {
            RestRequest request = new RestRequest("comment", Method.POST);            
            string data = Post(request, bl);
            bool result = (bool)DeserializeObject(data, typeof(bool));

            return result;
        }

        public ListCommentModel GetComments(int id, int offset, int count)
        {
            RestRequest request = new RestRequest("comment/{id}", Method.GET);
            request.AddParameter("offset", offset);
            request.AddParameter("count", count);
            request.AddUrlSegment("id", id.ToString());
            string data = Get(request);
            ListCommentModel result = (ListCommentModel)DeserializeObject(data, typeof(ListCommentModel));

            return result;
        }
    }
}