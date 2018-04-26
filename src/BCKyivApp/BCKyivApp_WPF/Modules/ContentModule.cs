using BCKyivApp.Core.Services;
using BCKyivApp.Core.Services.Interfaces;
using BCKyivApp.Core.ViewModels;
using BCKyivApp.Core.ViewModels.Interfaces;
using BCKyivApp.Data.Storages;
using BCKyivApp.Data.Storages.Interfaces;
using BCKyivApp.WPF.Resources;
using BCKyivApp.WPF.Service;
using BCKyivApp.WPF.Service.Interfaces;
using BCKyivApp.WPF.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCKyivApp.WPF.Modules
{
    public class ContentModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public ContentModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(Strings.ContentRegion, typeof(MapCentresView));

            _container.RegisterType<IDialogService, DialogService>();
            _container.RegisterType<ICentreService, CentreService>();

            _container.RegisterType<ICentreStorage, CentreStorage>();

            _container.RegisterTypeForNavigation<MapCentresView>();
            _container.RegisterTypeForNavigation<MapView>();
            _container.RegisterTypeForNavigation<NavigationView>();
            _container.RegisterTypeForNavigation<CentresView>();
            _container.RegisterTypeForNavigation<ContactsView>();
            
            _container.RegisterType<INavigationViewModel, NavigationViewModel>();
            _container.RegisterType<IMapViewModel, MapViewModel>();
            _container.RegisterType<IContactsViewModel, ContactsViewModel>();
            _container.RegisterType<ICentresViewModel, CentresViewModel>();
        }
    }
}