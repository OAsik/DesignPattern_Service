using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XaPa.Service.Helper.Constants;
using XaPa.Service.Manager.Business.XaPaOperations;
using XaPa.Service.Mapper.Manager;
using XaPa.Service.Model.Entity.XaPa;
using XaPa.Service.Model.WebModel;

namespace XaPa.Service.Manager.BusinessManager
{
    public class UserTokensManager : BaseManager
    {
        private readonly UserTokensOperations _userTokensOperations;
        private readonly UsersOperations _userOperations;

        public UserTokensManager()
        {
            _userTokensOperations = new UserTokensOperations(base.IUOW);
            _userOperations = new UsersOperations(base.IUOW);
        }

        public UserTokensWM GetUserToken(int id)
        {
            try
            {
                return UserTokensMapping.MaptoWM(_userTokensOperations.GetUserToken(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTokensWM> GetAllUserTokens()
        {
            try
            {
                return UserTokensMapping.MaptoWM(_userTokensOperations.GetAllUserTokens());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<UserTokensWM> FindUserTokens(Expression<Func<UserTokens, bool>> predicate)
        {
            try
            {
                return UserTokensMapping.MaptoWM(_userTokensOperations.FindUserTokens(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserToken(UserTokensWM webModel)
        {
            try
            {
                _userTokensOperations.AddUserToken(UserTokensMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AddUserTokens(List<UserTokensWM> webModelList)
        {
            try
            {
                _userTokensOperations.AddUserTokens(UserTokensMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteUserToken(UserTokensWM webModel)
        {
            try
            {
                _userTokensOperations.DeleteUserToken(UserTokensMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeteleUserTokens(List<UserTokensWM> webModelList)
        {
            try
            {
                _userTokensOperations.DeleteUserTokens(UserTokensMapping.MapToEntity(webModelList));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateUserToken(UserTokensWM webModel)
        {
            try
            {
                _userTokensOperations.UpdateUserToken(UserTokensMapping.MapToEntity(webModel));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void PublishToken(string userName, string password, int expiryTime, int notBeforeTime)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                {
                    throw new Exception(ErrorMessageConstants.UserNameNotFound);
                }

                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception(ErrorMessageConstants.UserPasswordNotFound);
                }

                var user = _userOperations.FindUser(x => x.UserAppName == userName && x.UserPassword == password);

                if (user == null)
                {
                    throw new Exception(ErrorMessageConstants.UserNotFound);
                }

                string token = _userTokensOperations.PublishToken(userName, password, expiryTime, notBeforeTime);

                UserTokensWM userToken = new UserTokensWM
                {
                    UserID = user.FirstOrDefault().UserID,
                    UserToken = token,
                    CreationDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddMinutes(expiryTime)
                };

                AddUserToken(userToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}