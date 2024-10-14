using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PrescriptionRepo : Repo, IRepo<Prescription, int, bool>
    {
        public bool Create(Prescription obj)
        {
            db.Prescriptions.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.Users.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public Prescription Get(int id)
        {
            return db.Prescriptions.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public List<Prescription> Get()
        {
            return db.Prescriptions.Where(p => p.IsDeleted == false).ToList();

        }
        public bool Update(Prescription obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.DrName))
                exobj.DrName = obj.DrName;

            if (obj.CheckupDate != default(DateTime))
                exobj.CheckupDate = obj.CheckupDate;

            if (!string.IsNullOrEmpty(obj.Remarks))
                exobj.Remarks = obj.Remarks;

            exobj.IsDeleted = false;

            if (obj.MedicalRecord != null)
                exobj.MedicalRecord = obj.MedicalRecord;

            return db.SaveChanges() > 0;
        }
    }
}
