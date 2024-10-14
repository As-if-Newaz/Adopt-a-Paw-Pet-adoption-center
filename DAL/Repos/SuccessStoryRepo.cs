using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SuccessStoryRepo : Repo, IRepo<SuccessStory, int, bool>
    {
        public bool Create(SuccessStory obj)
        {
            db.SuccessStories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = db.SuccessStories.Find(id);
            exobj.IsDeleted = true;
            return db.SaveChanges() > 0;

        }

        public SuccessStory Get(int id)
        {
            return db.SuccessStories.Where(v => v.Id == id && v.IsDeleted == false).FirstOrDefault();
        }

        public List<SuccessStory> Get()
        {
            return db.SuccessStories.Where(p => p.IsDeleted == false).ToList();
        }

        public bool Update(SuccessStory obj)
        {
            var exobj = Get(obj.Id);
            if (exobj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.Title))
                exobj.Title = obj.Title;

            if (!string.IsNullOrEmpty(obj.Story))
                exobj.Story = obj.Story;

            if (obj.AdoptionDate != default(DateTime))
                exobj.AdoptionDate = obj.AdoptionDate;

            exobj.IsDeleted = false;

            if (obj.Pet != null)
                exobj.Pet = obj.Pet;

            if (obj.User != null)
                exobj.User = obj.User;

            return db.SaveChanges() > 0;
        }
    }
}
