using AutoAppo_JosueVa.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AutoAppo_JosueVa.Models
{
    public class UserRole
    {

        public RestRequest Request { get; set; }

        public int UserRoleId { get; set; }
        public string UserRoleDescription { get; set; }

        public async Task<List<UserRole>> GetUserRoles()
        {
            try
            {
                string RouteSufix = string.Format("UserRoles");
                string URL = APIConnection.ProductionUrlPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                Request.AddHeader(APIConnection.ApiKeyName, APIConnection.ApiKey);
                Request.AddHeader(APIConnection.ContentType, APIConnection.MimeType);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<List<UserRole>>(response.Content);
                }
                else
                {
                    return new List<UserRole>();
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }

    }
}
