using System.Models;

namespace System.Interface

{
    public interface IUsers
    {
        public List<User> GetUserDetails();
        public User GetUserDetails(int id);
        public void AddUser(User user);
        public void UpdatUser(User user);
        public User DeleteUser(int id);
        public bool CheckUser(int id);

    }
}


  