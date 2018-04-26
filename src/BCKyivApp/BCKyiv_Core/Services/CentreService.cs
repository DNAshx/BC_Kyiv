using BCKyivApp.Core.Models;
using BCKyivApp.Core.Services.Interfaces;
using BCKyivApp.Data.Storages;
using BCKyivApp.Data.Storages.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CentreEntity = BCKyivApp.Data.Entities.Centre;

namespace BCKyivApp.Core.Services
{
    public class CentreService : ICentreService
    {
        private ICentreStorage _centreStorage;

        public CentreService (CentreStorage centreStorage)
        {
            _centreStorage = centreStorage;
        }
        
        public List<Centre> GetAll()
        {
            var result = new List<Centre>();
            _centreStorage.GetAll().ForEach(x => result.Add(Map(x)));

            return result;
        }



        public Centre Map(CentreEntity entity)
        {
            return new Centre
            {
                Id = entity.Id,
                City = entity.City,
                Country = entity.Country,
                Location = entity.Location
            };
        }
    }
}
