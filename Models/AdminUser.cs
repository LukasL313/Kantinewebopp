using System;

namespace KantinaWeb.Models

{
    public class AdminUser
    {
        public int Admin_ID {get; set;}
        public string Adminbruker { get; set; }
        public string Adminpass { get; set; }

        public AdminUser(string adminbruker, string adminpass)
        {
           Adminbruker = adminbruker;
           Adminpass = adminpass;
        }
    }
}