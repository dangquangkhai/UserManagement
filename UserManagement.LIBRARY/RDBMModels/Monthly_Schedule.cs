namespace UserManagement.LIBRARY.RDBMModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Monthly_Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Monthly_Schedule()
        {
            Salaries = new HashSet<Salary>();
        }

        public int ID { get; set; }

        public DateTime? BeginDay { get; set; }

        public DateTime? EndDay { get; set; }

        public int? UserID { get; set; }

        public int? TotalCount { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
