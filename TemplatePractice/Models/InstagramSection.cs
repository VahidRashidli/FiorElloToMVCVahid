using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TemplatePractice.Models
{
    public class InstagramSection:BaseEntity
    {
        [Column(TypeName ="varchar(50)")]
        public string Title { get; set; }
    }
}
