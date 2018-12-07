using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Manager.Business.XaPaOperations;
using XaPa.Service.Mapper.Manager;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Manager.BusinessManager
{
    public class UserTitlesManager : BaseManager
    {
        private readonly UserTitlesOperations _userTitlesOperations;

        public UserTitlesManager()
        {
            _userTitlesOperations = new UserTitlesOperations(base.IUOW);
        }

        public UserTitlesWM GetUserTitle(int id)
        {
            try
            {
                return UserTitlesMapping.MaptoWM(_userTitlesOperations.GetUserTitle(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTitlesWM> GetAllUserTitles()
        {
            try
            {
                return UserTitlesMapping.MaptoWM(_userTitlesOperations.GetAllUserTitles());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTitlesWM> FindUserTitles(Expression<Func<UserTitles, bool>> predicate)
        {
            try
            {
                return UserTitlesMapping.MaptoWM(_userTitlesOperations.FindUserTitles(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserTitle(UserTitlesWM webModel)
        {
            try
            {
                _userTitlesOperations.AddUserTitle(UserTitlesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserTitles(List<UserTitlesWM> webModelList)
        {
            try
            {
                _userTitlesOperations.AddUserTitles(UserTitlesMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUserTitle(UserTitlesWM webModel)
        {
            try
            {
                _userTitlesOperations.DeleteUserTitle(UserTitlesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleUserTitles(List<UserTitlesWM> webModelList)
        {
            try
            {
                _userTitlesOperations.DeleteUserTitles(UserTitlesMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateUserTitle(UserTitlesWM webModel)
        {
            try
            {
                _userTitlesOperations.UpdateUserTitle(UserTitlesMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}