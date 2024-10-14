using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PetRepo : Repo, IRepo<Pet, int, bool>, SRepo<string, List<Pet>>, FRepo<string, List<Pet>>
    {
        public bool Create(Pet obj)
        {
            db.Pets.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.Pets.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public List<Pet> Filter(string attr)
        {
            return db.Pets.Where(p => p.IsDeleted == false && (p.Age.ToString() == attr || p.Breed == attr || p.Location == attr)).ToList();
        }

        public Pet Get(int id)
        {
            return db.Pets.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public List<Pet> Get()
        {
            return db.Pets.Where(p => p.IsDeleted == false).ToList();
        }

        public List<Pet> Search(string str)
        {
            return db.Pets.Where(p => p.IsDeleted == false && (p.Breed.Contains(str) || p.Location.Contains(str))).ToList();
        }

        public bool Update(Pet obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false; 
            }

            
            if (!string.IsNullOrEmpty(obj.Name))
                exobj.Name = obj.Name;

            if (!string.IsNullOrEmpty(obj.Type))
                exobj.Type = obj.Type;

            if (!string.IsNullOrEmpty(obj.Breed))
                exobj.Breed = obj.Breed;

            if (!string.IsNullOrEmpty(obj.Description))
                exobj.Description = obj.Description;

            if (!string.IsNullOrEmpty(obj.Location))
                exobj.Location = obj.Location;

            
            if (obj.Age != default(int))
                exobj.Age = obj.Age;

            exobj.IsAvailable = obj.IsAvailable;

            exobj.IsDeleted = false;

            if (obj.DatePosted != default(DateTime))
                exobj.DatePosted = obj.DatePosted;

            if (obj.DateAdopted != default(DateTime))
                exobj.DateAdopted = obj.DateAdopted;


            if (obj.AdoptionApplications != null)
            {

                exobj.AdoptionApplications.Clear();
                foreach (var application in obj.AdoptionApplications)
                {
                    exobj.AdoptionApplications.Add(application);
                }
            }

            if (obj.User != null)
                exobj.User = obj.User;

            return db.SaveChanges() > 0;
        }
    }
}
