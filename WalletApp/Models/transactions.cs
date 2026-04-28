namespace WalletApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class transactions
    {
        [Key]
        public int transaction_id { get; set; }

        public int user_id { get; set; }

        public int category_id { get; set; }

        public decimal amount { get; set; }

        public DateTime transaction_date { get; set; }

        public bool is_income { get; set; }

        public virtual categories categories { get; set; }

        public virtual users users { get; set; }
    }
}
