using System.ComponentModel.DataAnnotations;

namespace KantinaWeb.Models
{
    public class UserObjects
    {
        // Bruker model 
        public int UserID { get; set; }

        public string Brukernavn { get; set; }

        public string Email { get; set; }

        public string Passord {get; set; } 

        public UserObjects(){}

        public UserObjects(string brukernavn, string email, string passord, int userid)
        {
           Brukernavn = brukernavn;
           Email = email;
           Passord = passord;
           UserID = userid;
        }
    } 
}

