using Acr.UserDialogs;
using AutoAppo_JosueVa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAppo_JosueVa.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_JosueVa.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppoSignUpPage : ContentPage
    {

        UserViewModel userViewModel;

        public AppoSignUpPage()
        {
            InitializeComponent();
            this.BindingContext = userViewModel = new UserViewModel();
            LoadUserRoles();
        }

        public async void LoadUserRoles()
        {
            PckrUserRole.ItemsSource = await userViewModel.GetUserRoles();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
           
            if (
                (TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim())) || 
                (TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim())) ||
                (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim())) ||
                (TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim())) ||
                (TxtCardId.Text != null && !string.IsNullOrEmpty(TxtCardId.Text.Trim())) ||
                (TxtAddress.Text != null && !string.IsNullOrEmpty(TxtAddress.Text.Trim())) 
                )
            {


                try
                {
                    UserDialogs.Instance.ShowLoading("Cargando..");
                    await Task.Delay(2000);
                    bool R = await userViewModel.AddUser(
                        TxtEmail.Text.Trim(),
                        TxtPassword.Text.Trim(),
                        TxtName.Text.Trim(),
                        TxtPhone.Text.Trim(),
                        TxtCardId.Text.Trim(),
                        TxtAddress.Text.Trim(),
                        (PckrUserRole.SelectedItem as UserRole).UserRoleId
                        );

                    if (R)
                    {
                        await DisplayAlert("OK", "Usuario Guardado", "OK");
                        await this.Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Upss", "Usuario NO Guardado", "OK");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }

            }
            else
            {
                await DisplayAlert("Error", "Debe ingresar todos los datos", "OK");
            }
           
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
           await this.Navigation.PopAsync();
        }
    }
}