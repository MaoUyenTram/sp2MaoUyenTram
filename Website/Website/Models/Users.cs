using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    [Table("Users")]
    public class Users
    {
        [Key,Required]
        public String UId { get; set; }
        public String Email { get; set; }
        public String Psw { get; set; }
        public Boolean Teacher { get; set;}



        public Users(string UId, string Email, string Psw, bool Teacher)
        {
            this.UId = UId;
            this.Email = Email;
            this.Psw = Psw;
            this.Teacher = Teacher;
        }

    }
}