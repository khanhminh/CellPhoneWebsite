using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Configuration;

namespace CellPhoneShop
{
    public class AccountService : BaseService
    {
        //protected string access_token = ConfigurationManager.AppSettings["access_token"];

        public int CreateAccount(TaiKhoan account)
        {
            RestRequest request = new RestRequest("account", Method.POST);
            string data = Post(request, account);
            int result = (int)DeserializeObject(data, typeof(int));

            return result;
        }

        public TaiKhoan GetAccount(string username)
        {
            RestRequest request = new RestRequest("account", Method.GET);
            request.AddParameter("username", username);
            string data = Get(request);
            TaiKhoan tk = (TaiKhoan)DeserializeObject(data, typeof(TaiKhoan));

            return tk;
        }

        public bool UpdateAccount(TaiKhoan tk)
        {
            RestRequest request = new RestRequest("account", Method.PUT);
            string data = Post(request, tk);
            bool result = (bool)DeserializeObject(data, typeof(bool));

            return result;
        }

        public bool CheckLogin(LoginModel tk)
        {
            RestRequest request = new RestRequest("membership", Method.POST);
            string data = Post(request, tk);
            bool result = (bool)DeserializeObject(data, typeof(bool));

            return result;
        }

        public string GetUsername(string email)
        {
            RestRequest request = new RestRequest("membership", Method.GET);
            request.AddParameter("email", email);
            string data = Get(request);
            string result = (string)DeserializeObject(data, typeof(string));

            return result;
        }

        public bool ChangePassword(UserMembershipModel user)
        {
            RestRequest request = new RestRequest("membership", Method.PUT);
            string data = Post(request, user);
            bool result = (bool)DeserializeObject(data, typeof(bool));

            return result;
        }
    }
}