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
    public partial class AppoLoginPage : ContentPage
    {

        UserViewModel userViewModel;

        public AppoLoginPage()
        {
            InitializeComponent();
            this.BindingContext = userViewModel = new UserViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {


            if (TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim()))
            {
                if (TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    

                    try
                    {
                        UserDialogs.Instance.ShowLoading("Cargando..");
                        await Task.Delay(2000);
                        bool R = await userViewModel.ValidateLogin(TxtEmail.Text.Trim(), TxtPassword.Text.Trim());

                        if (R)
                        {
                            Global.GlobalUser = await userViewModel.getUserByEmail(TxtEmail.Text);
                            await this.Navigation.PushAsync(new AppoOptionsPage());
                        }
                        else
                        {
                            await DisplayAlert("Upss", "Usuario NO Encontrado", "OK");
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
                    await DisplayAlert("Error","La contraseña esta en blanco","OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "El email esta en blanco", "OK");
            }

            
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
           await this.Navigation.PushAsync(new AppoSignUpPage());
        }
    }
}