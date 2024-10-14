using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, bool>, IAuth, RegValRepo
    {
        public User Authentication(string email, string password)
        {
            var user = db.Users.SingleOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
            return user;
        }

        public bool Create(User obj)
        {   
            var data = db.Users.Where(v => v.Email.Equals(obj.Email)).FirstOrDefault();

            if (data != null)
            {
                return false;
            }
            db.Users.Add(obj);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var exobj = db.Users.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return db.Users.Where(v => v.Id == id && v.IsDeleted == false && v.Active == true).FirstOrDefault();
        }

        public List<User> Get()
        {
            return db.Users.Where(p => p.IsDeleted == false && p.Active == true).ToList();
        }

        public bool Update(User obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.Name))
                exobj.Name = obj.Name;

            if (!string.IsNullOrEmpty(obj.Email))
                exobj.Email = obj.Email;

            if (!string.IsNullOrEmpty(obj.Password))
                exobj.Password = obj.Password;

            if (!string.IsNullOrEmpty(obj.Role))
                exobj.Role = obj.Role;

            if (!string.IsNullOrEmpty(obj.Address))
                exobj.Address = obj.Address;

            if (!string.IsNullOrEmpty(obj.AuthKey))
                exobj.AuthKey = obj.AuthKey;

            if (obj.Active == true)
                exobj.Active = obj.Active;

            if (!string.IsNullOrEmpty(obj.Phone))
                exobj.Phone = obj.Phone;

            if (obj.RegDate != default(DateTime))
                exobj.RegDate = obj.RegDate;

            exobj.IsDeleted = false;

            if (obj.successStories != null)
            {
                exobj.successStories.Clear();
                foreach (var story in obj.successStories)
                {
                    exobj.successStories.Add(story);
                }
            }

            if (obj.AdoptionApplications != null)
            {
                exobj.AdoptionApplications.Clear();
                foreach (var application in obj.AdoptionApplications)
                {
                    exobj.AdoptionApplications.Add(application);
                }
            }

            if (obj.Pets != null)
            {
                exobj.Pets.Clear();
                foreach (var pet in obj.Pets)
                {
                    exobj.Pets.Add(pet);
                }
            }

            return db.SaveChanges() > 0;
        }

        public bool Validate(string authkey)
        {
            var exobj = db.Users.Where(v => v.AuthKey == authkey && v.IsDeleted == false).FirstOrDefault();

            if (exobj == null)
            {
                return false;
            }

            exobj.Active = true;
            return db.SaveChanges() > 0;
        }
    }
}
