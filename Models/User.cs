using System;

namespace UserNamespace
{
    public class UserObjects
    {
        // Definerer bruker, samt med en constructer sånn at det kan bli brukt.
        public int UserID { get; set; }
        public string Brukernavn { get; set; }
        public string Email { get; set; }
        public string Password {get; set; } 
        // Hash metode får passord senere, vet ikke om gidder enda. 
        // cryptographic metode ?
        public UserObjects(string brukernavn, string email, string password)
        {
           Brukernavn = brukernavn;
           Email = email;
           Password = password;
        }
    } 
}

