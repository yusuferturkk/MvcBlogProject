//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblBlog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblBlog()
        {
            this.TblComment = new HashSet<TblComment>();
        }
    
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public Nullable<System.DateTime> BlogDate { get; set; }
        public string BlogImage { get; set; }
        public Nullable<byte> TypeId { get; set; }
        public Nullable<byte> CategoryId { get; set; }
    
        public virtual TblCategory TblCategory { get; set; }
        public virtual TblType TblType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblComment> TblComment { get; set; }
    }
}
