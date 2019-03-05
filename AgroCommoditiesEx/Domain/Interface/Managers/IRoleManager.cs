using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Managers
{
    public interface IRoleManager
    {
        Task<UserModel> AddUserToRolesAsync(UserModel user, string[] roleIds);
        Task<RoleModel> GetRoleById(string roleId);
        Task<RoleModel[]> GetAllRole();

        Task<RoleModel> SaveRole(RoleModel role);

    }
}
