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
    using System.Web;

    public partial class video
    {

        [Display(Name = "Video Id")]
        [Required]
        public int v_id { get; set; }

        [Display(Name = "Lecture Name")]
        [Required]
        public string lecture_name { get; set; }


        [Display(Name = "Video Name")]
        [Required]
        public string video_path { get; set; }
        public HttpPostedFileBase videofile { get; set; }

        [Display(Name = "Course Id")]
        [Required]
        public int c_id { get; set; }

        public virtual cours cours { get; set; }
    }
}