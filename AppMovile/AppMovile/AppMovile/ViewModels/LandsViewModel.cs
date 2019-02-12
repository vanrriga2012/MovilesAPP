using AppMovile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppMovile.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Country> lands;
        #endregion
        #region Properties
        public ObservableCollection<Country> Lands {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        #endregion
        #region Constructor
        public LandsViewModel()
        {
            this.LoadLands();
        }
        #endregion
        #region Methods
        public void LoadLands()
        {

        }
        #endregion
    }
}
