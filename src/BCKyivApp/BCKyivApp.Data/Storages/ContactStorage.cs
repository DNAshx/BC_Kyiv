using BCKyivApp.Data.Storages.Interfaces;
using BCKyivApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace BCKyivApp.Data.Storages
{
    public class ContactStorage : IContactStorage
    {
        public List<Contact> GetByCentre(int centreId)
        {
            using (var dbContext = new StorageContext())
            {
                return dbContext.Contacts.Where(c => c.CentreId == centreId).Include(c => c.Centre).ToList();
            }
        }
    }
}
