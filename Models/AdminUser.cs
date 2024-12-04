using System;
namespace KantinaWeb.Models
{
    public class AdminUser
    {
        public int Admin_ID { get; set;}
        public string Adminbruker { get; set; }
        public string Adminpass { get; set; }

        public AdminUser(int admin_id, string adminbruker, string adminpass)
        {  
           Admin_ID = admin_id; 
           Adminbruker = adminbruker;
           Adminpass = adminpass;
        }
    }
}