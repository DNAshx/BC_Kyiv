using BCKyivApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCKyivApp.Core
{
    public static class Test
    {
        private static void AddCentres(StorageContext db)
        {
            var centres = db.Centres;
            centres.Add(new Data.Entities.Centre()
            {
                City = "Kyiv",
                Country = "Ukraine",
                Location = "50.452719,30.611214"
            });
            db.SaveChanges();
        }

        private static void AddContacts(StorageContext db)
        {
            var centres = db.Centres;
            var contacts = db.Contacts;

            contacts.Add(new Data.Entities.Contact()
            {
                FirstName = "Alexey",
                LastName = "Kucher",
                Email = "alexey.kucher@gmail.com",
                CentreId = centres.First<Data.Entities.Centre>().Id
            });
        }
        
        public static void AddData()
        {
            using (var db = new StorageContext())
            {
                AddCentres(db);
            }
        }
    }
}
