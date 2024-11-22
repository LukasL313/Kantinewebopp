using System;

namespace User
{
    public class UserObjects
    {
        public string User { get; }
        public string Email { get; }
        public string Password {get; } 
        // Hash metode får passord senere, vet ikke om gidder enda. 
        // cryptographic metode ?

        // Constructer 
        public UserObjects( string user, string email, string password)
        {
           User = user;
           Email = email;
           Password = password;
        }
    } 
}

