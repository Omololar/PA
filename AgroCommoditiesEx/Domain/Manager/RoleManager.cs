using Domain.Interface.Managers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Manager
{
    public class RoleManager : IRoleManager
    {
        public Task<UserModel> AddUserToRolesAsync(UserModel user, string[] roleIds)
        {
            throw new NotImplementedException();
        }

        public Task<RoleModel[]> GetAllRole()
        {
            throw new NotImplementedException();
        }

        public Task<RoleModel> GetRoleById(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<RoleModel> SaveRole(RoleModel role)
        {
            throw new NotImplementedException();
        }
    }
}
