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
    public class FilterService
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
        public static List<PetDTO> Filter(string keyword)
        {
            var data = DataAccess.FilterData().Filter(keyword);
            return GetMapper().Map<List<PetDTO>>(data);
        }
    }
}
