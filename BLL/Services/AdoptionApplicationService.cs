using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdoptionApplicationService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdoptionApplication, AdoptionApplicationDTO>();
                cfg.CreateMap<AdoptionApplicationDTO, AdoptionApplication>();
            });
            return new Mapper(config);
        }

        public static bool Create(AdoptionApplicationDTO obj)
        {
            obj.ApplicationDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            obj.ApprovalStatus = "Pending";
            obj.IsDeleted = false;
            var data = GetMapper().Map<AdoptionApplication>(obj);
            return DataAccess.AdoptionApplicationData().Create(data);
        }

        public static List<AdoptionApplicationDTO> Get()
        {
            var data = DataAccess.AdoptionApplicationData().Get();
            return GetMapper().Map<List<AdoptionApplicationDTO>>(data);

        }
        public static AdoptionApplicationDTO Get(int id)
        {
            var data = DataAccess.AdoptionApplicationData().Get(id);
            return GetMapper().Map<AdoptionApplicationDTO>(data);
        }

        public static bool Update(AdoptionApplicationDTO obj)
        {
            var data = GetMapper().Map<AdoptionApplication>(obj);
            return DataAccess.AdoptionApplicationData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.AdoptionApplicationData().Delete(id);

        }


    }
}
