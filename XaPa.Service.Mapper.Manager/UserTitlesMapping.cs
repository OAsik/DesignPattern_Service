using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class UserTitlesMapping
    {
        public static List<UserTitlesWM> MaptoWM(List<UserTitles> entityList)
        {
            return entityList.Select(x => new UserTitlesWM
            {
                UserTitleID = x.UserTitleID,
                UserTitleName = x.UserTitleName
            }).ToList();
        }

        public static UserTitlesWM MaptoWM(UserTitles entity)
        {
            return new UserTitlesWM()
            {
                UserTitleID = entity.UserTitleID,
                UserTitleName = entity.UserTitleName
            };
        }

        public static List<UserTitles> MapToEntity(List<UserTitlesWM> webModelList)
        {
            return webModelList.Select(x => new UserTitles
            {
                UserTitleID = x.UserTitleID,
                UserTitleName = x.UserTitleName
            }).ToList();
        }

        public static UserTitles MapToEntity(UserTitlesWM webModel)
        {
            return new UserTitles()
            {
                UserTitleID = webModel.UserTitleID,
                UserTitleName = webModel.UserTitleName
            };
        }
    }
}