using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCKyivApp.Core.Models
{
    public class NavigationLinkModel : BindableBase
    {
        private string _imageSource;
        private bool _isSelected;
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }

        public string ImageSource

        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                RaisePropertyChanged(nameof(ImageSource));
            }
        }

        private string _viewName;
        public string ViewName
        {
            get { return _viewName; }
            set
            {
                _viewName = value;
                RaisePropertyChanged(nameof(ViewName));
            }
        }
    }
}