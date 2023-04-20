using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_JosueVa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppoOptionsPage : ContentPage
    {
        public AppoOptionsPage()
        {
            InitializeComponent();


            LblUser.Text = Global.GlobalUser.Nombre;


            if (Global.GlobalUser.IDRole == 2)
            {
                BtnSchedule.IsVisible = false;
                BtnService.IsVisible = false;
            }

        }

        private async void BtnAppointment_Clicked(object sender, EventArgs e)
        {
           await this.Navigation.PushAsync(new MyAppointmentListPage());
        }

        private async void BtnUserManagement_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new UserManagementPage());
        }

        private void BtnSchedule_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnService_Clicked(object sender, EventArgs e)
        {

        }
    }
}