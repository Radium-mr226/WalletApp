namespace WalletApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class savings_goals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public savings_goals()
        {
            savings_transfers = new HashSet<savings_transfers>();
        }

        [Key]
        public int goal_id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public decimal target_amount { get; set; }

        public virtual users users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<savings_transfers> savings_transfers { get; set; }
    }
}
