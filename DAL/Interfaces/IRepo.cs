using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS , ID , RETURN>
    {
        RETURN Create(CLASS obj);

        List<CLASS> Get();

        CLASS Get(ID id);

        RETURN Update(CLASS obj);

        RETURN Delete(ID id);   
    }
}
