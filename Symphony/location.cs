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
    using System.Web;

    public partial class location
    {
        public int l_id { get; set; }
        public string Address { get; set; }
        public decimal Telephone { get; set; }
        public string image { get; set; }

        public HttpPostedFileBase imagefile { get; set; }
    }
}
