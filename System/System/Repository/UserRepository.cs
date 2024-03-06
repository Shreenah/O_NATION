using Microsoft.EntityFrameworkCore;
using System.Interface;
using System.Models;

namespace System.Repository
{
    public class UserRepository : IUsers
    {

        readonly O_NATIONContext _dbContext = new();

        public UserRepository(O_NATIONContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUserDetails()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public User DeleteUser(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(int id)
        {
            return _dbContext.Users.Any(u => u.UserId == id);
        }

        public User GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}


    


      
