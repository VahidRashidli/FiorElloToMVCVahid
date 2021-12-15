using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class InstagramSectionPicture:BaseEntity
    {
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column(TypeName ="varchar(50)")]
        public string ImageName { get; set; }
    }
}
