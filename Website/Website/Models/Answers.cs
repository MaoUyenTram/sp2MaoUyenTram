using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Website.Models
{
    [Table("Answers")]
    public class Answers
    {
        [Key,Required]
        public int AId { get; set; }
        
        public int QId { get; set;}
        [ForeignKey("QId")]
        public virtual Questions Questions { get; set; }
        public String Answer { get; set; }



        public Answers(int aId, int qId, string answer)
        {
            this.AId = aId;
            this.QId = qId;
            this.Answer = answer;
        }
    }
}