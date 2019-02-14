using AppMovile.Models;
using AppMovile.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMovile.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Country> lands;
        private ApiServices apiService;
        private bool isRefreshing;
        #endregion
        #region Properties
        public ObservableCollection<Country> Lands {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion
        #region Constructor
        public LandsViewModel()
        {
            this.apiService = new ApiServices();
            this.LoadLandsAsync();
        }
        #endregion
        #region Methods
        public async void LoadLandsAsync()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();
            if(!connection.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", connection.Message, "Acceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
          
            var response = await this.apiService.GetList<Country>(
                "http://restcountries.eu", 
                "/rest", 
                "/v2/all");
            if(!response.IsSucces)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", response.Message, "Acceptar");
                return;
              
            }
          
            var list = (List<Country>)response.Result;
            this.lands = new ObservableCollection<Country>(list);
            this.IsRefreshing = false;
        }
        #endregion
        #region Commands
        private ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLandsAsync);
            }
        }
        #endregion
    }
}
