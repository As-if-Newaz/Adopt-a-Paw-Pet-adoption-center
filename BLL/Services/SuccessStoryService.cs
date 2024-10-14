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
    public class SuccessStoryService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SuccessStory, SuccessStoryDTO>();
                cfg.CreateMap<SuccessStoryDTO, SuccessStory>();
            });
            return new Mapper(config);
        }

        public static bool Create(SuccessStoryDTO obj)
        {
            obj.IsDeleted = false;
            var data = GetMapper().Map<SuccessStory>(obj);
            return DataAccess.SuccessStoryData().Create(data);
        }

        public static List<SuccessStoryDTO> Get()
        {
            var data = DataAccess.SuccessStoryData().Get();
            return GetMapper().Map<List<SuccessStoryDTO>>(data);

        }
        public static SuccessStoryDTO Get(int id)
        {
            var data = DataAccess.SuccessStoryData().Get(id);
            return GetMapper().Map<SuccessStoryDTO>(data);
        }

        public static bool Update(SuccessStoryDTO obj)
        {
            var data = GetMapper().Map<SuccessStory>(obj);
            return DataAccess.SuccessStoryData().Update(data);

        }

        public static bool Delete(int id)
        {
            return DataAccess.SuccessStoryData().Delete(id);

        }
    }
}
