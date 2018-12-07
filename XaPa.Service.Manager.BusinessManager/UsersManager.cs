using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Manager.Business.XaPaOperations;
using XaPa.Service.Mapper.Manager;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Manager.BusinessManager
{
    public class UsersManager : BaseManager
    {
        private readonly UsersOperations _usersOperations;

        public UsersManager()
        {
            _usersOperations = new UsersOperations(base.IUOW);
        }

        public UsersWM GetUser(int id)
        {
            try
            {
                return UsersMapping.MapToWM(_usersOperations.GetUser(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UsersWM> GetAllUsers()
        {
            try
            {
                return UsersMapping.MapToWM(_usersOperations.GetAllUsers());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public UsersWM FindUser(Expression<Func<Users, bool>> predicate)
        {
            try
            {
                return UsersMapping.MapToWM(_usersOperations.FindUser(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UsersWM> FindUsers(Expression<Func<Users, bool>> predicate)
        {
            try
            {
                return UsersMapping.MapToWM(_usersOperations.FindUsers(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUser(UsersWM webModel)
        {
            try
            {
                _usersOperations.AddUser(UsersMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUsers(List<UsersWM> webModelList)
        {
            try
            {
                _usersOperations.AddUsers(UsersMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUser(UsersWM webModel)
        {
            try
            {
                _usersOperations.DeleteUser(UsersMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleUsers(List<UsersWM> webModelList)
        {
            try
            {
                _usersOperations.DeleteUsers(UsersMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateUser(UsersWM webModel)
        {
            try
            {
                _usersOperations.UpdateUser(UsersMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public UsersWM IdentifyUser(ClaimsIdentity claimsIdentity)
        {
            try
            {
                return UsersMapping.MapToWM(_usersOperations.IdentifyUser(claimsIdentity));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}