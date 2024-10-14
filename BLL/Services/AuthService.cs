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
    public class AuthService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token, TokenDTO>();
                cfg.CreateMap<TokenDTO, Token>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }
        public static TokenDTO Authentication(string email, string password)
        {
            var data = DataAccess.AuthData().Authentication(email, password);
            
            if (data != null)
            {
                Token t = new Token();
                t.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                var Key = Guid.NewGuid().ToString();
                t.Key = Key.Substring(0, 15); 
                t.UserId = data.Id;
                t.IsValid = true;
                var token = DataAccess.TokenData().Create(t);
                return GetMapper().Map<TokenDTO>(token);
            }
            return null;
        }
        public static bool IsTokenValid(string key)
        {
            var token = DataAccess.TokenData().Get(key);
            if(token != null && token.ExpiredAt == null && token.IsValid == true)
            {

            return true; 
            }
        return false;}

        public static bool LogoutToken(string key)
        {       
            if(DataAccess.TokenData().Get(key) != null)
            {
                var token = DataAccess.TokenData().Delete(key);
                //GetMapper().Map<TokenDTO>(token);
                return true;
            }
            return false;
        }
    }
    }

