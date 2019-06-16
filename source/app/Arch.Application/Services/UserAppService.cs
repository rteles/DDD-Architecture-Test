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

        public OperationResultList<UserResult> GetActiveUsers()
        {
            var or = new OperationResultList<UserResult>();

            try
            {
                var users = _userService.GetActiveUsers();
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
    }
}