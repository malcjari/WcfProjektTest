using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfProjektTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void deleteCase(int id)
        {
            using(DbModel db = new DbModel())
            {
                Cases c = new Cases();
                c = db.Cases.Find(id);
                db.Cases.Remove(c);
                db.SaveChanges();
            }
        }

        public void addCase(CaseData iCase)
        {
            using (DbModel db = new DbModel())
            {
                Cases tempCase = new Cases();

                tempCase.date = iCase.date;
                tempCase.lat = iCase.lat;
                tempCase.lng = iCase.lng;
                tempCase.description = iCase.description;
                tempCase.isActive = iCase.isActive;
                tempCase.contact_phone = iCase.contact_phone;
                tempCase.contact_email = iCase.contact_email;
                tempCase.category = iCase.category;

                db.Cases.Add(tempCase);
                db.SaveChanges();
            }
        }

        
        public List<CaseData> getAllCases()
        {
            List<CaseData> returnList = new List<CaseData>();

            using(DbModel db = new DbModel())
            {
                var tempList = db.Cases.ToList();

                foreach (var item in tempList)
                {
                    CaseData c = new CaseData();

                    c.id = item.id;
                    c.date = item.date;
                    c.lat = item.lat;
                    c.lng = item.lng;
                    c.description = item.description;
                    c.isActive = item.isActive;
                    c.contact_phone = item.contact_phone;
                    c.contact_email = item.contact_email;
                    c.category = item.category;

                    returnList.Add(c);

                }
            }

            return returnList;
        }

        public void editCase(int id, int category, string description, bool isActive)
        {
            using(DbModel db = new DbModel())
            {
                Cases c = db.Cases.Find(id);
                c.category = category;
                c.description = description;
                c.isActive = isActive;

                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool logIn(string username, string password)
        {
            using(DbModel db = new DbModel())
            {
                bool logInOk = false;

                var userList = db.Users.ToList();

                foreach (var item in userList)
                {
                    if(username == item.username)
                    {
                        logInOk = true;
                    }
                }

                return logInOk;
            }
        }
    }
}
