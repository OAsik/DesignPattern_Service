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
    public class UserTokensOperations
    {
        private readonly IUnitOfWork _uow;

        public UserTokensOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserTokens GetUserToken(int id)
        {
            try
            {
                UserTokens userToken = _uow.UserTokens.Get(id);
                _uow.Complete();
                return userToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTokens> GetAllUserTokens()
        {
            try
            {
                List<UserTokens> userTokenList = _uow.UserTokens.GetAll().ToList();
                _uow.Complete();
                return userTokenList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTokens> FindUserTokens(Expression<Func<UserTokens, bool>> predicate)
        {
            try
            {
                List<UserTokens> userTokenList = _uow.UserTokens.Find(predicate).ToList();
                _uow.Complete();
                return userTokenList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserToken(UserTokens entity)
        {
            try
            {
                _uow.UserTokens.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserTokens(List<UserTokens> entityList)
        {
            try
            {
                _uow.UserTokens.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUserToken(UserTokens entity)
        {
            try
            {
                _uow.UserTokens.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUserTokens(List<UserTokens> entityList)
        {
            try
            {
                _uow.UserTokens.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateUserToken(UserTokens entity)
        {
            try
            {
                _uow.UserTokens.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string PublishToken(string userName, string password, int expiryTime, int notBeforeTime)
        {
            try
            {
                return _uow.UserTokens.PublishToken(userName, password, expiryTime, notBeforeTime);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}