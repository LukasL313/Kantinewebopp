using System;

namespace UserNamespace
{
    public class UserObjects
    {
        // Definerer bruker, samt med en constructer sånn at det kan bli brukt.
        public int UserID { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string Password {get; set; } 
        // Hash metode får passord senere, vet ikke om gidder enda. 
        // cryptographic metode ?
        public UserObjects(string user, string email, string password)
        {
           User = user;
           Email = email;
           Password = password;
        }
    } 
}

