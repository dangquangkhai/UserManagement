namespace UserManagement.LIBRARY.RDBMModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Salary")]
    public partial class Salary
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? MonthID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Payment { get; set; }

        public int? PayMentOfUserID { get; set; }

        public virtual Monthly_Schedule Monthly_Schedule { get; set; }

        public virtual PaymentPerDay PaymentPerDay { get; set; }

        public virtual User User { get; set; }
    }
}
