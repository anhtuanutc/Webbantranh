//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL_TTCMWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Order()
        {
            this.tbl_orderDetail = new HashSet<tbl_orderDetail>();
        }
    
        public int order_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string order_receiver_note { get; set; }
        public Nullable<double> order_total_price { get; set; }
        public Nullable<int> order_state { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_orderDetail> tbl_orderDetail { get; set; }
        public virtual tbl_state tbl_state { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}
