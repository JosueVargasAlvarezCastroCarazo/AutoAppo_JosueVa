using AutoAppo_JosueVa.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AutoAppo_JosueVa.DTO
{
    public class UserDTO
    {
        public RestRequest Request { get; set; }
        public UserDTO()
        {

        }

        public UserDTO(int iDUsuario, string nombre, string correo, string numeroTelefono, string contrasennia, string? cedula, string? direccion, int iDRole, int iDEstado, string role, string estado)
        {
            IDUsuario = iDUsuario;
            Nombre = nombre;
            Correo = correo;
            NumeroTelefono = numeroTelefono;
            Contrasennia = contrasennia;
            Cedula = cedula;
            Direccion = direccion;
            IDRole = iDRole;
            IDEstado = iDEstado;
            Role = role;
            Estado = estado;
        }

        public int IDUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string NumeroTelefono { get; set; } = null!;
        public string Contrasennia { get; set; } = null!;
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }
        public int IDRole { get; set; }
        public int IDEstado { get; set; }

        public string Role { get; set; } = null!;
        public string Estado { get; set; } = null!;



        public async Task<UserDTO> GetUserByEmail()
        {
            try
            {
                string RouteSufix = string.Format("users/GetUserByEmail/{0}", Correo);
                string URL = APIConnection.ProductionUrlPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                Request.AddHeader(APIConnection.ApiKeyName, APIConnection.ApiKey);
                Request.AddHeader(APIConnection.ContentType, APIConnection.MimeType);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);
                    return list[0];
                }
                else
                {
                    return new UserDTO();
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
                throw;
            }
        }





        public async Task<bool> UpdateUser()
        {
            try
            {
                string RouteSufix = string.Format("users/{0}",IDUsuario);
                string URL = APIConnection.ProductionUrlPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Put);

                Request.AddHeader(APIConnection.ApiKeyName, APIConnection.ApiKey);
                Request.AddHeader(APIConnection.ContentType, APIConnection.MimeType);

                string Serialize = JsonConvert.SerializeObject(this);

                Request.AddBody(Serialize, APIConnection.MimeType);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.NoContent)
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
