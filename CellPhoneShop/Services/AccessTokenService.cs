using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using DotNetOpenAuth.OAuth2;

namespace CellPhoneShop
{
    public class AccessTokenService
    {
        public void UpdateToken()
        {
            var state = GetAccessToken();
            Save(state.AccessToken);
        }

        private void Save(string date)
        {
            Configuration connectionConfiguration = WebConfigurationManager.OpenWebConfiguration("~");
            connectionConfiguration.AppSettings.Settings["access_token"].Value = date;
            connectionConfiguration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private static IAuthorizationState GetAccessToken()
        {

            var authorizationServer = new AuthorizationServerDescription
            {
                TokenEndpoint = new Uri(ConfigurationManager.AppSettings["Link_AccessToken"]),
                ProtocolVersion = ProtocolVersion.V20

            };
            var client = new WebServerClient(authorizationServer, ConfigurationManager.AppSettings["LinkHost"]);
            client.ClientIdentifier = ConfigurationManager.AppSettings["AppId"];
            client.ClientSecret = ConfigurationManager.AppSettings["AppSecret"];

            var state = client.GetClientAccessToken(null);
            return state;
        }
    }

    public class OAuthHttpClient : HttpClient
    {
        public OAuthHttpClient(string accessToken)
            : base(new OAuthTokenHandler(accessToken))
        {

        }

        class OAuthTokenHandler : MessageProcessingHandler
        {
            string _accessToken;
            public OAuthTokenHandler(string accessToken)
                : base(new HttpClientHandler())
            {
                _accessToken = accessToken;

            }
            protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                return request;
            }

            protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, System.Threading.CancellationToken cancellationToken)
            {
                return response;
            }
        }
    }
}