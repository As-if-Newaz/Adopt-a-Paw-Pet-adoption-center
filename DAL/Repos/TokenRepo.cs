using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
        {
            public Token Create(Token obj)
            {
                db.Tokens.Add(obj);
                 db.SaveChanges();
                 return obj;
            }

            public Token Delete(string id)
            {
                var exobj = Get(id);
                exobj.IsValid = false;
                exobj.ExpiredAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                 db.SaveChanges();
                return exobj;
            }

            public Token Get(string id)
            {
                return db.Tokens.Where(t => t.Key.Equals(id) && t.IsValid == true).FirstOrDefault();
            }

            public List<Token> Get()
            {
                return db.Tokens.Where(p => p.IsValid == true).ToList();
            }

            public Token Update(Token obj)
            {
                var exobj = Get(obj.Key);
                if (exobj == null)
                {
                    return obj;
                }
                if (obj.Key != null)
                {
                    exobj.Key = obj.Key;
                }
                exobj.IsValid = true;
            if (obj.CreatedAt != default(DateTime))
                exobj.CreatedAt = obj.CreatedAt;

            if (obj.ExpiredAt != default(DateTime))
                exobj.ExpiredAt = obj.ExpiredAt;

            if (obj.User != null)
                {
                    exobj.User = obj.User;
                }

                db.SaveChanges();
               
                return obj;
            }
        }
}
