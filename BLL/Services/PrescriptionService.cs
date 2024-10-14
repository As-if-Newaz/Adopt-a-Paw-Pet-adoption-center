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
    public class PrescriptionService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Prescription, PrescriptionDTO>();
                cfg.CreateMap<PrescriptionDTO, Prescription>();
            });
            return new Mapper(config);
        }

        public static bool Create(PrescriptionDTO obj)
        {
            obj.CheckupDate = DateTime.Now;
            obj.IsDeleted = false;
            var data = GetMapper().Map<Prescription>(obj);
            return DataAccess.PrescriptionData().Create(data);
        }

        public static List<PrescriptionDTO> Get()
        {
            var data = DataAccess.PrescriptionData().Get();
            return GetMapper().Map<List<PrescriptionDTO>>(data);

        }
        public static PrescriptionDTO Get(int id)
        {
            var data = DataAccess.PrescriptionData().Get(id);
            return GetMapper().Map<PrescriptionDTO>(data);
        }

        public static bool Update(PrescriptionDTO obj)
        {
            var data = GetMapper().Map<Prescription>(obj);
            return DataAccess.PrescriptionData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.PrescriptionData().Delete(id);

        }
    }
}
