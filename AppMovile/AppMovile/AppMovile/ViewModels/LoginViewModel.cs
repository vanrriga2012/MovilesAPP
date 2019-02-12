using AppMovile.Views;
using GalaSoft.MvvmLight.Command;
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
            get { return this.email; }
            set { SetValue(ref this.email, value); }

        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunnig {
            get { return isRunnig; }
            set { SetValue(ref isRunnig, value); }
        }
        public bool IsEnabled {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }

        public bool IsRemember {
            get;
            set; }


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
                this.Email = string.Empty;
                return;
            }
            isRunnig = false;
            IsEnabled = true;
            this.Password = string.Empty;
            this.Email = string.Empty;
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            #endregion
            #region Constructors
        }
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.isEnabled = true;
            this.Email = "paul_barriga@hotmail.com";
            this.password = "1234";

        }
        #endregion
    }
}
