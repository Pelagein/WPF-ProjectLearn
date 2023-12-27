using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.Model
{
    public class Users
    {
        public Users(string Name,string Password) 
        {
            this.Name = Name;
            this.Password = Password;
            Role = "users";
        }
        
        [Required]
        public Int32 id { get; set; }

        [MaxLength(30)]
        public String Name { get; set; }

        [MaxLength(30)]
        public String Password { get; set; }

        [MaxLength(15)]
        public String Role { get; set; }
    }
}
