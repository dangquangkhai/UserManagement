namespace UserManagement.PERMISSON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            Group_Roles = new HashSet<Group_Roles>();
            Role_Permissions = new HashSet<Role_Permissions>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Descriptions { get; set; }

        public DateTime? Created { get; set; }

        public int? CreatorID { get; set; }

        public DateTime? Modified { get; set; }

        public int? Modifier { get; set; }

        [StringLength(10)]
        public string Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group_Roles> Group_Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role_Permissions> Role_Permissions { get; set; }

        public virtual User User { get; set; }
    }
}
