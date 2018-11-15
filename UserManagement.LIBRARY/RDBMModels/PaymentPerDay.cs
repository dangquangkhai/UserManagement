namespace UserManagement.LIBRARY.RDBMModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentPerDay")]
    public partial class PaymentPerDay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentPerDay()
        {
            Salaries = new HashSet<Salary>();
        }

        public int ID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Money { get; set; }

        [Column(TypeName = "money")]
        public decimal? Allowance { get; set; }

        public int? UserID { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
