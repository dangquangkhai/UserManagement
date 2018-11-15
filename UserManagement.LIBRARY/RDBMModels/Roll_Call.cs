namespace UserManagement.LIBRARY.RDBMModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Roll_Call
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public DateTime? Created { get; set; }

        public bool? Count { get; set; }

        public virtual User User { get; set; }
    }
}
