using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Data.UnitOfWork.Infrastructure;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Manager.Business.XaPaOperations
{
    public class UserTitlesOperations
    {
        private readonly IUnitOfWork _uow;

        public UserTitlesOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserTitles GetUserTitle(int id)
        {
            try
            {
                UserTitles userTitle = _uow.UserTitles.Get(id);
                _uow.Complete();
                return userTitle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTitles> GetAllUserTitles()
        {
            try
            {
                List<UserTitles> userTitleList = _uow.UserTitles.GetAll().ToList();
                _uow.Complete();
                return userTitleList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTitles> FindUserTitles(Expression<Func<UserTitles, bool>> predicate)
        {
            try
            {
                List<UserTitles> userTitleList = _uow.UserTitles.Find(predicate).ToList();
                _uow.Complete();
                return userTitleList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserTitle(UserTitles entity)
        {
            try
            {
                _uow.UserTitles.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserTitles(List<UserTitles> entityList)
        {
            try
            {
                _uow.UserTitles.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUserTitle(UserTitles entity)
        {
            try
            {
                _uow.UserTitles.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUserTitles(List<UserTitles> entityList)
        {
            try
            {
                _uow.UserTitles.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateUserTitle(UserTitles entity)
        {
            try
            {
                _uow.UserTitles.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}