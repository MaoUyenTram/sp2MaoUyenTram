using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Models
{
    [Table("Qanswers")]
    public class QAnswers
    {
        
        public int QId { get; set; }
        [ForeignKey("QId")]
        public Questions Questions { get; set; }
        
        public int AId { get; set; }
        [ForeignKey("AId")]
        public Answers Answers { get; set; }
        
        public String UId { get; set; }
        [ForeignKey("UId"), Column(Order =0)]
        public Users Users { get; set; }



        public QAnswers(int qId, int aId, string uId)
        {
            this.QId = qId;
            this.AId = aId;
            this.UId = uId;
        }
    }
}