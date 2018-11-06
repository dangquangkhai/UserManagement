namespace UserManagement.PERMISSON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group_Users
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? GroupID { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
    }
}
