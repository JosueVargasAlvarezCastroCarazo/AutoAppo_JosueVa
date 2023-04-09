using Acr.UserDialogs;
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
    public partial class AppoRecoverPasword : ContentPage
    {
        UserViewModel userViewModel;
        public AppoRecoverPasword()
        {
            InitializeComponent();
            this.BindingContext = userViewModel = new UserViewModel();
        }

        private async void BtnAction_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                UserDialogs.Instance.ShowLoading("Cargando..");
                var R = await userViewModel.AddCode(TxtEmail.Text.Trim());
                UserDialogs.Instance.HideLoading();
                if (R)
                {

                }
                else
                {
                    await DisplayAlert("Upss", "Problema en los servicios", "OK");
                }

            }
        }

        private void BtnActionChangePassword_Clicked(object sender, EventArgs e)
        {

        }
    }
}