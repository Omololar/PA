using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repositories
{
    public interface IRoleRepository
    {
        Task<RoleModel> GetRoleById(string roleId);
        Task<RoleModel[]> GetAllRole();
        Task<UserModel> AddUserToRole(UserModel user, string[] roleId);
        Task<RoleModel> Create(RoleModel model);

    }
}
