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
    public class MedicalRecordService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MedicalRecord, MedicalRecordDTO>();
                cfg.CreateMap<MedicalRecordDTO, MedicalRecord>();
            });
            return new Mapper(config);
        }

        public static bool Create(MedicalRecordDTO obj)
        {   
            obj.IsDeleted = false;
            var data = GetMapper().Map<MedicalRecord>(obj);
            return DataAccess.MedicalRecordData().Create(data);
        }

        public static List<MedicalRecordDTO> Get()
        {
            var data = DataAccess.MedicalRecordData().Get();
            return GetMapper().Map<List<MedicalRecordDTO>>(data);

        }
        public static MedicalRecordDTO Get(int id)
        {
            var data = DataAccess.MedicalRecordData().Get(id);
            return GetMapper().Map<MedicalRecordDTO>(data);
        }

        public static bool Update(MedicalRecordDTO obj)
        {
            var data = GetMapper().Map<MedicalRecord>(obj);
            return DataAccess.MedicalRecordData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.MedicalRecordData().Delete(id);
        }
    }
}
