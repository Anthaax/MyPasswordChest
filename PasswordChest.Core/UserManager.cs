using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace PasswordChest.Core
{
    public class UserManager
    {
        User _currentUser;
        readonly ChestContext _context;
        public UserManager(ChestContext context)
        {
            _context = context;
            User.UserHaveChange += (s, e) => SaveUser(s as User);
        }
        public static event EventHandler UserHasBeenCreated;

        public User CurrentUser => _currentUser;

        public User CreateNewUser(string firstName, string lastName, string password)
        {
            if (_context.UsersName.Contains(User.GetUserFullName(firstName,lastName)))
                throw new InvalidOperationException("User alredy exist");
            User user = new User(firstName, lastName, password);
            UserHasBeenCreated?.Invoke(user, EventArgs.Empty);
            SaveUser(user);
            _currentUser = user;
            return user;
        }
        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }
        public void SaveUser(User user)
        {
            string path = Constants.SaveFolderPath + Path.DirectorySeparatorChar + user.GetHashCode();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fs, user);
            }
        }
        public void LoadUser(string userName)
        {
            User user;
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream sr = new FileStream(Constants.SaveFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                user = formatter.Deserialize(sr) as User;
            }
            _currentUser = user;
        }

    }
}