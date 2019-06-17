using Arch.Application.DataTypes.Request;
using Arch.Application.DataTypes.Result;
using Arch.Application.Services.Contracts;
using Arch.Infra.Common.Logging;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arch.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly Core.Interfaces.Service.IUserService _userService;

        public UserAppService(Core.Interfaces.Service.IUserService userService)
        {
            _userService = userService;
        }

        public OperationResultList<UserResult> GetUsers(bool onlyActive)
        {
            var or = new OperationResultList<UserResult>();

            try
            {
                var users = _userService.GetUsers(onlyActive);
                var usersResult = Mapper.DynamicMap<List<Core.Entities.User>, List<DataTypes.Result.UserResult>>(users.ToList());

                or.Success = true;
                or.Data = usersResult;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Data = null;
                or.Message = ex.Message;
                ex.LogException();
            }

            return or;
        }

        public OperationResult<UserResult> GetUser(int userId)
        {
            var or = new OperationResult<UserResult>();

            try
            {
                var user = _userService.GetUser(userId);
                var userResult = Mapper.DynamicMap<Core.Entities.User, DataTypes.Result.UserResult>(user);

                or.Success = true;
                or.Data = userResult;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Data = null;
                or.Message = ex.Message;
                ex.LogException();
            }

            return or;
        }

        public OperationResult AddUser(AddUserRequest request)
        {
            var or = new OperationResult();

            try
            {
                var newUser = Mapper.DynamicMap<AddUserRequest, Core.Entities.User>(request);
                _userService.AddUser(newUser);
                or.Success = true;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Message = ex.Message;
                ex.LogException();
            }

            return or;
        }

        public OperationResult UpdateUser(UpdateUserRequest request)
        {
            var or = new OperationResult();

            try
            {
                var newUser = Mapper.DynamicMap<UpdateUserRequest, Core.Entities.User>(request);
                _userService.UpdateUser(newUser);
                or.Success = true;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Message = ex.Message;
                ex.LogException();
            }

            return or;
        }

        public OperationResult DeleteUser(int userId)
        {
            var or = new OperationResult();

            try
            {
                var user = _userService.GetUser(userId);
                _userService.DeleteUser(user);
                or.Success = true;
            }
            catch (Exception ex)
            {
                or.Success = false;
                or.Message = ex.Message;
                ex.LogException();
            }

            return or;
        }
    }
}