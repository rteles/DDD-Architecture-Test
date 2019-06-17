using Arch.Application.DataTypes.Request;
using Arch.Application.DataTypes.Result;

namespace Arch.Application.Services.Contracts
{
    public interface IUserAppService
    {
        OperationResult AddUser(AddUserRequest request);
        OperationResultList<UserResult> GetUsers(bool onlyActive);
        OperationResult<UserResult> GetUser(int userId);
        OperationResult UpdateUser(UpdateUserRequest request);
        OperationResult DeleteUser(int userId);
    }
}