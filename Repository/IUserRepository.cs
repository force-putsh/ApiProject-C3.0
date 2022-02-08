using ApiProject_C3._0.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProject_C3._0.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDemo>> GetAllusers();
        Task<UserDemo> GetUserById(int id);
        Task<UserDemo> CreateUser(UserDemo user);
        Task<UserDemo> UpdateUser(UserDemo user);
        Task DeleteUser(int id);
    }
}
