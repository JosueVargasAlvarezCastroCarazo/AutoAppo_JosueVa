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

        private void BtnAppointment_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnUserManagement_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnSchedule_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnService_Clicked(object sender, EventArgs e)
        {

        }
    }
}