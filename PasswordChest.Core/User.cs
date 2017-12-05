using System;

namespace PasswordChest.Core
{
    [Serializable]
    public class User
    {
        string _password;

        public User(string firstName, string lastName, string inputPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            _password = PasswordCrypt(inputPassword);
        }

        public static string GetUserFullName(string firstName, string lastName) => firstName + Constants.SEPARATOR_KEY + lastName;

        [field: NonSerialized]
        public static event EventHandler UserHaveChange;

        public string LastName { get; }
        public string FirstName { get; }
        public string FullName => GetUserFullName(FirstName, LastName);

        public bool IsCorrectPassword(string password)
        {
            return PasswordCrypt(password) == _password;
        }

        private string PasswordCrypt(string inputPassword)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputPassword);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);

        }
    }
}
