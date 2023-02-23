using AutoAppo_JosueVa.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoAppo_JosueVa.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public UserRole MyUserRole { get; set; }
        public UserStatus MyStatus { get; set; }
        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyStatus = new UserStatus();
            MyUser = new User();
            MyUserRole = new UserRole();
        }

        public async Task<bool> ValidateLogin(string email, string password)
        {

            if (IsBusy)
            {
                return false;
            }
            IsBusy = true;

            try
            {
                MyUser.Email = email;
                MyUser.LoginPassword = password;

                bool R = await MyUser.ValidateLogin();

                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }

            
        }










    }
}
