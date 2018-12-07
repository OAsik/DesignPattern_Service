using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Mapper.Manager
{
    public class UserTokensMapping
    {
        public static List<UserTokensWM> MaptoWM(List<UserTokens> entityList)
        {
            return entityList.Select(x => new UserTokensWM
            {
                UserTokenID = x.UserTokenID,
                UserID = x.UserID,
                UserToken = x.UserToken,
                CreationDate = x.CreationDate,
                ExpiryDate = x.ExpiryDate
            }).ToList();
        }

        public static UserTokensWM MaptoWM(UserTokens entity)
        {
            return new UserTokensWM()
            {
                UserTokenID = entity.UserTokenID,
                UserID = entity.UserID,
                UserToken = entity.UserToken,
                CreationDate = entity.CreationDate,
                ExpiryDate = entity.ExpiryDate
            };
        }

        public static List<UserTokens> MapToEntity(List<UserTokensWM> webModelList)
        {
            return webModelList.Select(x => new UserTokens
            {
                UserTokenID = x.UserTokenID,
                UserID = x.UserID,
                UserToken = x.UserToken,
                CreationDate = x.CreationDate,
                ExpiryDate = x.ExpiryDate
            }).ToList();
        }

        public static UserTokens MapToEntity(UserTokensWM webModel)
        {
            return new UserTokens()
            {
                UserTokenID = webModel.UserTokenID,
                UserID = webModel.UserID,
                UserToken = webModel.UserToken,
                CreationDate = webModel.CreationDate,
                ExpiryDate = webModel.ExpiryDate
            };
        }
    }
}