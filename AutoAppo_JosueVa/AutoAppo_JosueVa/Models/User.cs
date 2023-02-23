using AutoAppo_JosueVa.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoAppo_JosueVa.Models
{
    public class User
    {
        public User()
        {
           
        }

        public RestRequest Request { get; set; }
        const string MimeType = "application/json";
        const string ContentType = "Content-Type";

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LoginPassword { get; set; }
        public string CardId { get; set; }
        public string Address { get; set; }
        public int UserRoleId { get; set; }
        public int UserStatusId { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual UserStatus UserStatus { get; set; }


        public async Task<bool> ValidateLogin()
        {
            try
            {
                string RouteSufix = string.Format("users/ValidateUserLogin?email={0}&password={1}", Email, LoginPassword);
                string URL = APIConnection.ProductionUrlPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL,Method.Get);

                Request.AddHeader(APIConnection.ApiKeyName,APIConnection.ApiKey);
                Request.AddHeader(ContentType, MimeType);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
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
