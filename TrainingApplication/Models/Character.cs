using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingApplication.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Character Name")]
        [Required]
        public string Characters { get; set; }
        [DisplayName("Vision")]
        [Required]
        public string VisionType { get; set; }
        [Required]
        public string Weapon { get; set; }
        [Required]
        [Range(1,90,ErrorMessage = "Woah that out of this world?!")]
        public int Level { get; set; }
        [Required]
        public string Nation { get; set; }
        [Required]
        public string Birthday { get; set; }

    }
}
