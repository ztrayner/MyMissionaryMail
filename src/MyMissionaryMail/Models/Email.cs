using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMissionaryMail.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FromEmail { get; set; }
        [Required]
        public string RecipientEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        public string BodyPlain { get; set; }
        public string StrippedText { get; set; }
        public string StrippedSignature { get; set; }
        public string BodyHtml { get; set; }
        public string StrippedHtml { get; set; }
        public int? AttachmentCount { get; set; }
        public long TimeStampSeconds { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<string> AttachmentLinks { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        [ForeignKey("Missionary")]
        public int? MissionaryId { get; set; }
    }
}
