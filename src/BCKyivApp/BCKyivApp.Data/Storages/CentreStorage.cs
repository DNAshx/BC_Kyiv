using BCKyivApp.Data.Storages.Interfaces;
using BCKyivApp.Data;
using BCKyivApp.Data.Entities;
using GlauxSoft.Sachware.TabletPrototype.Storage.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCKyivApp.Data.Storages
{
    public class CentreStorage : ICentreStorage
    {
        public List<Centre> GetAll()
        {
            using (var dbContext = new StorageContext())
            {
                return dbContext.Centres.Include(c => c.Contacts).ToList();
            }
        }

        public void Save(Centre centre)
        {
            using (var dbContext = new StorageContext())
            {
                dbContext.Centres.Add(centre);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int centreId)
        {
            using (var dbContext = new StorageContext())
            {
                var centreToDelete = GetCentre(dbContext, centreId, false);
                dbContext.Remove(centreToDelete);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get Centre entity or throw exception
        /// </summary>
        /// <param name="context">Storage context</param>
        /// <param name="centreId">target document id</param>
        /// <returns>Centre or throws EntityNotFoundException&lt;Centre&gt;</returns>
        private Centre GetCentre(StorageContext context, int centreId, bool throwNotFoundException = true)
        {
            var documentEntry = context.Centres.Include(d => d.Contacts).SingleOrDefault(d => d.Id == centreId);

            if (documentEntry == null && throwNotFoundException)
            {
                throw new EntityNotFoundException<Centre>(centreId);
            }

            return documentEntry;
        }
    }
}
