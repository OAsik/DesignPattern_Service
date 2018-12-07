using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class UsersMapping
    {
        public static List<UsersWM> MapToWM(List<Users> entityList)
        {
            return entityList.Select(x => new UsersWM
            {
                UserID = x.UserID,
                UserNameSurname = x.UserNameSurname,
                UserTitle = x.UserTitle,
                City = x.City,
                Country = x.Country,
                Phone = x.Phone,
                UserAppName = x.UserAppName,
                UserPassword = x.UserPassword
            }).ToList();
        }

        public static UsersWM MapToWM(IQueryable<Users> entity)
        {
            return new UsersWM()
            {
                UserID = entity.FirstOrDefault().UserID,
                UserNameSurname = entity.FirstOrDefault().UserNameSurname,
                UserTitle = entity.FirstOrDefault().UserTitle,
                City = entity.FirstOrDefault().City,
                Country = entity.FirstOrDefault().Country,
                Phone = entity.FirstOrDefault().Phone,
                UserAppName = entity.FirstOrDefault().UserAppName,
                UserPassword = entity.FirstOrDefault().UserPassword
            };
        }

        public static UsersWM MapToWM(Users entity)
        {
            return new UsersWM()
            {
                UserID = entity.UserID,
                UserNameSurname = entity.UserNameSurname,
                UserTitle = entity.UserTitle,
                City = entity.City,
                Country = entity.Country,
                Phone = entity.Phone,
                UserAppName = entity.UserAppName,
                UserPassword = entity.UserPassword
            };
        }

        public static List<Users> MapToEntity(List<UsersWM> webModelList)
        {
            return webModelList.Select(x => new Users
            {
                UserID = x.UserID,
                UserNameSurname = x.UserNameSurname,
                UserTitle = x.UserTitle,
                City = x.City,
                Country = x.Country,
                Phone = x.Phone,
                UserAppName = x.UserAppName,
                UserPassword = x.UserPassword
            }).ToList();
        }

        public static Users MapToEntity(UsersWM webModel)
        {
            return new Users()
            {
                UserID = webModel.UserID,
                UserNameSurname = webModel.UserNameSurname,
                UserTitle = webModel.UserTitle,
                City = webModel.City,
                Country = webModel.Country,
                Phone = webModel.Phone,
                UserAppName = webModel.UserAppName,
                UserPassword = webModel.UserPassword
            };
        }
    }
}