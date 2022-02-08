using ApiProject_C3._0.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ApiProject_C3._0.Repository
{
    public class UserRepository:IUserRepository
    {
        readonly DemoDbContext demoDbContext;
        public UserRepository(DemoDbContext dbContext)
        {
            demoDbContext = dbContext;
        }

        public async Task<UserDemo> CreateUser(UserDemo userDemo)
        {
            var result=await demoDbContext.UserDemo.AddAsync(userDemo);
            await demoDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(int id)
        {
            var result=await demoDbContext.UserDemo.FirstOrDefaultAsync(x=>x.Id==id);
            if (result!=null)
            {
                demoDbContext.UserDemo.Remove(result);
                await demoDbContext.SaveChangesAsync();
            }
        }

        public async Task<UserDemo> GetUserById(int id)
        {
            var result= await demoDbContext.UserDemo.FirstOrDefaultAsync(x=>x.Id == id);
            return result;
        }

        public async Task<UserDemo> UpdateUser(UserDemo userDemo)
        {
            var result=demoDbContext.UserDemo.FirstOrDefault(x=>x.Id==userDemo.Id);
            
            if (result!=null)
            {
                result.Nom = userDemo.Nom;
                result.Prenom = userDemo.Prenom;
                await demoDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<UserDemo>> GetAllusers()
        {
            var result=await demoDbContext.UserDemo.ToListAsync();
            return result;
        }
    }
}
