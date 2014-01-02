using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;

namespace CellPhoneShop
{
    public class ProductService : BaseService
    {
        public NewProductModel GetNewProduct(int offset, int count)
        {
            RestRequest request = new RestRequest("newproduct", Method.GET);
            request.AddParameter("offset", offset);
            request.AddParameter("count", count);
            string data = Get(request);
            NewProductModel result = (NewProductModel)DeserializeObject(data, typeof(NewProductModel));

            return result;
        }

        public SanPham GetDetailProduct(int id)
        {
            RestRequest request = new RestRequest("product/{id}", Method.GET);
            request.AddParameter("detail", true);
            request.AddUrlSegment("id", id.ToString());
            string data = Get(request);
            SanPham sp = (SanPham)DeserializeObject(data, typeof(SanPham));

            return sp;
        }

        public List<SanPham> GetRelativeProduct(int id, int count)
        {
            RestRequest request = new RestRequest("relativeproduct/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            request.AddParameter("count", count);
            string data = Get(request);
            List<SanPham> result = (List<SanPham>)DeserializeObject(data, typeof(List<SanPham>));

            return result;
        }

        public SanPham GetProduct(int id)
        {
            RestRequest request = new RestRequest("product/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            string data = Get(request);
            SanPham sp = (SanPham)DeserializeObject(data, typeof(SanPham));

            return sp;
        }

        //public List<SanPham> GetProducts(int offset, int count)
        //{
        //    RestRequest request = new RestRequest("product", Method.GET);
        //    request.AddParameter("offset", offset);
        //    request.AddParameter("count", count);
        //    string data = Get(request);
        //    List<SanPham> result = (List<SanPham>)DeserializeObject(data, typeof(List<SanPham>));

        //    return result;
        //}

        public ListProductModel GetProducts(FilterModel filter)
        {
            RestRequest request = new RestRequest("filter", Method.POST);

            string data = Post(request, filter);
            ListProductModel result = (ListProductModel)DeserializeObject(data, typeof(ListProductModel));

            return result;
        }

        public List<SoSanhGia> GetPriceCompare(int id)
        {
            RestRequest request = new RestRequest("PriceCompare/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            string data = Get(request);
            List<SoSanhGia> result = (List<SoSanhGia>)DeserializeObject(data, typeof(List<SoSanhGia>));

            return result;
        }
    }
}