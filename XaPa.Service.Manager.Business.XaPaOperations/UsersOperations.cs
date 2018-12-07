using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Data.UnitOfWork.Infrastructure;
using XaPa.Service.Model.Entity.XaPa;

namespace XaPa.Service.Manager.Business.XaPaOperations
{
    public class UsersOperations
    {
        private readonly IUnitOfWork _uow;

        public UsersOperations(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Users GetUser(int id)
        {
            try
            {
                Users user = _uow.Users.Get(id);
                _uow.Complete();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Users> GetAllUsers()
        {
            try
            {
                List<Users> userList = _uow.Users.GetAll().ToList();
                _uow.Complete();
                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IQueryable<Users> FindUser(Expression<Func<Users, bool>> predicate)
        {
            try
            {
                IQueryable<Users> user = _uow.Users.FindUser(predicate);
                _uow.Complete();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Users> FindUsers(Expression<Func<Users, bool>> predicate)
        {
            try
            {
                List<Users> userList = _uow.Users.Find(predicate).ToList();
                _uow.Complete();
                return userList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUser(Users entity)
        {
            try
            {
                _uow.Users.Add(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUsers(List<Users> entityList)
        {
            try
            {
                _uow.Users.AddRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUser(Users entity)
        {
            try
            {
                _uow.Users.Remove(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUsers(List<Users> entityList)
        {
            try
            {
                _uow.Users.RemoveRange(entityList);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateUser(Users entity)
        {
            try
            {
                _uow.Users.Update(entity);
                _uow.Complete();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IQueryable<Users> IdentifyUser(ClaimsIdentity claimsIdentity)
        {
            try
            {
                return _uow.Users.IdentifyUser(claimsIdentity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}