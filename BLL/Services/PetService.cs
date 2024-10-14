using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace BLL.Services
{
    public class PetService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pet, PetDTO>();
                cfg.CreateMap<PetDTO, Pet>();
            });
            return new Mapper(config);
        }

        public static bool Create(PetDTO obj)
        {
            obj.IsDeleted = false;
            obj.DatePosted = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            var data = GetMapper().Map<Pet>(obj);
            return DataAccess.PetData().Create(data);
        }

        public static List<PetDTO> Get()
        {
            var data = DataAccess.PetData().Get();

            return GetMapper().Map<List<PetDTO>>(data);

        }
        public static PetDTO Get(int id)
        {
            var data = DataAccess.PetData().Get(id);
            return GetMapper().Map<PetDTO>(data);
        }

        public static bool Update(PetDTO obj)
        {
            var data = GetMapper().Map<Pet>(obj);
            return DataAccess.PetData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.PetData().Delete(id);

        }
    }
}
