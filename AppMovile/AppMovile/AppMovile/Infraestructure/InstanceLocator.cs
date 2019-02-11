using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovile.Infraestructure
{
    using ViewModels;
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion
        #region Contructor
        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
        #endregion

    }
}
