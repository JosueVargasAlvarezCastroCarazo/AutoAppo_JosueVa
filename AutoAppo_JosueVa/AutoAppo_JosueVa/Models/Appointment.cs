using AutoAppo_JosueVa.Services;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoAppo_JosueVa.Models
{
    public class Appointment
    {

        public int AppointmentId { get; set; }
        public DateTime AppoDate { get; set; }
        public int AppoStart { get; set; }
        public int AppoEnd { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Notes { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public int ScheduleId { get; set; }
        public int AppoStatusId { get; set; }

        public virtual AppointmentStatus AppoStatus { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
        public virtual User User { get; set; } = null!;


        public RestRequest Request { get; set; }


        public async Task<ObservableCollection<Appointment>> GetAppointmentListByUser(int id)
        {
            try
            {
                string RouteSufix = string.Format("Appointments/GetAppointmentListByUser?id={0}", id);
                string URL = APIConnection.ProductionUrlPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                Request.AddHeader(APIConnection.ApiKeyName, APIConnection.ApiKey);
                Request.AddHeader(APIConnection.ContentType, APIConnection.MimeType);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<Appointment>>(response.Content);
                }
                else
                {
                    return new ObservableCollection<Appointment>();
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
