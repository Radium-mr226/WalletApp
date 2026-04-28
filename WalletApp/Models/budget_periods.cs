namespace WalletApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class budget_periods
    {
        [Key]
        public int period_id { get; set; }

        public int user_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        public decimal? planned_budget { get; set; }

        public virtual users users { get; set; }
    }
}
