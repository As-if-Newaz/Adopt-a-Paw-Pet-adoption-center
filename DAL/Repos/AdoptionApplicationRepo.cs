using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdoptionApplicationRepo : Repo, IRepo<AdoptionApplication, int, bool>
    {
        public bool Create(AdoptionApplication obj)
        {
            db.AdoptionApplications.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.AdoptionApplications.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public AdoptionApplication Get(int id)
        {
            return db.AdoptionApplications.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public List<AdoptionApplication> Get()
        {
            return db.AdoptionApplications.Where(p => p.IsDeleted == false).ToList();
        }

        public bool Update(AdoptionApplication obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false; 
            }
           
            if (obj.Description != null)
                exobj.Description = obj.Description;

            if (obj.ApplicationDate != default(DateTime))
                exobj.ApplicationDate = obj.ApplicationDate;

            if (obj.ApprovalStatus != null)
                exobj.ApprovalStatus = obj.ApprovalStatus;

            exobj.IsDeleted = false;

            if (obj.ApprovalDate.HasValue)
                exobj.ApprovalDate = obj.ApprovalDate;

            if (obj.User != null)
                exobj.User = obj.User;

            if (obj.Pet != null)
                exobj.Pet = obj.Pet;



            return db.SaveChanges() > 0;
        }
    }
}
