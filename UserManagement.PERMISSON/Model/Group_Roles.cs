namespace UserManagement.PERMISSON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group_Roles
    {
        public int ID { get; set; }

        public int? GroupID { get; set; }

        public int? RoleID { get; set; }

        public virtual Group Group { get; set; }

        public virtual Role Role { get; set; }
    }
}
