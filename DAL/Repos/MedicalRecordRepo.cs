using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MedicalRecordRepo : Repo, IRepo<MedicalRecord, int, bool>
    {
        public bool Create(MedicalRecord obj)
        {
            db.MedicalRecords.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.MedicalRecords.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public MedicalRecord Get(int id)
        {
            return db.MedicalRecords.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public List<MedicalRecord> Get()
        {
            return db.MedicalRecords.Where(p => p.IsDeleted == false).ToList();
        }

        public bool Update(MedicalRecord obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false; 
            }
            if (obj.Pet != null)
            {
                exobj.Pet = obj.Pet;
            }
            exobj.IsDeleted = false;
            if (obj.Prescriptions != null)
            {
                exobj.Prescriptions = obj.Prescriptions;
            }
            if (obj.vaccinations != null)
            {
                exobj.vaccinations = obj.vaccinations;
            }
            return db.SaveChanges() > 0;
        }
    }
}
