using System;

namespace AdminUsersNamespace
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