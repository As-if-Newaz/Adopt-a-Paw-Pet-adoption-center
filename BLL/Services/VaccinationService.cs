using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VaccinationService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vaccination, VaccinationDTO>();
                cfg.CreateMap<VaccinationDTO, Vaccination>();
            });
            return new Mapper(config);
        }

        public static bool Create(VaccinationDTO obj)
        {
            obj.IsDeleted = false;  
            var data = GetMapper().Map<Vaccination>(obj);
            return DataAccess.VaccinationData().Create(data);
        }

        public static List<VaccinationDTO> Get()
        {
            var data = DataAccess.VaccinationData().Get();
            return GetMapper().Map<List<VaccinationDTO>>(data);

        }
        public static VaccinationDTO Get(int id)
        {
            var data = DataAccess.VaccinationData().Get(id);
            return GetMapper().Map<VaccinationDTO>(data);
        }

        public static bool Update(VaccinationDTO obj)
        {
            var data = GetMapper().Map<Vaccination>(obj);
            return DataAccess.VaccinationData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.VaccinationData().Delete(id);

        }
    }
}
