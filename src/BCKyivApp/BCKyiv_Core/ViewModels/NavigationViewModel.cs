using BCKyivApp.Core.Models;
using BCKyivApp.Core.ViewModels.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BCKyivApp.Core.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationViewModel
    {
        
        private NavigationLinkModel _currentNavigationLink;
        public NavigationLinkModel CurrentNavigationLink
        {
            get { return _currentNavigationLink; }
            set
            {
                _currentNavigationLink = value;
                UpdateSelectedLink(CurrentNavigationLink);
                RaisePropertyChanged(nameof(CurrentNavigationLink));
            }
        }

        public ObservableCollection<NavigationLinkModel> NavigationLinks { get; set; }

        public NavigationViewModel()
        {
            NavigationLinks = new ObservableCollection<NavigationLinkModel>
            {
                new NavigationLinkModel
                {
                    Name = "Map",
                    ViewName = "MapView",
                    IsSelected = false,
                    ImageSource = ""
                },
                new NavigationLinkModel
                {
                    Name = "Contacts",
                    ViewName = "ContactsView",
                    IsSelected = false,
                    ImageSource = ""
                },
                new NavigationLinkModel
                {
                    Name = "Centres",
                    ViewName = "CentresView",
                    IsSelected = false,
                    ImageSource = ""
                }
            };
        }

        private void UpdateSelectedLink(NavigationLinkModel obj)
        {
            foreach (var navigationLink in NavigationLinks)
                navigationLink.IsSelected = false;

            var navigationLinkModel = NavigationLinks.FirstOrDefault(model => model == obj);
            if (navigationLinkModel == null)
                return;

            navigationLinkModel.IsSelected = true;
        }
    }
}
