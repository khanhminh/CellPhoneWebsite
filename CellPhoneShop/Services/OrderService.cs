using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CellPhoneShop
{
    public class OrderService : BaseService
    {
        public List<PhuongThucGiaoHang> GetListPTGH()
        {
            RestRequest request = new RestRequest("DeliveryMode", Method.GET);
            string data = Get(request);
            List<PhuongThucGiaoHang> result = (List<PhuongThucGiaoHang>)DeserializeObject(data, typeof(List<PhuongThucGiaoHang>));

            return result;
        }

        public List<PhuongThucThanhToan> GetListPTTT()
        {
            RestRequest request = new RestRequest("PaymentMode", Method.GET);
            string data = Get(request);
            List<PhuongThucThanhToan> result = (List<PhuongThucThanhToan>)DeserializeObject(data, typeof(List<PhuongThucThanhToan>));

            return result;
        }

        public int CreateOrder(DonDatHang order)
        {
            RestRequest request = new RestRequest("Order", Method.POST);
            string data = Post(request, order);
            int result = (int)DeserializeObject(data, typeof(int));

            return result;
        }

        public ListOrderModel GetListOrder(string username, int offset, int count)
        {
            RestRequest request = new RestRequest("order", Method.GET);
            request.AddParameter("username", username);
            request.AddParameter("offset", offset);
            request.AddParameter("count", count);
            string data = Get(request);
            ListOrderModel result = (ListOrderModel)DeserializeObject(data, typeof(ListOrderModel));

            return result;
        }

        public DonDatHang GetOrder(int id)
        {
            RestRequest request = new RestRequest("order/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            string data = Get(request);
            DonDatHang result = (DonDatHang)DeserializeObject(data, typeof(DonDatHang));

            return result;
        }

        public bool DeleteOrder(int id)
        {
            RestRequest request = new RestRequest("order/{id}", Method.DELETE);
            request.AddUrlSegment("id", id.ToString());
            string data = Get(request);
            bool result = (bool)DeserializeObject(data, typeof(bool));

            return result;
        }
    }
}