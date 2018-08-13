using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public Users()
        {
        }

        public Users(string UId, string Email, string Psw, bool Teacher)
        {
            this.UId = UId;
            this.Email = Email;
            this.Psw = Psw;
            this.Teacher = Teacher;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            var hashCode = -718741358;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Psw);
            hashCode = hashCode * -1521134295 + Teacher.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var users = obj as Users;
            return users != null &&
                   UId == users.UId &&
                   Email == users.Email &&
                   Psw == users.Psw &&
                   Teacher == users.Teacher;
        }
    }
}