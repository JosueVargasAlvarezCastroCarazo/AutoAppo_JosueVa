using Acr.UserDialogs;
using AutoAppo_JosueVa.Models;
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
	public partial class UserManagementPage : ContentPage
	{
        UserViewModel userViewModel;
        public UserManagementPage ()
		{
			InitializeComponent ();
            this.BindingContext = userViewModel = new UserViewModel();

            TxtEmail.Text = Global.GlobalUser.Correo;
            TxtName.Text = Global.GlobalUser.Nombre;
            TxtPhone.Text = Global.GlobalUser.NumeroTelefono;
            TxtCardId.Text = Global.GlobalUser.Cedula;
            TxtAddress.Text = Global.GlobalUser.Direccion;

        }

        private async void BtnAction_Clicked(object sender, EventArgs e)
        {

            if (
                (TxtEmail.Text != null && !string.IsNullOrEmpty(TxtEmail.Text.Trim())) &&
                (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim())) &&
                (TxtPhone.Text != null && !string.IsNullOrEmpty(TxtPhone.Text.Trim())) &&
                (TxtCardId.Text != null && !string.IsNullOrEmpty(TxtCardId.Text.Trim())) &&
                (TxtAddress.Text != null && !string.IsNullOrEmpty(TxtAddress.Text.Trim()))
                )
            {


                try
                {
                    UserDialogs.Instance.ShowLoading("Cargando..");
                    await Task.Delay(2000);
                    bool R = await userViewModel.UpdateUser(
                        Global.GlobalUser.IDUsuario,
                        TxtEmail.Text.Trim(),
                        Global.GlobalUser.Contrasennia,
                        TxtName.Text.Trim(),
                        TxtPhone.Text.Trim(),
                        TxtCardId.Text.Trim(),
                        TxtAddress.Text.Trim(),
                        Global.GlobalUser.IDRole,
                        Global.GlobalUser.IDEstado
                        );

                    if (R)
                    {

                        /* var respuesta = await DisplayAlert("OK", "Usuario Modificado", "si", "no");
                         * 
                         * if(respuesta){
                         * }
                         * 
                         */

                        await DisplayAlert("OK", "Usuario Modificado", "OK");
                        Global.GlobalUser.Correo = TxtEmail.Text.Trim();
                        Global.GlobalUser.Nombre = TxtName.Text.Trim();
                        Global.GlobalUser.NumeroTelefono = TxtPhone.Text.Trim();
                        Global.GlobalUser.Cedula = TxtCardId.Text.Trim();
                        Global.GlobalUser.Direccion = TxtAddress.Text.Trim();

                        await this.Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Upss", "Usuario NO Modificado", "OK");
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
    }
}