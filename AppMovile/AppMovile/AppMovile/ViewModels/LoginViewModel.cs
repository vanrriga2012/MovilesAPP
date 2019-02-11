using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMovile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
      

        #region Attributes
        private string email;
        private string password;
        private bool isRunnig;
        private bool isEnabled;
        #endregion
        #region Properties
        public string Email
        {
            get;
            set;

        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Password)));
                }
            }
        }
        public bool IsRunnig {
            get
            {
                return isRunnig;
            }
            set
            {
                if (this.isRunnig != value)
                {
                    this.isRunnig = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsRunnig)));
                }
            }
        }
        public bool IsEnabled {
            get
            {
                return isEnabled;
            }
            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsEnabled)));
                }
            }
        }
        public bool IsRemember {
            get
            {
                return IsRemember;
            }
            set
            {
                if (this.IsRemember != value)
                {
                    this.IsRemember = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsRemember)));
                }
            }
        }
      
      
       
        #endregion
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginAsync);
            }
        }

        private async void LoginAsync()
        {

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe Ingresar El correo", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe Ingresar su Contraseña", "Aceptar");
                return;
            }
            this.IsEnabled = false;
            this.IsRunnig = true;
            if (this.Email != "paul_barriga@hotmail.com" || this.Password != "1234")
            {
                this.IsEnabled = true;
                this.IsRunnig = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Email o Contraseña Incorrecta", "Aceptar");
                this.Password = string.Empty;
                return;
            }
            else
            {
                this.IsEnabled = true;
                this.isRunnig = false;
                await Application.Current.MainPage.DisplayAlert("Ok", "Login", "Aceptar");
            }

            #endregion
            #region Constructors
        }
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.isEnabled = true;

        }
        #endregion
    }
}
