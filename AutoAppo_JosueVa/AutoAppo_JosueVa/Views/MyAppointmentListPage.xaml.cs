using AutoAppo_JosueVa.ViewModels;
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
    public partial class MyAppointmentListPage : ContentPage
    {

        UserViewModel userViewModel;

        public MyAppointmentListPage()
        {
            InitializeComponent();
            this.BindingContext = userViewModel = new UserViewModel();
            LoadAppos();
        }


        private async void LoadAppos()
        {
            var list = await userViewModel.GetAppointmentListByUser(Global.GlobalUser.IDUsuario);

            ListItem.ItemsSource = list;
        }

    }
}