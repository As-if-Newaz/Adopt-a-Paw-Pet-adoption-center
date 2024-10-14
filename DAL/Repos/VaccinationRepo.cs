using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class VaccinationRepo : Repo, IRepo<Vaccination, int, bool>
    {
        public bool Create(Vaccination obj)
        {
            db.Vaccinations.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.Vaccinations.Find(id);
            exobj.IsDeleted = true; 
            return db.SaveChanges() > 0;
        }

        public Vaccination Get(int id)
        {
            return db.Vaccinations.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public List<Vaccination> Get()
        {
            return db.Vaccinations.Where(p => p.IsDeleted == false).ToList();
        }

        public bool Update(Vaccination obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.VaccineName))
                exobj.VaccineName = obj.VaccineName;

            if (obj.VaccineDate != default(DateTime))
                exobj.VaccineDate = obj.VaccineDate;

            exobj.IsDeleted = obj.IsDeleted;

            if (obj.MedicalRecord != null)
                exobj.MedicalRecord = obj.MedicalRecord;

            return db.SaveChanges() > 0;
        }
    }
}
