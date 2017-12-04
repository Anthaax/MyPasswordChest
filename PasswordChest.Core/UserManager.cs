using System;

namespace PasswordChest.Core
{
    public class UserManager
    {
        User _currentUser;
        public UserManager(ChestContext context)
        {
            User.UserHaveChange += (s, e) => SaveUser(s as User);
        }
        public User CurrentUser => _currentUser;
        public User CreateNewUser()
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }
        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }
        public void LoadUser(string userName)
        {
            throw new NotImplementedException();
        }

    }
}