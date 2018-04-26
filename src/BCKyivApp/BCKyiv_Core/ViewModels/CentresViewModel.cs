using BCKyivApp.Core.Models;
using BCKyivApp.Core.Services;
using BCKyivApp.Core.Services.Interfaces;
using BCKyivApp.Core.ViewModels.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BCKyivApp.Core.ViewModels
{
    public class CentresViewModel : BindableBase, ICentresViewModel
    {
        private ICentreService _centreService;

        public string TestText => "Test";

        private ObservableCollection<Centre> _centres;
        public ObservableCollection<Centre> Centres
        {
            get { return _centres; }
            set
            {
                _centres = value;
                RaisePropertyChanged(nameof(Centres));
            }
        }

        public CentresViewModel(CentreService centreService)
        {
            _centreService = centreService;
            Test.AddData();
            Initialize();
        }

        private void Initialize()
        {
            Centres = new ObservableCollection<Centre>(_centreService.GetAll());
        }
        
    }
}
