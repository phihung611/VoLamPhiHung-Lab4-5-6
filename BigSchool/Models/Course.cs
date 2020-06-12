using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public ApplicationUser Lecturer { get; set; }
        [Required]
        [StringLength(225)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; }
        [Required]
        public byte CategoryId { get; set; }

    }
}