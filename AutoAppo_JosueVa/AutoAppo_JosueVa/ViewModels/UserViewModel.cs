using AutoAppo_JosueVa.DTO;
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
        public UserDTO MyUserDTO { get; set; }

        public UserViewModel()
        {
            MyStatus = new UserStatus();
            MyUser = new User();
            MyUserRole = new UserRole();
            MyUserDTO = new UserDTO();
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


        public async Task<bool> AddUser(
            string email, 
            string password, 
            string name, 
            string phone, 
            string identification, 
            string address, 
            int userRole, 
            int UserStatus = 3
            )
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

                MyUser.Name = name;
                MyUser.PhoneNumber = phone;
                MyUser.CardId = identification;
                MyUser.Address = address;

                MyUser.UserRoleId = userRole;
                MyUser.UserStatusId = UserStatus;

                bool R = await MyUser.AddUser();

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

        public async Task<UserDTO> getUserByEmail(
            string email
            )
        {

            if (IsBusy)
            {
                return new UserDTO();
            }
            IsBusy = true;

            try
            {
                MyUserDTO.Correo = email;


                UserDTO R = await MyUserDTO.GetUserByEmail();

                return R;
            }
            catch (Exception)
            {
                return new UserDTO();
                throw;
            }
            finally
            {
                IsBusy = false;
            }


        }


        public async Task<List<UserRole>> GetUserRoles()
        {

            if (IsBusy)
            {
                return new List<UserRole>();
            }
            IsBusy = true;

            try
            {
      
                return await MyUserRole.GetUserRoles();

            }
            catch (Exception)
            {
                return new List<UserRole>();
                throw;
            }
            finally
            {
                IsBusy = false;
            }


        }














    }
}
