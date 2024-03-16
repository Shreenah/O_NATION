using System.Models;

namespace System.Interface

{
    public interface IUsers
    {
        public List<User> GetUserDetails();
        public User GetUserDetails(string id);
        public void AddUser(User user);
        public void UpdatUser(User user);
        public User DeleteUser(string id );
        public bool CheckUser(string id);

    }
}


  