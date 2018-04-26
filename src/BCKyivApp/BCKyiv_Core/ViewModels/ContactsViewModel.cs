using BCKyivApp.Core.ViewModels.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCKyivApp.Core.ViewModels
{
    public class ContactsViewModel : BindableBase, IContactsViewModel
    {
        public string TestText => "Test";
    }
}
