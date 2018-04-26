using BCKyivApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BCKyivApp.Data.Storages.Interfaces
{
    public interface ICentreStorage
    {
        List<Centre> GetAll();

        void Save(Centre centre);
    }
}
