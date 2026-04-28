namespace WalletApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class savings_transfers
    {
        [Key]
        public int transfer_id { get; set; }

        public int goal_id { get; set; }

        public decimal amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime transfer_date { get; set; }

        public virtual savings_goals savings_goals { get; set; }
    }
}
