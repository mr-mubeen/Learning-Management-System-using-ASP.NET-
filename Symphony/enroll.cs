//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Symphony
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class enroll
    {
        [Display(Name = "Enroll Id")]
        [Required]
        public int enroll_id { get; set; }

        [Display(Name = "Student Name")]
        [Required]
        public string s_name { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        
        public decimal cell { get; set; }

        [Display(Name = "Course Id")]
        [Required]
        public int c_id { get; set; }
    
        public virtual cours cours { get; set; }
        public virtual entance_exams entance_exams { get; set; }
    }
}